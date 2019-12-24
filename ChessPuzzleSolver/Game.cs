using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{        
    public class Game
    {
        public Position mStartPos { set; get; }
        public string mEvent { set; get; }
        public string mSite { set; get; }
        public string mDate { set; get; }
        public string mRound { set; get; }
        public string mWhite { set; get; }
        public string mBlack { set; get; }
        public string mResult { set; get; }
        public List<FullMove> mListMove { set; get; }

        public Game()
        {
        }
    }
}
