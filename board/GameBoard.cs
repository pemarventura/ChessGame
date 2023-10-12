
using System.Diagnostics.Contracts;
using System.Globalization;

namespace board
{
    public class GameBoard
    {
        public int lines { get; set; }
        public int rows { get; set; }

        public Piece[,] pieces;

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

        public Piece piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public void putPiece(Piece p, Position pos)
        {
            if (existingPiece(pos)){
                throw new GameBoardException("Position occupied!");
            }
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece removePiece( Position pos) 
        {
           if (piece(pos) == null)
            {
                return null;
           }

           Piece aux = piece(pos);

            aux.Position = null;
            pieces[pos.Line, pos.Column] = null;
            return aux;

        }

        public bool existingPiece(Position pos)
        {
            validateException(pos);

            return piece(pos) != null; 
        }

        public bool validatePosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line > lines || pos.Column < 0 || pos.Column > rows)
            {
                return false;
            }

            return true;
        }

        public void validateException(Position pos)
        {
            if (!validatePosition(pos))
            {
                throw new GameBoardException("Invalid position!");
            }
        }

    }
}
