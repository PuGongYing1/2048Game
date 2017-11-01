using _2048Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        const int N = 4;  //方块在纵向及横向上的个数
        private static int[,] board; //记录每个方块上的数
        static Button[] btns;
        public static int score;
        public static int max = 0;//记录最高分

        static int gameMode;
        static string[] str0 = { "2", "4", "8", "16", "32", "64", "128", "256", "512", "1024", "2048" };
        static string[] str1 = { "夏", "商", "周", "秦", "汉", "隋", "唐", "宋", "元", "明", "清" };
        static string[] str2 = { "一品", "二品", "三品", "四品", "五品", "六品", "七品", "八品", "九品", "良民", "贱民" };
        static string[] str3 = { "士兵", "排长", "连长", "营长", "旅长", "师长", "军长", "司令", "大帅", "良民", "贱民" };

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new int[N, N];
            score = 0;
            gameMode = 0;

            this.Text = "Game2048";
            this.DoubleBuffered = true;

            StartGame();
        }
        private void StartGame()
        {
            //设置两个不同的块为随机的2或4
            Random rnd = new Random();
            int n1 = rnd.Next(N * N);
            int n2;
            do
            {
                n2 = rnd.Next(N * N);
            }
            while (n1 == n2);
            board[n1 / N, n1 % N] = rnd.Next(2) * 2 + 2; //设为2或4
            board[n2 / N, n2 % N] = rnd.Next(2) * 2 + 2;

            InitialUI();
        }
       
        private void InitialUI()//初始化界面
        {
            //生成按钮
            GenerateAllButtons();

        }                
        private void GenerateAllButtons()//产生所有的按钮
        {
            btns = new Button[N * N];

            int x0 = 5, y0 = 5, w = 60, d = w + 5;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = new Button();
                int r = i / N;  //行
                int c = i % N;  //列

                btn.Left = x0 + c * d;
                btn.Top = y0 + r * d;
                btn.Width = w;
                btn.Height = w;
                btn.Font = new Font("楷体", 16);

                btn.Text = GetTextOfButton(board[r, c]);
                btn.BackColor = GetColorOfButton(board[r, c]);

                btn.Visible = true;
                btns[i] = btn;
                this.pnlBoard.Controls.Add(btn);
            }
        }

        private void RefreshUI()//更新界面
        {
            RefreshAllButtons();
        }
        private void RefreshAllButtons()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                int r = i / N;  //行
                int c = i % N;  //列
                btns[i].Text = GetTextOfButton(board[r, c]);
                btns[i].BackColor = GetColorOfButton(board[r, c]);
            }
        }

        string GetTextOfButton(int n)//得到方块上应有的文字
        {
            if (n < 2) return "";

            int k = (int)Math.Log(n, 2) - 1;

            if (gameMode == 0)
            {
                return str0[k];
            }
            else if (gameMode == 1)
            {
                return str1[k];
            }
            else if (gameMode == 2)
            {
                return str2[k];
            }

            else if (gameMode == 3)
            {
                return str3[k];
            }

            return "";
        }
        Color GetColorOfButton(int n) //得到方块上应有的颜色
        {
            if (n == 0) return Color.FromArgb(100, 0, 100, 200);

            int tmp = 230 - (int)Math.Log(n, 2) * 20;
            return Color.FromArgb(250, 0, tmp, tmp);
        }

        //处理键盘消息
        //要注意的是:由于按钮等元素的存在,窗体得不到KeyDown事件,所以在覆盖ProcessCmdKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bMoved = false;

            if (keyData == Keys.Right)
            {
                bMoved = rightMove();
            }
            else if (keyData == Keys.Left)
            {
                bMoved = leftMove();
            }
            else if (keyData == Keys.Down)
            {
                bMoved = downMove();
            }
            else if (keyData == Keys.Up)
            {
                bMoved = upMove();
            }

            if (bMoved)
            {
                generateNewData();
                RefreshUI();
                if (IsGameOver() == true)
                {
                    if (File.Exists(@"D:\2048.txt"))
                    {
                        //读取文件
                        StreamReader re = new StreamReader(@"D:\2048.txt");
                        List<string> sco = new List<string>();
                        string a = re.ReadLine();
                        while (a != null)
                        {
                            string[] b = a.Split('#');
                            sco.Add(b[0]);
                            a = re.ReadLine();
                        }
                        max = GetMax(sco);//在历史记录寻得最大值
                        re.Close();
                    }
                    else
                        File.Create(@"D:\2048.txt").Close();

                    if (score > max && max !=0)
                    {
                        //max = score;
                        pnlBoard.Visible = false;
                        showhappy();
                    }
                    //写入分数和日期
                    StreamWriter wr = new StreamWriter(@"D:\2048.txt", true, Encoding.Default);
                    wr.WriteLine(score.ToString() + "#----------#" + DateTime.Now);
                    wr.Close();

                    MessageBox.Show("Game Over!");

                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //产生新的随机数据
        private void generateNewData()
        {
            Random rnd = new Random();
            //随机找到一个空的块
            int nCount;
            do
            {
                nCount = rnd.Next(N * N);
            }
            while (board[nCount / N, nCount % N] != 0);

            board[nCount / N, nCount % N] = rnd.Next(2) * 2 + 2; //其值设为2或者4
        }

        #region 关于四个方向的业务逻辑
        private bool rightMove()
        {
            bool isMoved = false;
            for (int j = 0; j < board.GetLength(0); j++) //针对所有的行
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int i = board.GetLength(1) - 1; i > -1; i--) //从右边起，针对每个块进行处理
                {
                    if (board[j, i] == 0) continue; //空的块不处理
                    if (board[j, i] == value1)//如果与上一次找到的相等，则合并
                    {
                        board[x1, y1] = board[x1, y1] * 2;
                        board[j, i] = 0;
                        value1 = -1;
                        score += board[x1, y1];
                        isMoved = true;
                        label1.Text = score.ToString();
                    }
                    else
                    {
                        int k;
                        for (k = i + 1; k < board.GetLength(1); k++) //向右找到一个非空的块
                        {
                            if (board[j, k] > 0)
                                break;
                        }
                        if (k - 1 != i)//如果这个非空的块左边有空位置
                        {
                            isMoved = true;
                            board[j, k - 1] = board[j, i]; //“移动”到这里（将其上的数字显示到这里）
                            board[j, i] = 0;
                        }
                        value1 = board[j, k - 1]; //记下这个值（非空的块）
                        x1 = j;
                        y1 = k - 1;
                    }
                }
            }
            return isMoved;
        }
        private bool upMove()
        {
            bool isMoved = false;
            for (int i = 0; i < board.GetLength(1); i++)
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[j, i] != 0)
                    {
                        if (value1 < 0)
                        {
                            int k;
                            for (k = j - 1; k > -1; k--)
                            {
                                if (board[k, i] > 0)
                                    break;
                            }
                            board[k + 1, i] = board[j, i];
                            if (k + 1 != j)
                            {
                                board[j, i] = 0;
                                isMoved = true;
                            }
                            value1 = board[k + 1, i];
                            x1 = k + 1;
                            y1 = i;
                        }
                        else
                        {
                            if (board[j, i] == value1)//合并
                            {
                                board[x1, y1] = board[x1, y1] * 2;
                                board[j, i] = 0;
                                value1 = -1;
                                score += board[x1, y1];
                                isMoved = true;
                                label1.Text = score.ToString();
                            }
                            else
                            {
                                int k;
                                for (k = j - 1; k > -1; k--)
                                {
                                    if (board[k, i] > 0)
                                        break;
                                }
                                board[k + 1, i] = board[j, i];
                                if (k + 1 != j)
                                {
                                    isMoved = true;
                                    board[j, i] = 0;
                                }
                                value1 = board[k + 1, i];
                                x1 = k + 1;
                                y1 = i;
                            }
                        }
                    }
                }

            }
            return isMoved;
        }
        private bool leftMove()
        {
            bool isMoved = false;
            for (int j = 0; j < board.GetLength(0); j++)
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    if (board[j, i] != 0)
                    {
                        if (value1 < 0)
                        {
                            int k;
                            for (k = i - 1; k > -1; k--)
                            {
                                if (board[j, k] > 0)
                                    break;
                            }
                            board[j, k + 1] = board[j, i];
                            if (k + 1 != i)
                            {
                                isMoved = true;
                                board[j, i] = 0;
                            }
                            value1 = board[j, k + 1];
                            x1 = j;
                            y1 = k + 1;
                        }
                        else
                        {
                            if (board[j, i] == value1)//合并
                            {
                                board[x1, y1] = board[x1, y1] * 2;
                                board[j, i] = 0;
                                value1 = -1;
                                score += board[x1, y1];
                                isMoved = true;
                                label1.Text = score.ToString();
                            }
                            else
                            {
                                int k;
                                for (k = i - 1; k > -1; k--)
                                {
                                    if (board[j, k] > 0)
                                        break;
                                }
                                board[j, k + 1] = board[j, i];
                                if (k + 1 != i)
                                {
                                    isMoved = true;
                                    board[j, i] = 0;
                                }
                                value1 = board[j, k + 1];
                                x1 = j;
                                y1 = k + 1;
                            }
                        }
                    }
                }

            }
            return isMoved;
        }
        private bool downMove()
        {
            bool isMoved = false;
            for (int i = 0; i < board.GetLength(1); i++)
            {
                int x1 = -1, y1 = -1, value1 = -1;// x2=-1, y2=-1,value2=-1;
                for (int j = board.GetLength(0) - 1; j > -1; j--)
                {
                    if (board[j, i] != 0)
                    {
                        if (value1 < 0)
                        {
                            int k;
                            for (k = j + 1; k < board.GetLength(0); k++)
                            {
                                if (board[k, i] > 0)
                                    break;
                            }
                            board[k - 1, i] = board[j, i];
                            if (k - 1 != j)
                            {
                                board[j, i] = 0;
                                isMoved = true;
                            }
                            value1 = board[k - 1, i];
                            x1 = k - 1;
                            y1 = i;
                        }
                        else
                        {
                            if (board[j, i] == value1)//合并
                            {
                                board[x1, y1] = board[x1, y1] * 2;
                                board[j, i] = 0;
                                value1 = -1;
                                score += board[x1, y1];
                                isMoved = true;
                                label1.Text = score.ToString();
                            }
                            else
                            {
                                int k;
                                for (k = j + 1; k < board.GetLength(0); k++)
                                {
                                    if (board[k, i] > 0)
                                        break;
                                }
                                board[k - 1, i] = board[j, i];
                                if (k - 1 != j)
                                {
                                    board[j, i] = 0;
                                    isMoved = true;
                                }
                                value1 = board[k - 1, i];
                                x1 = k - 1;
                                y1 = i;
                            }
                        }
                    }
                }

            }
            return isMoved;
        }
        #endregion

        #region 游戏模式选择
        private void 朝代ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 1;
            RefreshUI();
        }
        private void 官品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 2;
            RefreshUI();
        }
        private void 军队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 3;
            RefreshUI();
        }
        private void 数字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameMode = 0;
            RefreshUI();
        }
        #endregion

        #region 鼠标按钮
        Message msg = default(Message);
        private void right_Click(object sender, EventArgs e)
        {
            ProcessCmdKey(ref msg, Keys.Right);
        }

        private void left_Click(object sender, EventArgs e)
        {
            ProcessCmdKey(ref msg, Keys.Left);
        }

        private void up_Click(object sender, EventArgs e)
        {
            ProcessCmdKey(ref msg, Keys.Up);
        }

        private void down_Click(object sender, EventArgs e)
        {
            ProcessCmdKey(ref msg, Keys.Down);
        }
        #endregion

        private bool IsGameOver()
        {
            int nCount = 0; //计算非空的格子的个数
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] > 0) nCount++;
                }
            }
            if (nCount != N * N) return false;

            //如果满了，并且没有可以相邻相同（可合并），则GameOver
            for (int i = 0; i < board.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < board.GetLength(1) - 1; j++)
                {
                    if (board[i, j] == 0) continue;
                    if (board[i, j] == board[i + 1, j] || board[i, j] == board[i, j + 1])
                        return false;
                }
            }
            return true;
        }

        public void showhappy()//破纪录的happy
        {
            PictureBox p = new PictureBox();
            p.Image = Resources.imageAddr1;
            p.Visible = true;
            p.Location = new Point(3, 3);
            p.Size = new Size(260, 260);
            p.SizeMode = PictureBoxSizeMode.CenterImage;
            p.TabIndex = 0;
            p.TabStop = false;

            Label t = new Label();
            t.AutoSize = true;
            t.BackColor = SystemColors.ActiveCaptionText;
            t.Font = new Font("宋体", 20F);
            t.ForeColor = SystemColors.ButtonHighlight;
            t.Location = new Point(71, 227);
            t.Size = new Size(147, 27);
            t.Text = "破纪录了！";

            this.Controls.Add(t);
            this.Controls.Add(p);
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
             Application.Restart();
        }

        public static int GetMax(List<string> arry)//寻找最高分
        {
            foreach (var item in arry)
            {
                if (item != "")
                    max = max > Int32.Parse(item) ? max : Int32.Parse(item);
            }
            return max;
        }

    }

}

