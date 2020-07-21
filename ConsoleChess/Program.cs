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
                while (!Match.Finish)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(Match);

                        Console.WriteLine();
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
                Console.Clear();
                Screen.PrintMatch(Match);
            }
            catch(BoardException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
