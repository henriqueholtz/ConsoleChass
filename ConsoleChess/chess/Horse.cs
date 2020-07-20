using board;

namespace chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "C"; //Horse(pt-br) = Cavalo
        }
        public override bool[,] PossibleMovements()
        {
            throw new BoardException("we need to implement");
        }
    }
}
