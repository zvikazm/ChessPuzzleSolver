using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class King:Piece
    {
        public King()
        {
        }

        public King(Square location, Position.Players color, Move lastMove)
        {
            _square = location;
            _color = color;
            _lastMove = lastMove;
        }

        public King(Square location, Position.Players color)
        {
            _square = location;
            _color = color;
        }

        public King(Piece piece)
        {
            this._color = piece._color;
            this._square = new Square(piece._square);
            this._lastMove = new Move(piece._lastMove);
        }

        public override List<Square> calcPossibleMoves(Position pos)
        {
            List<Square> possMoves = new List<Square>();
            List<Piece> selfPieces;
            List<Square> selfSquares = new List<Square>();
            if (_color.Equals(Position.Players.White))
            {
                selfPieces =  pos.mWhitePieces;                
            }
            else//self color is black
            {
                selfPieces =  pos.mBlackPieces;
            }
          
            foreach (Piece p in selfPieces)
            {
                selfSquares.Add(p._square);
            }

            int file = _square._file;
            int rank = _square._rank;
            for (int i = file - 1; i < file + 2; i++)
            {
                for (int j = rank - 1; j < rank + 2; j++)
                {
                    if (i == file && j == rank)
                        continue;
                    if (i < 1 || i > 8 || j < 1 || j > 8)
                        continue;
                    Square sq = new Square(i, j);
                    if (selfSquares.Contains(sq))
                        continue;
                    possMoves.Add(sq);
                }
            }
            return possMoves;
        }
        //public override List<Square> calcPossibleMoves(List<Piece> whitePieces, List<Piece> blackPieces)
        //{
        //    List<Piece> selfPieces;
        //    List<Piece> opponentPieces;
        //    if (_color.Equals(Position.Players.White))
        //    {
        //        selfPieces = whitePieces;
        //        opponentPieces = blackPieces;
        //    }
        //    else//self color is black
        //    {
        //        selfPieces = blackPieces;
        //        opponentPieces = whitePieces;
        //    }

        //    List<Square> selfSquares = new List<Square>();
        //    List<Square> opponentSquares = new List<Square>();
        //    foreach (Piece p in selfPieces)
        //    {
        //        selfSquares.Add(p._square);
        //    }
        //    foreach (Piece p in opponentPieces)
        //    {
        //        opponentSquares.Add(p._square);
        //    }
        //    Square oldSquare = new Square(_square);
        //    List<Square> possMoves = new List<Square>();
        //    int file = _square._file;
        //    int rank = _square._rank;
        //    for (int i = file - 1; i < file + 2; i++)
        //    {
        //        for (int j = rank - 1; j < rank + 2; j++)
        //        {
        //            if (i == file && j == rank)
        //                continue;
        //            if (i < 1 || i > 8 || j < 1 || j > 8)
        //                continue;
        //            Square sq = new Square(i, j);
        //            if (selfSquares.Contains(sq))
        //                continue;

        //            _square = sq;
        //            bool isSqPoss = true;
        //            foreach (Piece p in opponentPieces)
        //            {
        //                if (!p._square.Equals(sq) && !(p is King))
        //                {
        //                    List<Square> oppPossMoves = p.calcPossibleMoves(whitePieces, blackPieces);
        //                    if (oppPossMoves.Contains(sq))
        //                    {
        //                        isSqPoss = false;
        //                        break;
        //                    }
        //                }
        //                if (p is King)
        //                {
        //                    int kingFile = p._square._file;
        //                    int kingRank = p._square._rank;
        //                    for (int f = kingFile - 1; f < kingFile + 2; f++)
        //                    {
        //                        for (int r = kingRank - 1; r < kingRank + 2; r++)
        //                        {
        //                            if (f == kingFile && r == kingRank)
        //                                continue;
        //                            if (f < 1 || f > 8 || r < 1 || r > 8)
        //                                continue;
        //                            Square kingSq = new Square(f, r);
        //                            if (opponentSquares.Contains(kingSq))
        //                                continue;
        //                            if (sq.Equals(kingSq))
        //                                isSqPoss = false;
        //                        }
        //                    }
        //                }
        //            }
        //            if (isSqPoss)
        //                possMoves.Add(sq);
        //        }
        //    }
        //    _square = oldSquare;
        //    return possMoves;
        //}


        /*
        public override List<Square> calcPossibleMoves(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            List<Square> possMoves = new List<Square>();
            List<Square> threatSquares = new List<Square>();
            if (_color == "white")
            {
                foreach (Piece p in blackPieces)
                {
                    threatSquares.AddRange(p.calcPossibleMoves(whitePieces, blackPieces));   
                }
            }
            else//color is black
            {
                foreach (Piece p in whitePieces)
                {
                    if (!(p is King))
                        threatSquares.AddRange(p.calcPossibleMoves(whitePieces, blackPieces));
                    else//p is king
                    {
                        int kingFile = p._square._file;
                        int kingRank = p._square._rank;
                        for (int i = kingFile - 1; i < kingFile + 2; i++)
                        {
                            for (int j = kingRank - 1; j < kingRank + 2; j++)
                            {
                                if (i == kingFile && j == kingRank)
                                    continue;
                                if (i < 1 || i > 8 || j < 1 || j > 8)
                                    continue;
                                Square sq = new Square(i, j);
                                threatSquares.Add(sq);
                            }
                        }
                    }
                }
            }
            int file = _square._file;
            int rank = _square._rank;
            for (int i = file - 1; i < file + 2; i++)
            {
                for (int j = rank - 1; j < rank + 2; j++)
                {
                    if (i == file && j == rank)
                        continue;
                    if (i < 1 || i > 8 || j < 1 || j > 8)
                        continue;
                    Square sq = new Square(i, j);
                    if(!threatSquares.Contains(sq))
                        possMoves.Add(sq);
                }
            }
            return possMoves;
        }*/
    }
}
