
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

        public abstract bool[,] PossibleMovements();
    }
}
