using System.Collections.Generic;
using System.Runtime.CompilerServices;
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


        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public void PerformMovement(Position source, Position destiny)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseAmountMovements();
            Piece pieceRemoved = Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);
            if (pieceRemoved != null)
            {
                Captured.Add(pieceRemoved);
            }
        }

        public void PerformMove(Position source, Position destiny)
        {
            PerformMovement(source, destiny);
            Shift ++;
            ChangePlayer();
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

        public HashSet<Piece> PiecesInPlay(Color cor) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(cor));
            return aux;
        }

        public HashSet<Piece> CapturedPieces(Color cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.AddPiece(piece, new PositionChess(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(Board, Color.White));
            PutNewPiece('c', 2, new Tower(Board, Color.White));
            PutNewPiece('d', 2, new Tower(Board, Color.White));
            PutNewPiece('e', 2, new Tower(Board, Color.White));
            PutNewPiece('e', 1, new Tower(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            PutNewPiece('c', 7, new Tower(Board, Color.Black));
            PutNewPiece('c', 8, new Tower(Board, Color.Black));
            PutNewPiece('d', 7, new Tower(Board, Color.Black));
            PutNewPiece('e', 8, new Tower(Board, Color.Black));
            PutNewPiece('e', 7, new Tower(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));

            /*// White
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('a', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('b', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('c', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('d', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('e', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('f', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('g', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('h', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('a', 1).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('h', 1).ToPosition());
            Board.AddPiece(new Horse(Board, Color.White), new PositionChess('b', 1).ToPosition());
            Board.AddPiece(new Horse(Board, Color.White), new PositionChess('g', 1).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.White), new PositionChess('c', 1).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.White), new PositionChess('f', 1).ToPosition());
            Board.AddPiece(new Queen(Board, Color.White), new PositionChess('d', 1).ToPosition());
            Board.AddPiece(new King(Board, Color.White), new PositionChess('e', 1).ToPosition());

            //black 
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('a', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('b', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('e', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('f', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('g', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('h', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('a', 8).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('h', 8).ToPosition());
            Board.AddPiece(new Horse(Board, Color.Black), new PositionChess('b', 8).ToPosition());
            Board.AddPiece(new Horse(Board, Color.Black), new PositionChess('g', 8).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.Black), new PositionChess('f', 8).ToPosition());
            Board.AddPiece(new Queen(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            Board.AddPiece(new King(Board, Color.Black), new PositionChess('d', 8).ToPosition());*/
        }

    }
}
