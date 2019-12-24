using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class Pawn:Piece
    {
        public Pawn()
        {
            
        }
        /*public Pawn(Square location,string color)
        {
            _square = location;
            _color = color;
        }*/
        public Pawn(Square location, Position.Players color,Move lastMove)
        {
            _square = location;
            _color = color;
            _lastMove = lastMove;
        }

        public Pawn(Piece piece)
        {
            this._color = piece._color;
            this._square = new Square(piece._square);
            this._lastMove = new Move(piece._lastMove);
        }

        public override List<Square> calcPossibleMoves(Position pos)
        {
            List<Square> possMoves = new List<Square>();                   
            List<Square> selfSquares = new List<Square>();
            List<Square> opponentSquares = new List<Square>();
            int direction = 1;
            if (_color.Equals(Position.Players.White))
            {
                foreach (Piece p in pos.mWhitePieces)
                    selfSquares.Add(p._square);
                foreach (Piece p in pos.mBlackPieces)
                    opponentSquares.Add(p._square);
            }
            else//self color is black
            {
                direction = -1;
                foreach (Piece p in pos.mWhitePieces)
                    opponentSquares.Add(p._square);
                foreach (Piece p in pos.mBlackPieces)
                    selfSquares.Add(p._square);
            }
            int file = _square._file;
            int rank = _square._rank;

            //regular move
            Square s = new Square(file, rank + (1*direction));
            if (!selfSquares.Contains(s) && !opponentSquares.Contains(s))
            {
                possMoves.Add(s);
                if ((rank == 2 && _color == Position.Players.White) ||
                    (rank == 7 && _color == Position.Players.Black))//first move
                {
                    s = new Square(file, rank + (2*direction));
                    if (!selfSquares.Contains(s) && !opponentSquares.Contains(s))
                        possMoves.Add(s);
                }
            }
            //capture moves + En passant
            if (file < 8)
            {
                Square s1 = new Square(file + 1, rank + (1 * direction));
                if (opponentSquares.Contains(s1))
                    possMoves.Add(s1);
                if (pos.mLastMovePiece !=  null && pos.mLastMovePiece._lastMove != null && pos.mLastMovePiece is Pawn)
                {
                    if (_square._rank == 5 && pos.mLastMovePiece._lastMove._source._rank == 7 && pos.mLastMovePiece._lastMove._dest._rank == 5 && pos.mLastMovePiece._lastMove._dest._file == file-1 && direction == 1)
                        possMoves.Add(s1);
                    if (_square._rank == 4 && pos.mLastMovePiece._lastMove._source._rank == 2 && pos.mLastMovePiece._lastMove._dest._rank == 4 && pos.mLastMovePiece._lastMove._dest._file == file-1 && direction == -1)
                        possMoves.Add(s1);
                }
            }

            if (file > 1)
            {
                Square s2 = new Square(file - 1, rank + (1 * direction));
                if (opponentSquares.Contains(s2))
                    possMoves.Add(s2);
                if (pos.mLastMovePiece != null && pos.mLastMovePiece._lastMove != null && pos.mLastMovePiece is Pawn)
                {
                    if (_square._rank == 5 && pos.mLastMovePiece._lastMove._source._rank == 7 && pos.mLastMovePiece._lastMove._dest._rank == 5 && pos.mLastMovePiece._lastMove._dest._file == file+1 && direction == 1)
                        possMoves.Add(s2);
                    if (_square._rank == 4 && pos.mLastMovePiece._lastMove._source._rank == 2 && pos.mLastMovePiece._lastMove._dest._rank == 4 && pos.mLastMovePiece._lastMove._dest._file == file+1 && direction == -1)
                        possMoves.Add(s2);
                }
            }
            //En passant

            return possMoves;
        }
    //    public override List<Square> calcPossibleMoves(List<Piece> whitePieces, List<Piece> blackPieces)
    //    {
    //        List<Square> whiteSquares = new List<Square>();
    //        foreach (Piece p in whitePieces)
    //            whiteSquares.Add(p._square);
    //        List<Square> blackSquares = new List<Square>();
    //        foreach (Piece p in blackPieces)
    //            blackSquares.Add(p._square);
    //        List<Square> possMoves = new List<Square>();
    //        int file = _square._file;
    //        int rank = _square._rank;
    //        if (_color.Equals(Position.Players.White))
    //        {
    //            Square s = new Square(file, rank + 1);
    //            if (!whiteSquares.Contains(s) && !blackSquares.Contains(s))
    //            {
    //                possMoves.Add(s);
    //                if (rank == 2)
    //                {
    //                    s = new Square(file, rank + 2);
    //                    if (!whiteSquares.Contains(s) && !blackSquares.Contains(s))
    //                        possMoves.Add(s);
    //                }
    //            }
                
    //            //capture moves
    //            if (file > 1)//capture to the left
    //            {
    //                s = new Square(file - 1, rank + 1);
    //                if (blackSquares.Contains(s))
    //                    possMoves.Add(s);
    //                //else//En passant
    //                //{
    //                //    Square passSquare = new Square(file-1,rank);
    //                //    Move lastMove = new Move(new Square(file-1,rank+2),passSquare);
    //                //    foreach (Piece p in blackPieces)
    //                //        if (p._square.Equals(passSquare) && p is Pawn && p._lastMove.Equals(lastMove))
    //                //            possMoves.Add(passSquare);
    //                //}
    //            }
    //            if (file < 8)//capture to the right
    //            {
    //                s = new Square(file + 1, rank + 1);
    //                if (blackSquares.Contains(s))
    //                    possMoves.Add(s);
    //                //else//En passant
    //                //{
    //                //    Square passSquare = new Square(file + 1, rank);
    //                //    Move lastMove = new Move(new Square(file + 1, rank + 2), passSquare);
    //                //    foreach (Piece p in blackPieces)
    //                //        if (p._square.Equals(passSquare) && p is Pawn && p._lastMove.Equals(lastMove))
    //                //            possMoves.Add(passSquare);
    //                //}
    //            }
                    
    //        }
    //        else//color is black
    //        {
    //            Square s = new Square(file, rank - 1);
    //            if (!whiteSquares.Contains(s) && !blackSquares.Contains(s))
    //            {
    //                possMoves.Add(s);
    //                if (rank == 7)
    //                {
    //                    s = new Square(file, rank - 2);
    //                    if (!whiteSquares.Contains(s) && !blackSquares.Contains(s))
    //                    possMoves.Add(s);
    //                }
    //            }
                
               
    //            //capture moves
    //            if (file > 1)
    //            {
    //                s = new Square(file - 1, rank - 1);
    //                if(whiteSquares.Contains(s))
    //                    possMoves.Add(s);
    //                //else//En passant
    //                //{
    //                //    Square passSquare = new Square(file - 1, rank);
    //                //    Move lastMove = new Move(new Square(file - 1, rank - 2), passSquare);
    //                //    foreach (Piece p in whitePieces)
    //                //        if (p._square.Equals(passSquare) && p is Pawn && p._lastMove.Equals(lastMove))
    //                //            possMoves.Add(passSquare);
    //                //}
    //            }
    //            if (file < 8)
    //            {
    //                s = new Square(file + 1, rank - 1);
    //                if (whiteSquares.Contains(s))
    //                    possMoves.Add(s);
    //                //else//En passant
    //                //{
    //                //    Square passSquare = new Square(file + 1, rank);
    //                //    Move lastMove = new Move(new Square(file + 1, rank - 2), passSquare);
    //                //    foreach (Piece p in whitePieces)
    //                //        if (p._square.Equals(passSquare) && p is Pawn && p._lastMove.Equals(lastMove))
    //                //            possMoves.Add(passSquare);
    //                //}
    //            }
                    
    //        }
    //        return possMoves;
    //    }
    }
}
