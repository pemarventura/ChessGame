
namespace board
{
    public class GameBoard
    {
        public int lines { get; set; }
        public int rows { get; set; }

        private Piece[,] pieces;

        public GameBoard(int lines, int rows) 
        {
            this.lines = lines;
            this.rows = rows;
            pieces = new Piece[lines, rows];
        }

        public Piece piece(int line, int column) 
        {
            return pieces[line, column];
        }
    }
}
