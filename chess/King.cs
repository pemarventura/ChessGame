using board;

namespace chess
{
    public class King : Piece
    {
        public King(Color color, GameBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool canMove(Position pos)
        {
            Piece piece = gameBoard.piece(pos);
            return piece == null || piece.Color != this.Color;

        }
        public override bool[,] possibleMovements()
        {
            bool[,] matrix = new bool[gameBoard.lines, gameBoard.rows];

            Position pos = new Position(0,0);

            pos.defineValues(pos.Line - 1, pos.Column);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line,pos.Column] = true;
            }

            pos.defineValues(pos.Line - 1, pos.Column + 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(pos.Line, pos.Column + 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(pos.Line + 1, pos.Column + 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(pos.Line + 1, pos.Column);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(pos.Line + 1, pos.Column - 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(pos.Line , pos.Column - 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(pos.Line - 1, pos.Column - 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            return matrix;
        }
    }
}
