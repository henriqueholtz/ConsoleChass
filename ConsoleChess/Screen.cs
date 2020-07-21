using System;
using System.Collections.Generic;
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
            Console.WriteLine("Shift: " + Match.Shift);
            Console.WriteLine("Awaiting move: " + Match.CurrentPlayer);
            if (Match.Check)
            {
                Console.WriteLine("CHECK!");
            }
            Console.WriteLine();
        }

        public static void PrintCapturedPieces(ChessMatch Match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintSet(Match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
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
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            } 
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] PossiblesPositions)
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor CustomBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
            
        }

        public static PositionChess ReadPositionChess()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int line = int.Parse(position[1] + "");
            return new PositionChess(column, line);
        }
    }
}
