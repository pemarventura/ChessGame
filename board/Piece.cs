
namespace board
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int qntMovements { get; set; }
        public GameBoard gameBoard {  get; set; }

        public Piece(Color color, GameBoard gameBoard)
        {
            this.Position = null;
            this.Color = color;
            this.qntMovements = 0;
            this.gameBoard = gameBoard;
        }

        public void addMovements()
        {
            qntMovements++;
        }

        public void decreaseMovements()
        {
            qntMovements--;
        }

        public bool thereArePossibleMovements()
        {
            bool[,] matrix = possibleMovements();
            for (int i = 0; i < gameBoard.lines; i++)
            {
                for (int j = 0; j < gameBoard.rows; j++)
                {
                    if (matrix[i,j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool possibleMovement(Position pos)
        {
            return possibleMovements()[pos.Line,pos.Column];
        }

        public abstract bool[,] possibleMovements();

    }
}
