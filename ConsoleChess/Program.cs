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
                    //condição para não quebrar aplicação usando "7d" ou "d9"
                    Console.Write("Source: ");
                    Position source = Screen.ReadPositionChess().ToPosition();

                    bool[,] PossiblesPositions = Match.Board.Piece(source).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(Match.Board, PossiblesPositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadPositionChess().ToPosition();
                    Match.PerformMovement(source, destiny);
                }
            }
            catch(BoardException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
