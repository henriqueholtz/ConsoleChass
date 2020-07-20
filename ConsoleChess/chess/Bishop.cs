using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }
        public override bool[,] PossibleMovements()
        {
            throw new BoardException("we need to implement");
        }
    }
}
