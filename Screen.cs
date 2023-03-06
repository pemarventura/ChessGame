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
                for (int a = 0; a <gameBoard.rows; a++)
                {
                    Console.Write(gameBoard.piece(i,a) + "_ ");
                }
                Console.WriteLine("");
            }
        }
        

    }
}
