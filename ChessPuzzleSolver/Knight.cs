using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class Knight:Piece
    {
        public Knight()
        {
        }

        public Knight(Square location, Position.Players color, Move lastMove)
        {
            _square = location;
            _color = color;
            _lastMove = lastMove;
        }

        public Knight(Square location,Position.Players color)
        {
            _square = location;
            _color = color;
        }

        public Knight(Piece piece)
        {
            this._color = piece._color;
            this._square = new Square(piece._square);
            this._lastMove = new Move(piece._lastMove);
        }

        public override List<Square> calcPossibleMoves(Position pos)
        {
            List<Square> selfSquares = new List<Square>();
            if (_color.Equals(Position.Players.White))
            {
                foreach (Piece p in pos.mWhitePieces)
                    selfSquares.Add(p._square);
            }
            else
            {
                foreach (Piece p in pos.mBlackPieces)
                    selfSquares.Add(p._square);
            }
            List<Square> possMoves = new List<Square>();
            int file = _square._file;
            int rank = _square._rank;
            
            if(file-2 > 0 && rank+1 < 9)
                possMoves.Add(new Square(file-2,rank+1));
            if(file-1 > 0 && rank+2 < 9)
                possMoves.Add(new Square(file-1,rank+2));
            if(file+1 < 9 && rank+2 < 9)
                possMoves.Add(new Square(file+1,rank+2));
            if(file+2 < 9 && rank+1 < 9)
                possMoves.Add(new Square(file+2,rank+1));
            if(file+2 < 9 && rank-1 > 0)
                possMoves.Add(new Square(file+2, rank-1));
            if(file+1 < 9 && rank-2 > 0)
                possMoves.Add(new Square(file+1, rank-2));
            if(file-1 > 0 && rank-2 > 0)
                possMoves.Add(new Square(file-1, rank-2));
            if(file-2 > 0 && rank-1 > 0)
                possMoves.Add(new Square(file-2, rank-1));
            foreach(Square s in selfSquares)
            {
                if(possMoves.Contains(s))
                    possMoves.Remove(s);
            }

            return possMoves;
        }
    }
}
