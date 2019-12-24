using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class Move: IEquatable<Move>
    {
        public Square _source { get; set; }
        public Square _dest { get; set; }
        public Move()
        {
        }
        public Move(Square source, Square dest)
        {
            _source = new Square(source);
            _dest = new Square(dest);
        }
        public Move(Move move)
        {
            if (move != null)
            {
                this._source = new Square(move._source);
                this._dest = new Square(move._dest);
            }
        }
        public override string ToString()
        {
            if (_source != null && _dest != null)
                return _source.ToString() + "-" + _dest.ToString();
            else
                return "nullmove";
        }

        #region IEquatable<Move> Members

        public bool Equals(Move other)
        {
            return (this._source.Equals(other._source)) && (this._dest.Equals(other._dest));
        }

        #endregion

    }
}
