
namespace board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int qntMovements { get; protected set; }
        public GameBoard gameBoard {  get; protected set; }

        public Piece(Color color, GameBoard gameBoard)
        {
            this.Position = null;
            this.Color = color;
            this.qntMovements = 0;
            this.gameBoard = gameBoard;
        }
    }
}
