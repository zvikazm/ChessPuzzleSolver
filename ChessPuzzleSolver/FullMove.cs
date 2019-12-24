using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class FullMove
    {
        public int mNumOfMove { set; get; }
        public string mWhiteMove { set; get; }
        public string mBlackMove { set; get; }
        public string mComment { set; get; }

        public FullMove()
        {
        }

        public object Clone()
        {
            FullMove ret = new FullMove();
            ret.mNumOfMove = this.mNumOfMove;
            ret.mWhiteMove = this.mWhiteMove;
            ret.mBlackMove = this.mBlackMove;
            ret.mComment = this.mComment;
            return ret;
        }

        public string ToString()
        {
            return mNumOfMove + ". " + mWhiteMove + " " + mBlackMove + " " + mComment;
        }

        //public void Reset()
        //{
        //    this.mNumOfMove = -1;
        //    this.mWhiteMove = null;
        //    this.mBlackMove = null;
        //    this.mComment = null;
        //}
    }
}
