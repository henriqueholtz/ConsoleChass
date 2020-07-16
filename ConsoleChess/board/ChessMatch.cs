using System;
using board;
using chess;

namespace board
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Shift;
        private Color CurrentPlayer; 
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
        }

    }
}
