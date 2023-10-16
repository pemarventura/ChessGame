using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class ChessMatch
    {
        public GameBoard board;
        public int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;
        public bool check { get; set; }

        public ChessMatch()
        {
            board = new GameBoard(8,8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
        }

        public bool testCheckMate(Color color)
        {
            if (!isInCheck(color))
                return false;

            foreach (Piece piece in piecesInPlay(color)) 
            {
                bool[,] matrix  = piece.possibleMovements();

                for (int i=0; i<board.lines; i++)
                    for (int j=0; j<board.rows; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = piece.Position;
                            Position target = new Position(i, j);

                            Piece capturedPiece = executeMovement(origin, new Position(i,j));

                            bool testCheck = isInCheck(color);

                            undoMovement(origin, target, capturedPiece);

                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
            }

            return true;
        }


        public Piece executeMovement(Position origin, Position target)
        {
            Piece p = board.removePiece(origin);
            p.addMovements();
            Piece capturedPiece = board.removePiece(target);
            board.putPiece(p, target);

            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void undoMovement(Position origin, Position target, Piece capturedPiece) 
        { 
            Piece p = board.removePiece(target);
            p.decreaseMovements();
            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, target);
                capturedPieces.Remove(capturedPiece);
            }

            board.putPiece(p, origin);
        }

        private Color oponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }

            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece piece in piecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece R = king(color);
            if (R == null)
            {
                throw new TargetException("There is no king of color" + color + "on the board!");
            }

            foreach (Piece x in piecesInPlay(oponent(color)))
            {
                bool[,] matrix = x.possibleMovements();

                if (matrix[R.Position.Line, R.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }
        public HashSet<Piece> capturedPiecesMethod(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturedPieces) 
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(capturedPiecesMethod(color));

            return aux;
        }

        public HashSet<Piece> piecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public void addNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);  
        }

        public void setPlay(Position origin, Position target)
        {
            Piece capturedPiece = executeMovement(origin, target);

            if (isInCheck(currentPlayer))
            {
                undoMovement(origin, target, capturedPiece);
                throw new GameBoardException("You can't put yourself in check!");
            }

            if (isInCheck(oponent(currentPlayer)))
            {
                check = true;
            }

            else
            {
                check = false;
            }

            if (testCheckMate(oponent(currentPlayer))) 
            {
                finished = true;
            }

            turn++;

            changePlayer();
        }

        public void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }

            else
            {
                currentPlayer = Color.Black;
            }
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new GameBoardException("This color do not have a piece on that position");
            }

            if (currentPlayer != board.piece(pos).Color)
            {
                throw new GameBoardException("The piece on the chosen position is not tours");
            }

            if (!board.piece(pos).thereArePossibleMovements())
            {
                throw new GameBoardException("There are no possible movements for the chosen piece");
            }
        }

        public void validateTargetPosition(Position posOrigin, Position posTarget)
        {
            if (!board.piece(posOrigin).possibleMovement(posTarget))
            {
                throw new GameBoardException("Target position invalid");
            }
        }
    }
}
