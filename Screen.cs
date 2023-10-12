using System;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using board;
using chess;

namespace chess_console
{
    public class Screen
    {
        public static void PrintBoard(GameBoard gameBoard)
        {
            for (int i = 0; i <gameBoard.lines; i++)
            {
                Console.Write(8 - 1 + " ");

                for (int a = 0; a <gameBoard.rows; a++)
                {
                    printPiece(gameBoard.piece(i,a));
                    Console.Write("");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("   a b c d e f g h");
        }

        public static void PrintBoard(GameBoard gameBoard, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray; 

            for (int i = 0; i < gameBoard.lines; i++)
            {
                Console.Write(8 - 1 + " ");

                for (int a = 0; a < gameBoard.rows; a++)
                {
                    if (possiblePositions[i, a] == true)
                    {
                        Console.BackgroundColor = alteredBackground;
                    }

                    else
                    {
                        Console.ForegroundColor = originalBackground;
                    }
                    
                    printPiece(gameBoard.piece(i, a));
                    Console.ForegroundColor = originalBackground;

                }
                Console.WriteLine("");
            }

            Console.WriteLine("   a b c d e f g h");
            Console.ForegroundColor = originalBackground;
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }

                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
           
        }
    }
}
