using board;

namespace chess
{
    class Queen : Piece
    {

        public Queen(Board board, Color color) : base(board,color)
        {
        }
        public override string ToString()
        {
            return "R"; //Queen(pt-br) = Rainha
        }
        public override bool[,] PossibleMovements()
        {
            throw new BoardException("we need to implement");
            //    bool[,] mat = new bool[Board.Lines, Board.Columns];
            //    Position pos = new Position(0, 0); 
        }
    }
}
