
namespace board
{
    class GameBoard
    {
        public int lines { get; set; }
        public int rows { get; set; }

        private Piece[,] pieces;

        public GameBoard() 
        {
            this.lines = lines;
            this.rows = rows;
            pieces = new Piece[lines, rows];
        }
    }
}
