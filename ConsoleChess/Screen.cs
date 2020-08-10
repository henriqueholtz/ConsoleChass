using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using board;
using chess;

namespace ConsoleChess
{
    class Screen
    {
        public static void PrintMatch(ChessMatch Match)
        {
            PrintBoard(Match.Board);
            Console.WriteLine();
            PrintCapturedPieces(Match);
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Shift: " + Match.Shift);
            Console.ForegroundColor = aux;
            if (!Match.Finish)
            {
                if (Match.CurrentPlayer == Color.Black)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.WriteLine("Awaiting move: " + Match.CurrentPlayer);
                Console.ForegroundColor = aux;
                if (Match.Check)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("CHECK!");
                    Console.ForegroundColor = aux;
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + Match.CurrentPlayer);
            }
            Console.WriteLine();
        }

        public static void PrintCapturedPieces(ChessMatch Match)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Captured Pieces:");
            Console.ForegroundColor = aux;
            Console.Write("White: ");
            PrintSet(Match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Black: ");
            PrintSet(Match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                ConsoleColor auxFore = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = auxFore;
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
        }

        public static void PrintBoard(Board board, bool[,] PossiblesPositions)
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor CustomBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;
                for (int j = 0; j < board.Columns; j++)
                {
                    if (PossiblesPositions[i,j])
                    {
                        Console.BackgroundColor = CustomBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = OriginalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = OriginalBackground;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
            
        }

        public static PositionChess ReadPositionChess()
        {
            char column;
            int line;
            try
            {
                string position = Console.ReadLine();
                if (position == "" || position.Length > 2)
                {
                    throw new BoardException("Invalid position!");
                }
                column = position[0];
                line = int.Parse(position[1] + "");
                return new PositionChess(column, line);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
                return new PositionChess('a', 0); //Error
            }
        }
    }
}
