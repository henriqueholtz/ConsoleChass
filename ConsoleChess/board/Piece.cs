
namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; } //only subclass
        public int AmountMovements { get; protected set; }
        public Board Board { get; protected set; }
        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
        }
        public void IncreaseAmountMovements()
        {
            AmountMovements++;
        }
        public void DecrementAmountMovements()
        {
            AmountMovements--;
        }

        public bool HavePossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j<Board.Columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMove(Position pos) //Changed title in course to: PossibleMovement
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
