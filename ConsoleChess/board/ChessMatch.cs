using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using chess;

namespace board
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public  Color CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            Check = false;
            CurrentPlayer = Color.White;
            Finish = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece PerformMovement(Position source, Position destiny)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseAmountMovements();
            Piece pieceRemoved = Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);
            if (pieceRemoved != null)
            {
                Captured.Add(pieceRemoved);
            }
            return pieceRemoved;
        }

        public void PerformMove(Position source, Position destiny)
        {
            Piece pieceCaptured = PerformMovement(source, destiny);
            if (IsCheck(CurrentPlayer))
            {
                UndoMovement(source, destiny, pieceCaptured);
                throw new BoardException("You cannot put yourself in check.");
            }
            if (IsCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckMateTest(Adversary(CurrentPlayer)))
            {
                Finish = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
            }
        }

        public void UndoMovement(Position source, Position destiny, Piece pieceCaptured)
        {
            Piece p = Board.RemovePiece(destiny);
            p.DecrementAmountMovements();
            if (pieceCaptured != null)
            {
                Board.AddPiece(pieceCaptured, destiny);
                Captured.Remove(pieceCaptured);
            }
            Board.AddPiece(p, source);
        }

        public void ValidateSourcePosition(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece in this position!");
            }
            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The original piece chosen is not yours.");
            }
            if (!Board.Piece(pos).HavePossibleMovements())
            {
                throw new BoardException("There are no possible moves for the chosen piece.");
            }
        }

        public void ValidateDestinyPosition(Position source, Position destiny)
        {
            if (!Board.Piece(source).CanMove(destiny))
            {
                throw new BoardException("Destination position invalidates.");
            }
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> PiecesInPlay(Color color) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece x in PiecesInPlay(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("Don't have King in board chess.");
            }
            foreach (Piece x in PiecesInPlay(Adversary(color)))
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckMateTest(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach(Piece x in PiecesInPlay(color))
            {
                bool[,] mat = x.PossibleMovements();
                for (int i = 0; i<Board.Lines; i++)
                {
                    for (int j= 0; j < Board.Columns; j++)
                    {
                        if (mat[i,j])
                        {
                            Position source = x.Position;
                            Position destiny = new Position(i, j);
                            Piece CapturedPiece = PerformMovement(source, destiny);
                            bool CheckTest = IsCheck(color);
                            UndoMovement(source, destiny,CapturedPiece);
                            if (!CheckTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.AddPiece(piece, new PositionChess(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            //PutNewPiece('c', 1, new Tower(Board, Color.White));
            //PutNewPiece('c', 2, new Tower(Board, Color.White));
            //PutNewPiece('d', 2, new Tower(Board, Color.White));
            //PutNewPiece('e', 2, new Tower(Board, Color.White));
            //PutNewPiece('e', 1, new Tower(Board, Color.White));
            //PutNewPiece('d', 1, new King(Board, Color.White));

            //PutNewPiece('c', 7, new Tower(Board, Color.Black));
            //PutNewPiece('c', 8, new Tower(Board, Color.Black));
            //PutNewPiece('d', 7, new Tower(Board, Color.Black));
            //PutNewPiece('e', 8, new Tower(Board, Color.Black));
            //PutNewPiece('e', 7, new Tower(Board, Color.Black));
            //PutNewPiece('d', 8, new King(Board, Color.Black));

            // White
            PutNewPiece('a', 2, new Pawn(Board, Color.White));
            PutNewPiece('b', 2, new Pawn(Board, Color.White));
            PutNewPiece('c', 2, new Pawn(Board, Color.White));
            PutNewPiece('d', 2, new Pawn(Board, Color.White));
            PutNewPiece('e', 2, new Pawn(Board, Color.White));
            PutNewPiece('f', 2, new Pawn(Board, Color.White));
            PutNewPiece('g', 2, new Pawn(Board, Color.White));
            PutNewPiece('h', 2, new Pawn(Board, Color.White));
            PutNewPiece('a', 1, new Tower(Board, Color.White));
            PutNewPiece('h', 1, new Tower(Board, Color.White));
            PutNewPiece('b', 1, new Horse(Board, Color.White));
            PutNewPiece('g', 1, new Horse(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White));

            //black 
            PutNewPiece('a', 7, new Pawn(Board, Color.Black));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black));
            PutNewPiece('a', 8, new Tower(Board, Color.Black));
            PutNewPiece('h', 8, new Tower(Board, Color.Black));
            PutNewPiece('b', 8, new Horse(Board, Color.Black));
            PutNewPiece('g', 8, new Horse(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('e', 8, new Queen(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));
        }

    }
}
