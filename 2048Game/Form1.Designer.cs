namespace _2048Game
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mode = new System.Windows.Forms.ToolStripMenuItem();
            this.数字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.朝代ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.官品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.军队ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.up = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.NewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(12, 28);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(260, 260);
            this.pnlBoard.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏模式ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏模式ToolStripMenuItem
            // 
            this.游戏模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mode});
            this.游戏模式ToolStripMenuItem.Name = "游戏模式ToolStripMenuItem";
            this.游戏模式ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.游戏模式ToolStripMenuItem.Text = "设置";
            // 
            // mode
            // 
            this.mode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数字ToolStripMenuItem,
            this.朝代ToolStripMenuItem,
            this.官品ToolStripMenuItem,
            this.军队ToolStripMenuItem});
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(124, 22);
            this.mode.Text = "游戏模式";
            // 
            // 数字ToolStripMenuItem
            // 
            this.数字ToolStripMenuItem.Name = "数字ToolStripMenuItem";
            this.数字ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.数字ToolStripMenuItem.Text = "数字";
            this.数字ToolStripMenuItem.Click += new System.EventHandler(this.数字ToolStripMenuItem_Click);
            // 
            // 朝代ToolStripMenuItem
            // 
            this.朝代ToolStripMenuItem.Name = "朝代ToolStripMenuItem";
            this.朝代ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.朝代ToolStripMenuItem.Text = "朝代";
            this.朝代ToolStripMenuItem.Click += new System.EventHandler(this.朝代ToolStripMenuItem_Click);
            // 
            // 官品ToolStripMenuItem
            // 
            this.官品ToolStripMenuItem.Name = "官品ToolStripMenuItem";
            this.官品ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.官品ToolStripMenuItem.Text = "官品";
            this.官品ToolStripMenuItem.Click += new System.EventHandler(this.官品ToolStripMenuItem_Click);
            // 
            // 军队ToolStripMenuItem
            // 
            this.军队ToolStripMenuItem.Name = "军队ToolStripMenuItem";
            this.军队ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.军队ToolStripMenuItem.Text = "军队";
            this.军队ToolStripMenuItem.Click += new System.EventHandler(this.军队ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.提示ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 提示ToolStripMenuItem
            // 
            this.提示ToolStripMenuItem.Name = "提示ToolStripMenuItem";
            this.提示ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.提示ToolStripMenuItem.Text = "提示";
            // 
            // up
            // 
            this.up.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.up.Location = new System.Drawing.Point(338, 124);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(50, 50);
            this.up.TabIndex = 2;
            this.up.Text = "Up";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // left
            // 
            this.left.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.left.Location = new System.Drawing.Point(291, 170);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(50, 50);
            this.left.TabIndex = 3;
            this.left.Text = "Left";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.right.Location = new System.Drawing.Point(385, 170);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(50, 50);
            this.right.TabIndex = 4;
            this.right.Text = "Right";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // down
            // 
            this.down.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.down.Location = new System.Drawing.Point(338, 215);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(50, 50);
            this.down.TabIndex = 5;
            this.down.Text = "Down";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // NewGame
            // 
            this.NewGame.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F);
            this.NewGame.Location = new System.Drawing.Point(338, 170);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(50, 50);
            this.NewGame.TabIndex = 6;
            this.NewGame.Text = "New";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 25F);
            this.label1.Location = new System.Drawing.Point(345, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(286, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Score: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.down);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.up);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mode;
        private System.Windows.Forms.ToolStripMenuItem 朝代ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 官品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 军队ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数字ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 提示ToolStripMenuItem;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

