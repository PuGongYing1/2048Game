	1.游戏模式在设置——游戏模式中

	2.运行程序并完成一次游戏过程时，程序会在D盘写入一个txt文件。

		内容是得分和时间。

		程序运行大概顺序为Form1_Load =》StartGame =》InitialUI =》

		GenerateAllButtons =》GetTextOfButton，GetColorOfButton。

	3.用户按键对游戏进行操控，方法为ProcessCmdKey。也可以用鼠标点击，

		事件为right_Click、left_Click、up_Click、down_Click，这些事件都

		会回调ProcessCmdKey方法。
	
	4。点击中间按钮New,游戏重新开始，对应事件为NewGame_Click。

	5.IsGameOver方法对游戏是否结束进行判断，true为游戏结束

	6.ProcessCmdKey中有一个对游戏IsGameOver的判断，如果游戏结束，

		随及在D盘新建文件2048.txt（如果文件不存在的话），之后对文件

		内容进行读取，把分数保存在列表sco中，用方法GetMax找出最大得分。

		之后对最大得分与当前得分进行比较，如果当前得分大于最大分数，则

		调用showhappy方法。之后将当前得分和日期写入2048.txt文件。
