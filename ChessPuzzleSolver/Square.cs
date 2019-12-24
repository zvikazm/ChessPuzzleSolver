using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver 
{
    public class Square : IEquatable<Square>
    {

        public int _rank { get; set; }
        public int _file { get; set; }

        public Square()
        {
        }
        public Square(int file, int rank)
        {
            _file = file;
            _rank = rank;
        }
        
        public Square(char file, int rank)
        {        
            _rank = rank;
            _file = char2Int(file);
	    }

        public Square(Square square)
        {
            if (square != null)
            {
                this._file = square._file;
                this._rank = square._rank;
            }
        }
        public override string ToString()
        {
            return int2Char(_file).ToString() + " "+  _rank.ToString();
        }
        public static int char2Int(char c)
        {
            int fileInt = -1;
            switch (c)
            {
                case 'a': fileInt = 1; break;
                case 'b': fileInt = 2; break;
                case 'c': fileInt = 3; break;
                case 'd': fileInt = 4; break;
                case 'e': fileInt = 5; break;
                case 'f': fileInt = 6; break;
                case 'g': fileInt = 7; break;
                case 'h': fileInt = 8; break;
            }
            return fileInt;
        }
        public static char int2Char(int i)
        {
            char c='?';
            switch (i)
            {
                case 1: c = 'a'; break;
                case 2: c = 'b'; break;
                case 3: c = 'c'; break;
                case 4: c = 'd'; break;
                case 5: c = 'e'; break;
                case 6: c = 'f'; break;
                case 7: c = 'g'; break;
                case 8: c = 'h'; break;
            }
            return c;
        }

        #region IEquatable<Square> Members

        public bool Equals(Square other)
        {
            return (this._file == other._file) && (this._rank == other._rank);
        }

        #endregion
    }
}
