using board;
using chess;
using System;

namespace ConsoleChass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board Board = new Board(8, 8);

                Board.AddPiece(new Tower(Board, Color.Black), new Position(0, 0));
                Board.AddPiece(new Tower(Board, Color.Black), new Position(1, 3));
                Board.AddPiece(new King(Board, Color.Black), new Position(2, 4));

                Board.AddPiece(new Tower(Board, Color.White), new Position(3, 5));

                Screen.PrintBoard(Board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
