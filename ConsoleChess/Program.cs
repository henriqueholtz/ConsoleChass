using board;
using chess;
using System;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch Match = new ChessMatch();
                while(!Match.Finish)
                {
                    Console.Clear();
                    Screen.PrintBoard(Match.Board);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position source = Screen.ReadPositionChess().ToPosition();
                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadPositionChess().ToPosition();

                    Match.PerformMovement(source, destiny);
                }
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
