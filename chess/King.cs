using board;

namespace chess
{
    public class King : Piece
    {
        public King(Colors color, GameBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
