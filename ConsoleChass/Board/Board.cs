
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

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }
        public void AddPiece(Piece piece, Position position)
        {
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
