using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.chess
{
    public class Pawn : Piece
    {
        public Pawn(Color color, GameBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existEnemy(Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p != null && p.Color != this.Color;
        }

        private bool clear(Position pos)
        {
            return gameBoard.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] matrix = new bool[gameBoard.lines, gameBoard.rows];

            Position pos = new Position(0, 0);

            if (this.Color == Color.White)
            {
                pos.defineValues(Position.Line - 1, Position.Column);
                if (gameBoard.validatePosition(pos) && clear(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line - 2, Position.Column);
                if (gameBoard.validatePosition(pos) && clear(pos) && qntMovements == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line - 1, Position.Column - 1);
                if (gameBoard.validatePosition(pos) && clear(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line - 1, Position.Column + 1);
                if (gameBoard.validatePosition(pos) && clear(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
            }

            else
            {
                pos.defineValues(Position.Line + 1, Position.Column);
                if (gameBoard.validatePosition(pos) && clear(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line + 2, Position.Column);
                if (gameBoard.validatePosition(pos) && clear(pos) && qntMovements == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line + 1, Position.Column - 1);
                if (gameBoard.validatePosition(pos) && clear(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.defineValues(Position.Line + 1, Position.Column + 1);
                if (gameBoard.validatePosition(pos) && clear(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
            }

            return matrix;
        }

    }
}
