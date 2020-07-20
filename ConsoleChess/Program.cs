using board;
using chess;
using System;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch Match = new ChessMatch();
            while (!Match.Finish)
            {
                try
                {
                    Console.Clear();
                    Screen.PrintBoard(Match.Board);
                    Console.WriteLine();
                    Console.WriteLine("Shift: " + Match.Shift);
                    Console.WriteLine("Awaiting move: " + Match.CurrentPlayer);

                    Console.WriteLine();
                    //condição para não quebrar aplicação usando "7d" ou "d9"
                    Console.Write("Source: ");
                    Position source = Screen.ReadPositionChess().ToPosition();
                    Match.ValidateSourcePosition(source);

                    bool[,] PossiblesPositions = Match.Board.Piece(source).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(Match.Board, PossiblesPositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadPositionChess().ToPosition();
                    Match.ValidateDestinyPosition(source, destiny);
                    Match.PerformMove(source, destiny);
                }
                catch (BoardException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
