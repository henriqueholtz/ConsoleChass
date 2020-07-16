
namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public void AddPiece(Piece piece, Position position)
        {
            if (ExistPiece(position))
            {
                throw new BoardException("This position is already occupied.");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool ExistPiece(Position position)
        {
            ValidatePosition(position); //BoardException
            return Piece(position) != null;
        }

        public bool ValidPosition(Position position) 
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }
        public void ValidatePosition(Position position) 
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position Guy!");
            }
        }
    }
}
