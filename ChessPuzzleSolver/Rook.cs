using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class Rook:Piece
    {
        public Rook()
        {
        }

        public Rook(Square location, Position.Players color, Move lastMove)
        {
            _square = location;
            _color = color;
            _lastMove = lastMove;
        }

        public Rook(Square location,Position.Players color)
        {
            _square = location;
            _color = color;
        }
        public Rook(Piece piece)
        {
            this._color = piece._color;
            this._square = new Square(piece._square);
            this._lastMove = new Move(piece._lastMove);
        }
        public override List<Square> calcPossibleMoves(Position pos)
        {
            List<Square> selfSquares = new List<Square>();
            List<Square> opponentSquares = new List<Square>();
            if (_color.Equals(Position.Players.White))
            {
                foreach (Piece p in pos.mWhitePieces)
                    selfSquares.Add(p._square);
                foreach (Piece p in pos.mBlackPieces)
                    opponentSquares.Add(p._square);
            }
            else//self color is black
            {
                foreach (Piece p in pos.mWhitePieces)
                    opponentSquares.Add(p._square);
                foreach (Piece p in pos.mBlackPieces)
                    selfSquares.Add(p._square);
            }
            List<Square> possMoves = new List<Square>();
            int file = _square._file;
            int rank = _square._rank;
            int i = rank+1;
            int j = file;
            while (i < 9)
            {
                Square s = new Square(j, i);
                if (selfSquares.Contains(s))
                    break;
                possMoves.Add(s);
                if (opponentSquares.Contains(s))
                    break;
                i++;
            }
            i = rank - 1;
            while (i > 0)
            {
                Square s = new Square(j, i);
                if (selfSquares.Contains(s))
                    break;
                possMoves.Add(s);
                if (opponentSquares.Contains(s))
                    break;
                i--;
            }
            i = rank;
            j = file + 1;
            while (j < 9)
            {
                Square s = new Square(j, i);
                if (selfSquares.Contains(s))
                    break;
                possMoves.Add(s);
                if (opponentSquares.Contains(s))
                    break;
                j++;
            }
            j = file - 1;
            while (j > 0)
            {
                Square s = new Square(j, i);
                if (selfSquares.Contains(s))
                    break;
                possMoves.Add(s);
                if (opponentSquares.Contains(s))
                    break;
                j--;
            }
            return possMoves;
        }
    }
}
