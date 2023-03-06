using System;
using System.Data;
using board;

namespace chess_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameBoard GameBoard = new GameBoard(8, 8);

            Screen.PrintBoard(GameBoard);
        }
    }
}

