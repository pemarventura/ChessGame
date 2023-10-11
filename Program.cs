using System;
using System.Data;
using board;

namespace chess_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                GameBoard GameBoard = new GameBoard(8, 8);

                Screen.PrintBoard(GameBoard);
            }

            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

