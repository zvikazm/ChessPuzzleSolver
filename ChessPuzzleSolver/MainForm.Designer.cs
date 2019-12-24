namespace ChessPuzzleSolver
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonIsCheckmate = new System.Windows.Forms.Button();
            this.buttonIsCheck = new System.Windows.Forms.Button();
            this.whitePawn = new System.Windows.Forms.Panel();
            this.blackPawn = new System.Windows.Forms.Panel();
            this.whiteKnight = new System.Windows.Forms.Panel();
            this.blackKnight = new System.Windows.Forms.Panel();
            this.whiteQueen = new System.Windows.Forms.Panel();
            this.blackQueen = new System.Windows.Forms.Panel();
            this.whiteBishop = new System.Windows.Forms.Panel();
            this.blackBishop = new System.Windows.Forms.Panel();
            this.whiteRook = new System.Windows.Forms.Panel();
            this.blackRook = new System.Windows.Forms.Panel();
            this.whiteKing = new System.Windows.Forms.Panel();
            this.blackKing = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonPrintPosition = new System.Windows.Forms.Button();
            this.buttonClearTextBox = new System.Windows.Forms.Button();
            this.buttonClearBoard = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLogLevel = new System.Windows.Forms.TextBox();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.textBoxMaxDepth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDstNext = new System.Windows.Forms.TextBox();
            this.textBoxSrcNext = new System.Windows.Forms.TextBox();
            this.calcPossSrc = new System.Windows.Forms.TextBox();
            this.buttonCalcPoss = new System.Windows.Forms.Button();
            this.blackTurn = new System.Windows.Forms.RadioButton();
            this.whiteTurn = new System.Windows.Forms.RadioButton();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBoxDst = new System.Windows.Forms.TextBox();
            this.textBoxSrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadGamePGNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(670, 498);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(75, 23);
            this.buttonSolve.TabIndex = 1;
            this.buttonSolve.Text = "Solve!";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonIsCheckmate
            // 
            this.buttonIsCheckmate.Location = new System.Drawing.Point(656, 559);
            this.buttonIsCheckmate.Name = "buttonIsCheckmate";
            this.buttonIsCheckmate.Size = new System.Drawing.Size(112, 23);
            this.buttonIsCheckmate.TabIndex = 15;
            this.buttonIsCheckmate.Text = "is checkmate";
            this.buttonIsCheckmate.UseVisualStyleBackColor = true;
            this.buttonIsCheckmate.Click += new System.EventHandler(this.buttonIsCheckmate_Click);
            // 
            // buttonIsCheck
            // 
            this.buttonIsCheck.Location = new System.Drawing.Point(656, 589);
            this.buttonIsCheck.Name = "buttonIsCheck";
            this.buttonIsCheck.Size = new System.Drawing.Size(112, 23);
            this.buttonIsCheck.TabIndex = 16;
            this.buttonIsCheck.Text = "is check";
            this.buttonIsCheck.UseVisualStyleBackColor = true;
            this.buttonIsCheck.Click += new System.EventHandler(this.buttonIsCheck_Click);
            // 
            // whitePawn
            // 
            this.whitePawn.AllowDrop = true;
            this.whitePawn.BackColor = System.Drawing.Color.Gray;
            this.whitePawn.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.pawnWhite;
            this.whitePawn.Location = new System.Drawing.Point(632, 419);
            this.whitePawn.Name = "whitePawn";
            this.whitePawn.Size = new System.Drawing.Size(70, 70);
            this.whitePawn.TabIndex = 11;
            this.whitePawn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.whitePawn.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // blackPawn
            // 
            this.blackPawn.AllowDrop = true;
            this.blackPawn.BackColor = System.Drawing.Color.Gray;
            this.blackPawn.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.pawnBlack;
            this.blackPawn.Location = new System.Drawing.Point(717, 419);
            this.blackPawn.Name = "blackPawn";
            this.blackPawn.Size = new System.Drawing.Size(70, 70);
            this.blackPawn.TabIndex = 5;
            this.blackPawn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.blackPawn.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // whiteKnight
            // 
            this.whiteKnight.AllowDrop = true;
            this.whiteKnight.BackColor = System.Drawing.Color.Gray;
            this.whiteKnight.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.knightWhite;
            this.whiteKnight.Location = new System.Drawing.Point(632, 343);
            this.whiteKnight.Name = "whiteKnight";
            this.whiteKnight.Size = new System.Drawing.Size(70, 70);
            this.whiteKnight.TabIndex = 10;
            this.whiteKnight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.whiteKnight.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // blackKnight
            // 
            this.blackKnight.AllowDrop = true;
            this.blackKnight.BackColor = System.Drawing.Color.Gray;
            this.blackKnight.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.knightBlack;
            this.blackKnight.Location = new System.Drawing.Point(717, 343);
            this.blackKnight.Name = "blackKnight";
            this.blackKnight.Size = new System.Drawing.Size(70, 70);
            this.blackKnight.TabIndex = 4;
            this.blackKnight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.blackKnight.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // whiteQueen
            // 
            this.whiteQueen.AllowDrop = true;
            this.whiteQueen.BackColor = System.Drawing.Color.Gray;
            this.whiteQueen.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.queenWhite;
            this.whiteQueen.Location = new System.Drawing.Point(632, 115);
            this.whiteQueen.Name = "whiteQueen";
            this.whiteQueen.Size = new System.Drawing.Size(70, 70);
            this.whiteQueen.TabIndex = 9;
            this.whiteQueen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.whiteQueen.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // blackQueen
            // 
            this.blackQueen.AllowDrop = true;
            this.blackQueen.BackColor = System.Drawing.Color.Gray;
            this.blackQueen.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.queenBlack;
            this.blackQueen.Location = new System.Drawing.Point(717, 115);
            this.blackQueen.Name = "blackQueen";
            this.blackQueen.Size = new System.Drawing.Size(70, 70);
            this.blackQueen.TabIndex = 3;
            this.blackQueen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.blackQueen.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // whiteBishop
            // 
            this.whiteBishop.AllowDrop = true;
            this.whiteBishop.BackColor = System.Drawing.Color.Gray;
            this.whiteBishop.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.bishopWhite1;
            this.whiteBishop.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.whiteBishop.Location = new System.Drawing.Point(632, 267);
            this.whiteBishop.Name = "whiteBishop";
            this.whiteBishop.Size = new System.Drawing.Size(70, 70);
            this.whiteBishop.TabIndex = 7;
            this.whiteBishop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.whiteBishop.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // blackBishop
            // 
            this.blackBishop.AllowDrop = true;
            this.blackBishop.BackColor = System.Drawing.Color.Gray;
            this.blackBishop.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.bishopBlack;
            this.blackBishop.Location = new System.Drawing.Point(717, 267);
            this.blackBishop.Name = "blackBishop";
            this.blackBishop.Size = new System.Drawing.Size(70, 70);
            this.blackBishop.TabIndex = 3;
            this.blackBishop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.blackBishop.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // whiteRook
            // 
            this.whiteRook.AllowDrop = true;
            this.whiteRook.BackColor = System.Drawing.Color.Gray;
            this.whiteRook.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.rookWhite;
            this.whiteRook.Location = new System.Drawing.Point(632, 191);
            this.whiteRook.Name = "whiteRook";
            this.whiteRook.Size = new System.Drawing.Size(70, 70);
            this.whiteRook.TabIndex = 8;
            this.whiteRook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.whiteRook.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // blackRook
            // 
            this.blackRook.AllowDrop = true;
            this.blackRook.BackColor = System.Drawing.Color.Gray;
            this.blackRook.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.rookBlack;
            this.blackRook.Location = new System.Drawing.Point(717, 191);
            this.blackRook.Name = "blackRook";
            this.blackRook.Size = new System.Drawing.Size(70, 70);
            this.blackRook.TabIndex = 3;
            this.blackRook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.blackRook.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // whiteKing
            // 
            this.whiteKing.AllowDrop = true;
            this.whiteKing.BackColor = System.Drawing.Color.Gray;
            this.whiteKing.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.kingWhite;
            this.whiteKing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.whiteKing.Location = new System.Drawing.Point(632, 39);
            this.whiteKing.Name = "whiteKing";
            this.whiteKing.Size = new System.Drawing.Size(70, 70);
            this.whiteKing.TabIndex = 6;
            this.whiteKing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.whiteKing.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // blackKing
            // 
            this.blackKing.AllowDrop = true;
            this.blackKing.BackColor = System.Drawing.Color.Gray;
            this.blackKing.BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.kingBlack;
            this.blackKing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.blackKing.Location = new System.Drawing.Point(717, 39);
            this.blackKing.Name = "blackKing";
            this.blackKing.Size = new System.Drawing.Size(70, 70);
            this.blackKing.TabIndex = 2;
            this.blackKing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.blackKing.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(11, 638);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(614, 75);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // buttonPrintPosition
            // 
            this.buttonPrintPosition.Location = new System.Drawing.Point(656, 618);
            this.buttonPrintPosition.Name = "buttonPrintPosition";
            this.buttonPrintPosition.Size = new System.Drawing.Size(112, 23);
            this.buttonPrintPosition.TabIndex = 19;
            this.buttonPrintPosition.Text = "print position";
            this.buttonPrintPosition.UseVisualStyleBackColor = true;
            this.buttonPrintPosition.Click += new System.EventHandler(this.buttonPrintPosition_Click);
            // 
            // buttonClearTextBox
            // 
            this.buttonClearTextBox.Location = new System.Drawing.Point(656, 647);
            this.buttonClearTextBox.Name = "buttonClearTextBox";
            this.buttonClearTextBox.Size = new System.Drawing.Size(112, 23);
            this.buttonClearTextBox.TabIndex = 20;
            this.buttonClearTextBox.Text = "clear text";
            this.buttonClearTextBox.UseVisualStyleBackColor = true;
            this.buttonClearTextBox.Click += new System.EventHandler(this.buttonClearTextBox_Click);
            // 
            // buttonClearBoard
            // 
            this.buttonClearBoard.Location = new System.Drawing.Point(656, 676);
            this.buttonClearBoard.Name = "buttonClearBoard";
            this.buttonClearBoard.Size = new System.Drawing.Size(112, 23);
            this.buttonClearBoard.TabIndex = 21;
            this.buttonClearBoard.Text = "clear board";
            this.buttonClearBoard.UseVisualStyleBackColor = true;
            this.buttonClearBoard.Click += new System.EventHandler(this.buttonClearBoard_Click);
            // 
            // panelMain
            // 
            this.panelMain.AllowDrop = true;
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.textBoxLogLevel);
            this.panelMain.Controls.Add(this.ButtonStop);
            this.panelMain.Controls.Add(this.textBoxMaxDepth);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.textBoxDstNext);
            this.panelMain.Controls.Add(this.textBoxSrcNext);
            this.panelMain.Controls.Add(this.calcPossSrc);
            this.panelMain.Controls.Add(this.buttonCalcPoss);
            this.panelMain.Controls.Add(this.blackTurn);
            this.panelMain.Controls.Add(this.whiteTurn);
            this.panelMain.Controls.Add(this.richTextBox2);
            this.panelMain.Controls.Add(this.textBoxDst);
            this.panelMain.Controls.Add(this.textBoxSrc);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Controls.Add(this.whiteKing);
            this.panelMain.Controls.Add(this.buttonClearBoard);
            this.panelMain.Controls.Add(this.blackKing);
            this.panelMain.Controls.Add(this.buttonClearTextBox);
            this.panelMain.Controls.Add(this.whiteQueen);
            this.panelMain.Controls.Add(this.buttonPrintPosition);
            this.panelMain.Controls.Add(this.buttonIsCheck);
            this.panelMain.Controls.Add(this.blackQueen);
            this.panelMain.Controls.Add(this.buttonIsCheckmate);
            this.panelMain.Controls.Add(this.richTextBox1);
            this.panelMain.Controls.Add(this.whiteRook);
            this.panelMain.Controls.Add(this.blackRook);
            this.panelMain.Controls.Add(this.buttonSolve);
            this.panelMain.Controls.Add(this.whiteBishop);
            this.panelMain.Controls.Add(this.blackBishop);
            this.panelMain.Controls.Add(this.whiteKnight);
            this.panelMain.Controls.Add(this.whitePawn);
            this.panelMain.Controls.Add(this.blackKnight);
            this.panelMain.Controls.Add(this.blackPawn);
            this.panelMain.Location = new System.Drawing.Point(1, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1292, 708);
            this.panelMain.TabIndex = 22;
            this.panelMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panelMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(794, 564);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "log level:";
            // 
            // textBoxLogLevel
            // 
            this.textBoxLogLevel.Location = new System.Drawing.Point(856, 562);
            this.textBoxLogLevel.Name = "textBoxLogLevel";
            this.textBoxLogLevel.Size = new System.Drawing.Size(32, 20);
            this.textBoxLogLevel.TabIndex = 39;
            this.textBoxLogLevel.Text = "0";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(890, 599);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 38;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // textBoxMaxDepth
            // 
            this.textBoxMaxDepth.Location = new System.Drawing.Point(856, 599);
            this.textBoxMaxDepth.Name = "textBoxMaxDepth";
            this.textBoxMaxDepth.Size = new System.Drawing.Size(22, 20);
            this.textBoxMaxDepth.TabIndex = 37;
            this.textBoxMaxDepth.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(794, 602);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Mate in:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1121, 564);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "next move:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1121, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "last move:";
            // 
            // textBoxDstNext
            // 
            this.textBoxDstNext.Location = new System.Drawing.Point(1220, 562);
            this.textBoxDstNext.Name = "textBoxDstNext";
            this.textBoxDstNext.Size = new System.Drawing.Size(22, 20);
            this.textBoxDstNext.TabIndex = 33;
            // 
            // textBoxSrcNext
            // 
            this.textBoxSrcNext.Location = new System.Drawing.Point(1186, 561);
            this.textBoxSrcNext.Name = "textBoxSrcNext";
            this.textBoxSrcNext.Size = new System.Drawing.Size(22, 20);
            this.textBoxSrcNext.TabIndex = 32;
            // 
            // calcPossSrc
            // 
            this.calcPossSrc.Location = new System.Drawing.Point(1186, 602);
            this.calcPossSrc.Name = "calcPossSrc";
            this.calcPossSrc.Size = new System.Drawing.Size(22, 20);
            this.calcPossSrc.TabIndex = 31;
            this.calcPossSrc.Text = "e5";
            // 
            // buttonCalcPoss
            // 
            this.buttonCalcPoss.Location = new System.Drawing.Point(1069, 602);
            this.buttonCalcPoss.Name = "buttonCalcPoss";
            this.buttonCalcPoss.Size = new System.Drawing.Size(107, 23);
            this.buttonCalcPoss.TabIndex = 30;
            this.buttonCalcPoss.Text = "calc poss pos";
            this.buttonCalcPoss.UseVisualStyleBackColor = true;
            this.buttonCalcPoss.Click += new System.EventHandler(this.button2_Click);
            // 
            // blackTurn
            // 
            this.blackTurn.AutoSize = true;
            this.blackTurn.Location = new System.Drawing.Point(805, 647);
            this.blackTurn.Name = "blackTurn";
            this.blackTurn.Size = new System.Drawing.Size(73, 17);
            this.blackTurn.TabIndex = 29;
            this.blackTurn.Text = "blackTurn";
            this.blackTurn.UseVisualStyleBackColor = true;
            // 
            // whiteTurn
            // 
            this.whiteTurn.AutoSize = true;
            this.whiteTurn.Checked = true;
            this.whiteTurn.Location = new System.Drawing.Point(805, 621);
            this.whiteTurn.Name = "whiteTurn";
            this.whiteTurn.Size = new System.Drawing.Size(71, 17);
            this.whiteTurn.TabIndex = 28;
            this.whiteTurn.TabStop = true;
            this.whiteTurn.Text = "white turn";
            this.whiteTurn.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(793, 39);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(453, 450);
            this.richTextBox2.TabIndex = 27;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // textBoxDst
            // 
            this.textBoxDst.Location = new System.Drawing.Point(1220, 530);
            this.textBoxDst.Name = "textBoxDst";
            this.textBoxDst.Size = new System.Drawing.Size(22, 20);
            this.textBoxDst.TabIndex = 26;
            // 
            // textBoxSrc
            // 
            this.textBoxSrc.Location = new System.Drawing.Point(1186, 529);
            this.textBoxSrc.Name = "textBoxSrc";
            this.textBoxSrc.Size = new System.Drawing.Size(22, 20);
            this.textBoxSrc.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1217, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "dst";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1187, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "src";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(656, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "printPos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileOpen,
            this.saveAsFenFileToolStripMenuItem,
            this.loadGamePGNToolStripMenuItem});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "File";
            // 
            // MenuFileOpen
            // 
            this.MenuFileOpen.Name = "MenuFileOpen";
            this.MenuFileOpen.Size = new System.Drawing.Size(190, 22);
            this.MenuFileOpen.Text = "Load Position (FEN) ...";
            this.MenuFileOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
            // 
            // saveAsFenFileToolStripMenuItem
            // 
            this.saveAsFenFileToolStripMenuItem.Name = "saveAsFenFileToolStripMenuItem";
            this.saveAsFenFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveAsFenFileToolStripMenuItem.Text = "Save Position (FEN) ...";
            this.saveAsFenFileToolStripMenuItem.Click += new System.EventHandler(this.saveAsFenFileToolStripMenuItem_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuHelp.Text = "Help";
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.MenuHelpAbout.Text = "About";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1259, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadGamePGNToolStripMenuItem
            // 
            this.loadGamePGNToolStripMenuItem.Name = "loadGamePGNToolStripMenuItem";
            this.loadGamePGNToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loadGamePGNToolStripMenuItem.Text = "Load Game (PGN)  ...";
            this.loadGamePGNToolStripMenuItem.Click += new System.EventHandler(this.loadGamePGNToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1259, 712);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChessPuzzleSolver";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Panel blackKing;
        private System.Windows.Forms.Panel blackRook;
        private System.Windows.Forms.Panel blackBishop;
        private System.Windows.Forms.Panel blackQueen;
        private System.Windows.Forms.Panel blackKnight;
        private System.Windows.Forms.Panel blackPawn;
        private System.Windows.Forms.Panel whitePawn;
        private System.Windows.Forms.Panel whiteKnight;
        private System.Windows.Forms.Panel whiteQueen;
        private System.Windows.Forms.Panel whiteBishop;
        private System.Windows.Forms.Panel whiteRook;
        private System.Windows.Forms.Panel whiteKing;
        private System.Windows.Forms.Button buttonIsCheckmate;
        private System.Windows.Forms.Button buttonIsCheck;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonPrintPosition;
        private System.Windows.Forms.Button buttonClearTextBox;
        private System.Windows.Forms.Button buttonClearBoard;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDst;
        private System.Windows.Forms.TextBox textBoxSrc;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RadioButton blackTurn;
        private System.Windows.Forms.RadioButton whiteTurn;
        private System.Windows.Forms.Button buttonCalcPoss;
        private System.Windows.Forms.TextBox calcPossSrc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDstNext;
        private System.Windows.Forms.TextBox textBoxSrcNext;
        private System.Windows.Forms.TextBox textBoxMaxDepth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLogLevel;
        private System.Windows.Forms.ToolStripMenuItem saveAsFenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGamePGNToolStripMenuItem;



    }
}

