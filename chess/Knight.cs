using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.chess
{
    public class Knight : Piece
    {
        public Knight(Color color, GameBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool canMove(Position pos)
        {
            Piece piece = gameBoard.piece(pos);
            return piece == null || piece.Color != this.Color;

        }
        public override bool[,] possibleMovements()
        {
            bool[,] matrix = new bool[gameBoard.lines, gameBoard.rows];

            Position pos = new Position(0, 0);

            pos.defineValues(Position.Line - 1, Position.Column - 2);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 2, Position.Column - 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 2, Position.Column + 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line - 1, Position.Column + 2);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column + 2);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 2, Position.Column + 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 2, Position.Column - 1);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            pos.defineValues(Position.Line + 1, Position.Column - 2);

            if (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }



            return matrix;
        }
    }
}
