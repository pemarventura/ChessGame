using System;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using board;

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
                    if (gameBoard.piece(i,a) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(gameBoard.piece(i, a) + "_ ");
                    }
                    
                }
                Console.WriteLine("");
            }

            Console.WriteLine("   a b c d e f g h");
        }
        
        public static void printPiece(Piece piece)
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
            }
        }
    }
}
