using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

using System.Threading;
using System.IO;

namespace ChessPuzzleSolver
{
    public partial class MainForm : Form
    {
        Solver mSol;
        string mTxtLog;
        Thread workerThread;
        public bool stopFlag = false;
        public const int SQUARE_WIDTH = 70;
        public const int SQUARE_HEIGHT = 70;
        public const int LABEL_HEIGHT = 20;
        public const int LABEL_WIDTH = 15;
        public const int LABEL_OFFSET = 4;
        public const int BORDER_OFFSET = 40;
        public const int NUM_RANKS = 8;
        public const int NUM_FILES = 8;
        
        public Color BLACK_SQUARE_COLOR = Color.Gray;
        public Color WHITE_SQUARE_COLOR = Color.Beige;
        public Color POSS_MOVES_COLOR = Color.Aqua;

        private Panel[,] _grid;
        private Panel _sourceDrag;
        //private List<Piece> _whitePieces;
        //private List<Piece> _blackPieces;
        public MainForm()
        {
            InitializeComponent();
            createEmptyBoard();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void createEmptyBoard()
        {
            addTagsToSidePanels();
            int xSpot;
            int ySpot;
            _grid = new Panel[8, 8];
            for (int row = 0; row < NUM_RANKS; row++)
            {
                Label rankLabel = new Label();
                rankLabel.Width = LABEL_WIDTH;
                rankLabel.Height = LABEL_HEIGHT;
                rankLabel.Font = new Font("david", 15);
                int posLabelX = LABEL_OFFSET;
                int posLabelY = (row * SQUARE_HEIGHT) + (int)(BORDER_OFFSET * 2.2);
                rankLabel.Location = new Point(posLabelX,posLabelY);
                rankLabel.Text = (NUM_RANKS-row).ToString();
                panelMain.Controls.Add(rankLabel);
                


                for (int col = 0; col < NUM_FILES; col++)
                {
                    if (row == NUM_RANKS - 1)//add files labels
                    {
                        Label fileLabel = new Label();
                        fileLabel.Width = LABEL_WIDTH;
                        fileLabel.Height = LABEL_HEIGHT;
                        fileLabel.Font = new Font("david", 15);
                        int posLabelFileX = (col * SQUARE_WIDTH) + (int)(BORDER_OFFSET * 2.2);
                        int posLabelFileY = SQUARE_HEIGHT * NUM_RANKS+BORDER_OFFSET;
                        fileLabel.Location = new Point(posLabelFileX, posLabelFileY);
                        fileLabel.Text = Square.int2Char(col+1).ToString();
                        panelMain.Controls.Add(fileLabel);
                    }
                    // Create the tile
                    _grid[row, col] = new Panel();
                    if (Math.IEEERemainder((row + col), 2) == 0)
                        _grid[row, col].BackColor = WHITE_SQUARE_COLOR;
                    else
                        _grid[row, col].BackColor = BLACK_SQUARE_COLOR;
                    Square square = new Square(col+1, NUM_RANKS - row);
                    
                   /*TextBox t = new TextBox();
                    t.Text = square.ToString();
                    t.Height = 30;
                    t.Width = 30;
                    _grid[row, col].Controls.Add(t);
                    */
                    _grid[row, col].BorderStyle = BorderStyle.FixedSingle;
                    _grid[row, col].Width = 70;
                    _grid[row, col].Height = 70;
                    _grid[row, col].AllowDrop = true;
                    _grid[row, col].Tag = new PanelTag(square,null);
                    _grid[row, col].BackgroundImageLayout = ImageLayout.Center;
                    _grid[row, col].DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);
                    _grid[row, col].MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
                    _grid[row, col].DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
                    //_grid[row, col].MouseClick += new MouseEventHandler(MainForm_MouseClick);
                    _grid[row, col].Click += new EventHandler(MainForm_Click);
                    
                    //_grid[row, col].MouseEnter += new EventHandler(panel_MouseEnter);
                    //_grid[row, col].MouseLeave += new EventHandler(panel_MouseLeave);
                    //Label l = new Label();
                    //l.Text = square.ToString();
                    
                    //_grid[row, col].Controls.Add(l);
                    // Set the location for the tile
                    xSpot = (col * SQUARE_WIDTH + BORDER_OFFSET);
                    ySpot = (row * SQUARE_HEIGHT + BORDER_OFFSET);
                    _grid[row, col].Location = new Point(xSpot, ySpot);

                    // Add the tile to the form
                    panelMain.Controls.Add(_grid[row, col]);
                }
            }
            panelMain.DragDrop +=new DragEventHandler(panel_DragDrop);
        }

        void MainForm_Click(object sender, EventArgs e)
        {
            MouseEventArgs er = (MouseEventArgs)e;
            if (er.Button == MouseButtons.Right)
            {
                MenuItem deletePiece = new MenuItem("delete...");
                deletePiece.Click += new EventHandler(deletePiece_Click);
                MenuItem[] mia = { deletePiece };
                //mia[0]=mi;
                ContextMenu cm = new ContextMenu(mia);
                Panel p = (Panel)sender;
                p.ContextMenu = cm;
                cm.Show(p, new Point(er.X, er.Y));

            }
        }

        void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MenuItem deletePiece = new MenuItem("delete...");
                deletePiece.Click += new EventHandler(deletePiece_Click);
                MenuItem[] mia = { deletePiece };
                //mia[0]=mi;
                ContextMenu cm = new ContextMenu(mia);
                Panel p = (Panel)sender;
                p.ContextMenu = cm;
                cm.Show(p, new Point(e.X,e.Y));
                
            }
        }

        void deletePiece_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            ContextMenu cm= mi.GetContextMenu();
            Panel p = (Panel)cm.SourceControl;
            if (((PanelTag)p.Tag)._piece != null)
            {
                ((PanelTag)p.Tag)._piece = null;
            }
            if (p.BackgroundImage != null)
            {
                p.BackgroundImage = null;
                ((PanelTag)p.Tag)._piece = null;

            }
        }

        private void addTagsToSidePanels()
        {
            //TODO add capabilty to remove pieces from the board by dragging them out
            panelMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            panelMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);

            PanelTag kingWhiteTag = new PanelTag(null, new King(null,Position.Players.White));
            PanelTag kingBlackTag = new PanelTag(null, new King(null, Position.Players.Black));
            PanelTag queenWhiteTag = new PanelTag(null, new Queen(null, Position.Players.White));
            PanelTag queenBlackTag = new PanelTag(null, new Queen(null, Position.Players.Black));
            PanelTag rookWhiteTag = new PanelTag(null, new Rook(null, Position.Players.White));
            PanelTag rookBlackTag = new PanelTag(null, new Rook(null, Position.Players.Black));
            PanelTag bishopWhiteTag = new PanelTag(null, new Bishop(null, Position.Players.White));
            PanelTag bishopBlackTag = new PanelTag(null, new Bishop(null, Position.Players.Black));
            PanelTag knightWhiteTag = new PanelTag(null, new Knight(null, Position.Players.White));
            PanelTag knightBlackTag = new PanelTag(null, new Knight(null, Position.Players.Black));
            PanelTag pawnWhiteTag = new PanelTag(null, new Pawn(null, Position.Players.White, null));
            PanelTag pawnBlackTag = new PanelTag(null, new Pawn(null, Position.Players.Black,null));
            PanelTag panelMainTag = new PanelTag(null, new Pawn(null, Position.Players.Black, null));

            whiteKing.Tag = kingWhiteTag;
            blackKing.Tag = kingBlackTag;
            whiteQueen.Tag = queenWhiteTag;
            blackQueen.Tag = queenBlackTag;
            whiteRook.Tag = rookWhiteTag;
            blackRook.Tag = rookBlackTag;
            whiteBishop.Tag = bishopWhiteTag;
            blackBishop.Tag = bishopBlackTag;
            whiteKnight.Tag = knightWhiteTag;
            blackKnight.Tag = knightBlackTag;
            whitePawn.Tag = pawnWhiteTag;
            blackPawn.Tag = pawnBlackTag;
            panelMain.Tag = panelMainTag;
            //string s = @"C:\Users\zvika\Documents\Visual Studio 2008\Projects\ChessPuzzleSolver\ChessPuzzleSolver\";
            //blackPawn.BackgroundImage = new Bitmap(s+"bishopWhite.png");
            
        }

        
        
        

        
        private void debug(string str)
        {
           richTextBox1.Text += str+"\r\n";
        }
        /*void panel_MouseEnter(object sender, EventArgs e)
        {
            debug("mouse enter");
            Panel panel = (Panel)sender;
            Piece piece = ((PanelTag)panel.Tag)._piece;
            if (piece == null)
                return;
            List<Square> possMoves = piece.calcPossibleMoves(_whitePieces, _blackPieces);
            for (int i = 0; i < NUM_RANKS; i++)
            {
                for (int j = 0; j < NUM_FILES; j++)
                {
                    Square s = ((PanelTag)_grid[i, j].Tag)._square;
                    if (possMoves.Contains(s))
                        _grid[i, j].BackColor = POSS_MOVES_COLOR;
                }
            }
        }*/

        /*void panel_MouseLeave(object sender, EventArgs e)
        {
            debug("mouse leave");
            for (int i = 0; i < NUM_RANKS; i++)
            {
                for (int j = 0; j < NUM_FILES; j++)
                {
                    if (_grid[i, j].BackColor == POSS_MOVES_COLOR)
                    {
                        if (Math.IEEERemainder((i + j), 2) == 0)
                            _grid[i, j].BackColor = BLACK;
                        else
                            _grid[i, j].BackColor = WHITE;
                    }    
                }
            }
        }*/

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            //debug("mouse down");
            //we will pass the data that user wants to drag
            //DoDragDrop method is used for holding data
            //DoDragDrop accepts two paramete first paramter 
            //is data(image,file,text etc) and second paramter 
            //specify either user wants to copy the data or move data
            _sourceDrag = (Panel)sender;
            Panel source = (Panel)sender;
            Image im = source.BackgroundImage;
            DragDropEffects effect;
            if (im != null)
            {
                effect = DoDragDrop(im,
                           DragDropEffects.Copy);
                if (effect != DragDropEffects.None && ((PanelTag)source.Tag)._square != null)
                {                    
                    RemoveImage(sender);
                    ((PanelTag)source.Tag)._piece = null;
                }
            }
        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            //TODO change behavior when sender is panelMain
            //debug("drag enter");
            Panel p = (Panel)sender;
            //to disable capture, uncomment these 2 lines
            //if (((PanelTag)p.Tag)._piece != null)
            //    return;

            //this is the same square
            if (sender.Equals(_sourceDrag))
                return;
            //((PanelTag)p.Tag)._piece = ((PanelTag)_sourceDrag.Tag)._piece;
            //((PanelTag)p.Tag)._piece._square = ((PanelTag)p.Tag)._square;
            //_sourceDrag = null;
            // As we are interested in Image data only
            // we will check this as follows
            if (e.Data.GetDataPresent(typeof(Bitmap)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            if (sender.Equals(panelMain))
            {             
                return;
            }
            //debug("drag drop");
            //target control will accept data here 
            Panel destination = (Panel)sender;
            //destination.MouseClick += new MouseEventHandler(MainForm_MouseClick);
            destination.BackgroundImage = (Bitmap)e.Data.GetData(typeof(Bitmap));
            PanelTag pt = (PanelTag)_sourceDrag.Tag;
            ((PanelTag)destination.Tag)._piece = (Piece)pt._piece.Clone();
            _sourceDrag = null;
            ((PanelTag)destination.Tag)._piece._square = ((PanelTag)destination.Tag)._square;
            //debug(((PanelTag)destination.Tag)._piece.ToString());
        }

        private void RemoveImage(Object sender)
        {
            Panel p = (Panel)sender;
            //Square s = ((PanelTag)p.Tag)._square;
            //int rank = s._rank;
            //int file = s._file;
            /*if (Math.IEEERemainder((rank + file), 2) == 0)
            {
                p.BackColor = WHITE;
            }
            else
                p.BackColor = BLACK;*/
            p.BackgroundImage = null;
            ((PanelTag)p.Tag)._piece = null;
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            int moveToMate = 1; 
            int logLevel = 0;
            try
            {
                moveToMate = int.Parse(textBoxMaxDepth.Text);
                logLevel = int.Parse(textBoxLogLevel.Text);
            }
            catch (Exception exc) { }
            Position initPos = readPostionFromBoard();
            mSol = new Solver(initPos, moveToMate, Log, logLevel);
            workerThread = new Thread(mSol.SolveFunc);
            workerThread.Start();
            while (!workerThread.IsAlive) ;                    
        }              

        private Position readPostionFromBoard()
        {
            Position pos = new Position();
            for (int row = 0; row < NUM_RANKS; row++)
            {
                for (int col = 0; col < NUM_FILES; col++)
                {
                    Piece p = ((PanelTag)_grid[row, col].Tag)._piece;
                    if (p != null)
                    {
                        if (p._color.Equals(Position.Players.White))
                            pos.mWhitePieces.Add(p);
                        else
                            pos.mBlackPieces.Add(p);
                    }
                }
            }
            pos.mTurn = whiteTurn.Checked ? Position.Players.White : Position.Players.Black;

            if (textBoxSrc.Text != null && textBoxSrc.Text.Length == 2 &&
                textBoxDst.Text != null && textBoxDst.Text.Length == 2)
            {
                char[] src = textBoxSrc.Text.ToCharArray();
                Square srcSq = new Square(src[0], int.Parse(src[1].ToString()));

                char[] dst = textBoxDst.Text.ToCharArray();
                Square dstSq = new Square(dst[0], int.Parse(dst[1].ToString()));
                Piece p = pos.getPieceBySquare(dstSq);
                if (p != null && p._color != pos.mTurn)
                {
                    pos.mLastMovePiece = p;
                    p._lastMove = new Move(srcSq, dstSq);
                }

            }
            return pos;
        }

        private void buttonIsCheckmate_Click(object sender, EventArgs e)
        {
            Position pos = readPostionFromBoard();
            richTextBox1.Text += pos.isCheckMate().ToString()+"\n";
        }

        private void buttonIsCheck_Click(object sender, EventArgs e)
        {
            Position pos = readPostionFromBoard();
            Piece p  = pos.isCheck();
            if (p != null)
            {
                richTextBox1.Text += p.ToString() +"\n";
            }
            else
            {
                richTextBox1.Text += "no check\n";
            }
        }

        private void buttonPrintPosition_Click(object sender, EventArgs e)
        {
            Position pos = readPostionFromBoard();
            richTextBox1.Text += pos.ToString();
        }

        private void buttonClearTextBox_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void buttonClearBoard_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }

        private void ClearBoard()
        {
            for (int row = 0; row < NUM_RANKS; row++)
            {
                for (int col = 0; col < NUM_FILES; col++)
                {
                    if (((PanelTag)_grid[row, col].Tag)._piece != null)
                    {
                        ((PanelTag)_grid[row, col].Tag)._piece = null;
                    }
                    if (_grid[row, col].BackgroundImage != null)
                    {
                        _grid[row, col].BackgroundImage = null;
                        ((PanelTag)_grid[row, col].Tag)._piece = null;

                    }
                }
            }
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog spf = new SaveFileDialog();
            spf.Filter = "Text files (*.txt)|*.txt";
            if (spf.ShowDialog() == DialogResult.OK)
            {
                Position pos = readPostionFromBoard();
                ChessUtils ut = new ChessUtils();
                ut.WritePositionToFile(spf.FileName, pos);                
            }
            else
            {
                return;
            }                      
        }

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            String fileName;
            opf.Filter = "Fen files (*.fen)| *.fen; | All files (*.*)|*.*";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                fileName = opf.FileName;
            }
            else
                return;
            ChessUtils ut = new ChessUtils();
            Position pos;
            if (fileName.EndsWith("txt"))
                pos = ut.ReadPositionFromFile(opf.FileName);
            else if (fileName.EndsWith("fen"))
                pos = ut.ReadPositionFromFenFile(opf.FileName);
            else
                return;
            ClearBoard();
            FillBoard(pos);
        }

        private void FillBoard(Position pos)
        {
            foreach (Piece p in pos.mWhitePieces)
            {
                int file = p._square._file;
                int rank = p._square._rank;
                PanelTag pt = new PanelTag();
                pt._piece = (Piece)p.Clone();
                pt._square = p._square;
                _grid[NUM_RANKS-rank,file-1].Tag = pt;
                
                if (p is King)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.kingWhite;
                else if (p is Queen)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.queenWhite;
                else if (p is Rook)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.rookWhite;
                else if (p is Bishop)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.bishopWhite;
                else if (p is Knight)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.knightWhite;
                else if (p is Pawn)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.pawnWhite;


            }
            foreach (Piece p in pos.mBlackPieces)
            {
                int file = p._square._file;
                int rank = p._square._rank;
                PanelTag pt = new PanelTag();
                pt._piece = (Piece)p.Clone();
                pt._square = p._square;
                _grid[NUM_RANKS - rank, file - 1].Tag = pt;

                if (p is King)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.kingBlack;
                else if (p is Queen)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.queenBlack;
                else if (p is Rook)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.rookBlack;
                else if (p is Bishop)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.bishopBlack;
                else if (p is Knight)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.knightBlack;
                else if (p is Pawn)
                    _grid[NUM_RANKS - rank, file - 1].BackgroundImage = global::ChessPuzzleSolver.Properties.Resources.pawnBlack;
            }

            if (pos.mTurn == Position.Players.White)
            {
                whiteTurn.Checked = true;
            }
            else
            {
                blackTurn.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Position initPos = readPostionFromBoard();
            if (textBoxSrcNext.Text == null ||
                textBoxSrcNext.Text.Length != 2 ||
                textBoxDstNext.Text == null ||
                textBoxDstNext.Text.Length != 2)
                return;
            char[] src = textBoxSrcNext.Text.ToCharArray();            
            Square srcSq = new Square(src[0],int.Parse(src[1].ToString()));

            char[] dst = textBoxDstNext.Text.ToCharArray();
            Square dstSq = new Square(dst[0], int.Parse(dst[1].ToString()));

            List<Position> newPos = initPos.GetNextPositionsByMove(new Move(srcSq, dstSq));
            if (newPos == null)
            {
                richTextBox2.Text += "not legal move";
                return;
            }
            richTextBox2.Text += "init:\n";
            richTextBox2.Text += initPos.ToString() + "\n";
            richTextBox2.Text += "move: " + "\n";
            richTextBox2.Text += "after:\n";
            int i = 0;
            foreach(Position pos in newPos)
            {
                if (pos != null)
                {
                    richTextBox2.Text += "pos " + i + " \n";
                    richTextBox2.Text += pos.ToString() + "\n";
                    i++;
                }
            }
            //System.IO.File.WriteAllText("zvika.txt", line);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Position initPos = readPostionFromBoard();
            if (calcPossSrc.Text == null ||
                calcPossSrc.Text.Length != 2)
            {
                richTextBox2.Text += "please insert source square\n";
                return;
            }
            char[] src = calcPossSrc.Text.ToCharArray();
            Square srcSq = new Square(src[0], int.Parse(src[1].ToString()));
            Piece p = initPos.getPieceBySquare(srcSq);
            if (p == null || p._color != initPos.mTurn)
            {
                richTextBox2.Text += "no piece in src square or wrong color\n";
                return;
            }
            List<Square> ls = p.calcPossibleMoves(initPos);
            foreach (Square s in ls)
                richTextBox2.Text += s.ToString()+"\n";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length+1;
            richTextBox1.ScrollToCaret();
        }        

        public bool Log(String text)
        {            
            this.Invoke((MethodInvoker)delegate
            {
                richTextBox2.Text += text;
            });
            return true;
        }

        public bool LogToFile(String text)
        {
            mTxtLog += text;
            return true;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.SelectionStart = richTextBox2.Text.Length + 1;
            richTextBox2.ScrollToCaret();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            mSol.Stop();
            //workerThread.Join();
        }

        private void saveAsFenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog spf = new SaveFileDialog();
            spf.Filter = "Fen files (*.fen)|*.fen";
            if (spf.ShowDialog() == DialogResult.OK)
            {
                Position pos = readPostionFromBoard();
                ChessUtils ut = new ChessUtils();
                ut.WritePositionToFenFile(spf.FileName, pos);
            }
            else
            {
                return;
            }  
        }

        private void loadGamePGNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            String fileName;
            opf.Filter = "Pgn files (*.pgn)| *.pgn; | All files (*.*)|*.*";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                fileName = opf.FileName;
            }
            else
                return;
            ChessUtils ut = new ChessUtils();
            Game game = ut.ReadGameFromPgnFile(fileName);
        }
    }
}
