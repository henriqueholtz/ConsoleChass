using System;
using System.Security.Cryptography;
using board;
using chess;

namespace board
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public  Color CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            PutPieces();
        }

        public void PerformMovement(Position source, Position destiny)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseAmountMovements();
            Piece pieceRemoved = Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);
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

        private void PutPieces()
        {

            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('c', 1).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('c', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('d', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('e', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('e', 1).ToPosition());
            Board.AddPiece(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());


            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('e',7).ToPosition());
            Board.AddPiece(new King(Board, Color.Black), new PositionChess('d', 8).ToPosition());

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
