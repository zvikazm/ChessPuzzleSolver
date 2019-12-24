using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public abstract class Piece: IEquatable<Piece>, ICloneable
    {
        public Position.Players _color { get; set; }
        public Square _square { get; set; }
        public Move _lastMove { get; set; }

        public Piece()
        {
        }
        public Piece(Square square)
        {
            _square = square;
        }

        public Piece(Piece piece)
        {
            this._color = piece._color;
            this._square = new Square(piece._square);
            this._lastMove = new Move(piece._lastMove);
        }

        public override string ToString()
        {
            //this.GetType().Name
            return this.GetType().Name + " " + _color + " " + _square;
        }
        
        /*
         * this function calculate and return all possible moves of the piece.
         * It doesn't take care of check situations.
         * It takes care only to other pieces positions on the board, I.E. they not override 
         * self pieces and not jump over other pieces
         * This function assume that when call the turn belongs to the piece
         * 
         */
        abstract public List<Square> calcPossibleMoves(Position pos);


        #region IEquatable<Piece> Members

        public bool Equals(Piece other)
        {
            return (this._square.Equals(other._square)) && (this._color.Equals(other._color)) && (this.GetType().Equals(other.GetType()));
        }

        #endregion





        #region ICloneable Members

        public object Clone()
        {
            if (this is Bishop)
                return new Bishop(this);
            if (this is King)
                return new King(this);
            if (this is Knight)
                return new Knight(this);
            if (this is Pawn)
                return new Pawn(this);
            if (this is Queen)
                return new Queen(this);
            return new Rook(this);
        }

        #endregion
    }
}
