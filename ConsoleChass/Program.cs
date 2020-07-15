using board;
using chass;
using System;

namespace ConsoleChass
{
    class Program
    {
        static void Main(string[] args)
        {
            Board Board = new Board(8, 8);

            Board.AddPiece(new Tower(Board, Color.Black),new Position(0, 0));
            Board.AddPiece(new Tower(Board,Color.Black),new Position(1, 3));
            Board.AddPiece(new King(Board,Color.Black),new Position(2, 4));

            Screen.PrintBoard(Board);
        }
    }
}
