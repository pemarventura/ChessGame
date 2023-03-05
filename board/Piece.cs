
namespace board
{
    class Piece
    {
        public Position Position { get; set; }
        public Colors Color { get; protected set; }
        public int qntMovements { get; protected set; }
        public GameBoard gameBoard {  get; protected set; }

        public Piece(Position position, Colors color, GameBoard gameBoard)
        {
            Position = position;
            Color = color;
            this.qntMovements = 0;
            this.gameBoard = gameBoard;
        }


    }
}
