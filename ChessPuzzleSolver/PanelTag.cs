using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessPuzzleSolver
{
    public class PanelTag
    {
        public Square _square { get; set; }
        public Piece _piece { get; set; }
        public PanelTag()
        {
        }
        public PanelTag(Square square, Piece piece)
        {
            _square = square;
            _piece = piece;
        }
    }
}
