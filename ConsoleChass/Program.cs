using board;
using System;

namespace ConsoleChass
{
    class Program
    {
        static void Main(string[] args)
        {
            Board Board = new Board(8, 8);
            Screen.PrintBoard(Board);
        }
    }
}
