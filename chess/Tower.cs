using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class Tower : Piece
    {
        public Tower(Colors color, GameBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
