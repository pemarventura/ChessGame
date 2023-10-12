using System;
using System.Data;
using board;
using chess;

namespace chess_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(chessMatch.board);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + chessMatch.turn);
                        //Console.WriteLine("Waiting play: " chessMatch.c);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        chessMatch.validateOriginPosition(origin);

                        bool[,] possiblePositions = chessMatch.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(chessMatch.board);

                        Console.WriteLine();
                        Console.Write("Target: ");
                        Position target = Screen.readChessPosition().toPosition();
                        chessMatch.validateTargetPosition(origin, target);

                        chessMatch.setPlay(origin, target);
                    }

                    catch (GameBoardException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }


            }

            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

