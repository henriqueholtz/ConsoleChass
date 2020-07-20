using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board,Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }
        public override bool[,] PossibleMovements()
        {
            throw new BoardException("we need to implement");
        }
    }
}
