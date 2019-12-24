using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ChessPuzzleSolver
{
    public class ChessUtils
    {
        public ChessUtils()
        {
        }

        public Piece parseFenPiecePlacement(char piecePlacement, out int blankSquares)
        {
            Piece retPiece = null;
            blankSquares = 1;
            switch (piecePlacement)
            {
                case 'p':
                    retPiece = new Pawn(null, Position.Players.Black, null);                    
                    break;
                case 'n':
                    retPiece = new Knight(null, Position.Players.Black, null);
                    break;
                case 'b':
                    retPiece = new Bishop(null, Position.Players.Black, null);
                    break;
                case 'r':
                    retPiece = new Rook(null, Position.Players.Black, null);
                    break;
                case 'q':
                    retPiece = new Queen(null, Position.Players.Black, null);
                    break;
                case 'k':
                    retPiece = new King(null, Position.Players.Black, null);
                    break;
                case 'P':
                    retPiece = new Pawn(null, Position.Players.White, null);
                    break;
                case 'N':
                    retPiece = new Knight(null, Position.Players.White, null);
                    break;
                case 'B':
                    retPiece = new Bishop(null, Position.Players.White, null);
                    break;
                case 'R':
                    retPiece = new Rook(null, Position.Players.White, null);
                    break;
                case 'Q':
                    retPiece = new Queen(null, Position.Players.White, null);
                    break;
                case 'K':
                    retPiece = new King(null, Position.Players.White, null);
                    break;
                case '/':
                    blankSquares = 9;
                    break;
                case '1':
                    blankSquares = 1;
                    break;
                case '2':
                    blankSquares = 2;
                    break;
                case '3':
                    blankSquares = 3;
                    break;
                case '4':
                    blankSquares = 4;
                    break;
                case '5':
                    blankSquares = 5;
                    break;
                case '6':
                    blankSquares = 6;
                    break;
                case '7':
                    blankSquares = 7;
                    break;
                case '8':
                    blankSquares = 8;
                    break;
            }
            return retPiece;
        }

        public Position FenStringToPosition(string fenStr)
        {
            List<Piece> whitePieces = new List<Piece>();
            List<Piece> blackPieces = new List<Piece>();
            Position.Players colTurn;
            string[] fenFields = fenStr.Split(' ');
            char[] piecePlacement = fenFields[0].ToCharArray();
            int blankSquares = 0;
            int rank = 8;
            int file = 1;
            Piece p;
            for (int i = 0; i < piecePlacement.Length; i++)
            {
                p = parseFenPiecePlacement(piecePlacement[i], out blankSquares);
                if (p != null)
                {
                    p._square = new Square(file, rank);
                    if (p._color == Position.Players.White)
                    {
                        whitePieces.Add(p);
                    }
                    else
                    {
                        blackPieces.Add(p);
                    }
                }
                if (blankSquares < 9)
                    file += blankSquares;
                else
                {
                    file = 1;
                    rank--;
                }
            }

            if (fenFields[1][0] == 'w')
                colTurn = Position.Players.White;
            else
                colTurn = Position.Players.Black;
            
            Position position = new Position(whitePieces, blackPieces, null, colTurn, 0, null);
            return position;
        }

        public Position ReadPositionFromFenFile(string fileName)
        {            
            StreamReader reader;
            try
            {
                reader = File.OpenText(fileName);
            }
            catch (Exception exc) { return null; }

            string inputLine = reader.ReadLine();

            reader.Close();

            return FenStringToPosition(inputLine);
        }

        public string PositionToFenStr(Position pos)
        {
            Piece[,] board = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = null;
                }
            }
            foreach (Piece p in pos.mWhitePieces)
            {
                board[p._square._file - 1, p._square._rank - 1] = p;
            }
            foreach (Piece p in pos.mBlackPieces)
            {
                board[p._square._file - 1, p._square._rank - 1] = p;
            }

            string fen = "";
            int blankSquares = 0;

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[j, i] != null)
                    {
                        if (blankSquares > 0)
                            fen += blankSquares.ToString();
                        fen += PieceToFenChar(board[j, i]).ToString();
                        blankSquares = 0;
                    }
                    else
                    {
                        blankSquares++;
                    }
                }
                if (blankSquares > 0)
                {
                    fen += blankSquares.ToString();
                    blankSquares = 0;
                }
                if (i != 0)
                    fen += "/";
            }
            //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
            fen += " ";
            fen += (pos.mTurn == Position.Players.White) ? "w" : "b";
            fen += " KQkq - 0 1";
            return fen;
        }

        public void WritePositionToFenFile(string fileName, Position pos)
        {
            string fen = PositionToFenStr(pos);
            TextWriter txt;
            txt = new StreamWriter(fileName);
            txt.WriteLine(fen);
            txt.Close();
        }

        private char PieceToFenChar(Piece piece)
        {
            char c = '?';
            if (piece is King)           
                c = 'k';            
            else if (piece is Queen)
                c = 'q';
            else if (piece is Rook)
                c = 'r';
            else if (piece is Bishop)
                c = 'b';
            else if (piece is Knight)
                c = 'n';
            else if (piece is Pawn)
                c = 'p';
                        
            if (piece._color.Equals(Position.Players.White))
                c = Char.ToUpper(c);
            return c;
        }

        public Game ReadGameFromPgnFile(string fileName)
        {
            StreamReader reader;
            try
            {
                reader = File.OpenText(fileName);
            }
            catch (Exception exc) { return null; }

            Game retGame = new Game();
            Move move = null;
            bool halfMove = false;
            string inputLine = null;
            string moves = null;
            while ((inputLine = reader.ReadLine()) != null)
            {
                if (inputLine.StartsWith("["))
                {
                    //format is [tag "some val"]
                    string[] tmp = inputLine.Split(' ');
                    //remvoe the '[' from start
                    string tag = tmp[0].Substring(1, tmp[0].Length - 1);
                    //remove the '"' from start and the '"]' from end
                    int startVal = inputLine.IndexOf("\"");
                    int endVal = inputLine.IndexOf("\"", startVal + 1);
                    string val = inputLine.Substring(startVal + 1, endVal - 1 - startVal);
                    CreateGameTag(retGame, tag, val);
                }
                else if (inputLine.StartsWith(";") || 
                        inputLine.CompareTo("") == 0 || 
                        inputLine.CompareTo(" ") == 0)
                {
                    //this is comment or empty line
                    continue;
                }
                else //moves
                {
                    moves += inputLine + " ";                    
                }
            }
            // concatenate all linees to one long line
            int gameResult = -1;
            retGame.mListMove = ParseMovesPgn(moves, out gameResult);

            return retGame;
        }

        public List<FullMove> ParseMovesPgn(string moves, out int gameResult)
        {
            int startToken = 0;
            int endToken = 0;
            List<FullMove> retList = new List<FullMove>();
            List<string> ll = new List<string>();
            string token;
            int moveInd = 0;
            int length = moves.Length - 1;
            bool readMove = true;
            string move = null;
            bool isComment = true;
            FullMove fullMove = new FullMove();
            bool halfMove = false;
            int retGameResult = -1;
            while (endToken < length)
            {                
                isComment = false;
                readMove = true;
                move = null;
                if (moves.Substring(startToken, 1).CompareTo("{") == 0)
                {
                    //we have comment
                    startToken += 1; //skip on the "{"
                    endToken = moves.IndexOf("}", startToken + 1);
                    isComment = true;
                    readMove = false;
                }
                else
                {
                    endToken = moves.IndexOf(" ", startToken + 1);                    
                }
                
                token = moves.Substring(startToken, endToken - startToken);
                //handle multiple " " if exists
                while ((endToken < moves.Length - 1) && (moves.Substring(endToken + 1, 1).CompareTo(" ") == 0))
                {
                    endToken++;                    
                }


                if (token.CompareTo("1-0") == 0 ||
                    token.CompareTo("0-1") == 0 ||
                    token.CompareTo("1/2-1/2") == 0)
                {
                    //handle end of game
                    readMove = false;
                    fullMove.mBlackMove = null;
                    retList.Add((FullMove)fullMove.Clone());
                    if (token.CompareTo("1-0") == 0)
                        retGameResult = 0;
                    else if (token.CompareTo("0-1") == 0)
                        retGameResult = 1;
                    else
                        retGameResult = 2;
                }
                /*need to handle the 2 cases: 
                case A: 1. e4 e5
                case B: 1.e4 e5
                */                
                else if (StartsWithNumber(token))
                {
                    moveInd = Int32.Parse(token.Substring(0, token.IndexOf(".")));
                    fullMove.mNumOfMove = moveInd;
                    //case A
                    if (token.EndsWith("."))
                    {
                        readMove = false;
                    }
                    else // case B
                    {
                        int tmpStart = token.IndexOf(".") + 1;
                        int tmpLength = token.Length - tmpStart;
                        token = token.Substring(tmpStart, tmpLength);
                    }
                }
                
                if (readMove)//read move
                {
/////////////////////////////////////////////////////
#warning need to add to position moves without source

#warning need to parse all kinds of move (+, ++, !, ?, O-O, O-O-O, =, x
/////////////////////////////////////////////////////
                    if (!halfMove)
                    {
                        fullMove.mComment = null;
                        fullMove.mWhiteMove = token;
                        halfMove = true;
                    }
                    else
                    {
                        fullMove.mBlackMove = token;
                        halfMove = false;
                        retList.Add((FullMove)fullMove.Clone());
                    }
                }

                if (isComment)
                {
                    //take into account the " " after the "}"
                    startToken = endToken + 1;
                    fullMove.mComment = token;
                }
                else
                {
                    startToken = endToken + 1;
                }
            }
            gameResult = retGameResult;
            return retList;
        }

        public bool StartsWithNumber(string str)
        {
            for (int i = 1; i < 10; i++)
            {
                if (str.StartsWith(i.ToString()))
                    return true;
            }
            return false;            
        }

        public void CreateGameTag(Game game, string tag, string val)
        {
            if (tag.CompareTo("Event") == 0)
            {
                game.mEvent = val;
            }
            else if (tag.CompareTo("Site") == 0)
            {
                game.mSite = val;
            }
            else if (tag.CompareTo("Date") == 0)
            {
                game.mDate = val;
            }
            else if (tag.CompareTo("Round") == 0)
            {
                game.mRound = val;
            }
            else if (tag.CompareTo("White") == 0)
            {
                game.mWhite = val;
            }
            else if (tag.CompareTo("Black") == 0)
            {
                game.mBlack = val;
            }
            else if (tag.CompareTo("Result") == 0)
            {
                game.mResult = val;
            }
            else if (tag.CompareTo("FEN") == 0)
            {
                game.mStartPos = FenStringToPosition(val);
            }
        }

        public Position ReadPositionFromFile(string fileName)
        {
            List<Piece> whitePieces = new List<Piece>();
            List<Piece> blackPieces = new List<Piece>();
            StreamReader reader;
            try
            {
                reader = File.OpenText(fileName);
            }
            catch (Exception exc) { return null; }

            string inputLine = null;
            inputLine = reader.ReadLine();
            Position.Players colTurn;
            if (inputLine.StartsWith("White"))
                colTurn = Position.Players.White;
            else if (inputLine.StartsWith("Black"))
                colTurn = Position.Players.Black;
            else
                return null;
            while ((inputLine = reader.ReadLine()) != null)
            {
                if (inputLine.StartsWith("{"))
                    continue;
                string[] s = inputLine.Split(' ');
                string pieceKind = s[0];
                string stringColor = s[1];
                Position.Players color;
                if (stringColor.Equals("White"))
                    color = Position.Players.White;
                else
                    color = Position.Players.Black;
                char file = Char.Parse(s[2]);
                int rank = Int32.Parse(s[3]);
                Piece piece = null;
                Square square = new Square(file, rank);
                switch (pieceKind)
                {
                    case "King": piece = new King(square, color); break;
                    case "Queen": piece = new Queen(square, color); break;
                    case "Rook": piece = new Rook(square, color); break;
                    case "Bishop": piece = new Bishop(square, color); break;
                    case "Knight": piece = new Knight(square, color); break;
                    case "Pawn": piece = new Pawn(square, color, null); break;
                }
                if (color.Equals(Position.Players.White))
                    whitePieces.Add(piece);
                else
                    blackPieces.Add(piece);
            }
            reader.Close();
            Position position = new Position(whitePieces, blackPieces, null, colTurn, 0, null);
            return position;
        }

        public void WritePositionToFile(String fileName, Position pos)
        {
            TextWriter txt;
            txt = new StreamWriter(fileName);  

            txt.WriteLine(pos.mTurn.ToString());

            foreach (Piece p in pos.mWhitePieces)
            {
                txt.WriteLine(p.ToString());
            }
            foreach (Piece p in pos.mBlackPieces)
            {
                txt.WriteLine(p.ToString());
            }
            txt.Close();
        }
    }

}
