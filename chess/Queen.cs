using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.chess
{
    public class Queen : Piece
    {
        public Queen(Color color, GameBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
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

            pos.defineValues(Position.Line - 1, Position.Column - 1);
            while (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.defineValues(pos.Line - 1, pos.Column - 1);
            }

            pos.defineValues(Position.Line - 1, Position.Column + 1);
            while (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.defineValues(pos.Line - 1, pos.Column + 1);
            }

            pos.defineValues(Position.Line + 1, Position.Column + 1);
            while (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.defineValues(pos.Line + 1, pos.Column + 1);
            }

            pos.defineValues(pos.Line - 1, pos.Column);
            while (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).Color != this.Color)
                {
                    pos.Line = pos.Line - 1;
                }
            }

            pos.defineValues(pos.Line + 1, pos.Column);
            while (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).Color != this.Color)
                {
                    pos.Line = pos.Line + 1;
                }
            }

            pos.defineValues(pos.Line, pos.Column + 1);
            while (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).Color != this.Color)
                {
                    pos.Column = pos.Column + 1;
                }
            }

            pos.defineValues(pos.Line, pos.Column - 1);
            while (gameBoard.validatePosition(pos) && canMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).Color != this.Color)
                {
                    pos.Column = pos.Column - 1;
                }
            }

            return matrix;
        }

    }
}
