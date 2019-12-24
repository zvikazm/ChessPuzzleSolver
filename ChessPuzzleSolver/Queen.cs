using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class Queen:Piece
    {
        public Queen()
        {
        }

        public Queen(Square location, Position.Players color, Move lastMove)
        {
            _square = location;
            _color = color;
            _lastMove = lastMove;
        }

        public Queen(Square location,Position.Players color)
        {
            _square = location;
            _color = color;
        }

        public Queen(Piece piece)
        {
            this._color = piece._color;
            this._square = new Square(piece._square);
            this._lastMove = new Move(piece._lastMove);
        }

        public override List<Square> calcPossibleMoves(Position pos)
        {
            Rook rook = new Rook(_square,this._color);
            Bishop bishop = new Bishop(_square,this._color);
            List<Square> rookList = rook.calcPossibleMoves(pos);
            List<Square> bishopList = bishop.calcPossibleMoves(pos);
            List<Square> possMoves = new List<Square>();
            possMoves.AddRange(rookList);
            possMoves.AddRange(bishopList);
            return possMoves;
        }
    }
}
