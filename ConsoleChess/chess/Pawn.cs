using board;

namespace chess
{
    class Pawn : Piece
    {
        private ChessMatch Match;
        public Pawn(Board board,Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "P";
        }
        private bool HaveEnemy(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.Piece(pos) == null;
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            if (Board.ValidPosition(pos))
            {
                return p == null || p.Color != Color;
            }
            return false;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && AmountMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column -1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column +1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #EnPassant White
                pos.SetValues(Position.Line, Position.Column);
                if (pos.Line == 3)
                {
                    Position left = new Position(pos.Line, pos.Column - 1);
                    if (Board.ValidPosition(left) && HaveEnemy(left) && Board.Piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Line -1, left.Column] = true;
                    }
                    Position right = new Position(pos.Line, pos.Column + 1);
                    if (Board.ValidPosition(right) && HaveEnemy(right) && Board.Piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Line -1, right.Column] = true;
                    }
                }
            }
            else //Black
            {
                pos.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && AmountMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #EnPassant Black
                pos.SetValues(Position.Line, Position.Column);
                if (pos.Line == 4)
                {
                    Position left = new Position(pos.Line, pos.Column - 1);
                    if (Board.ValidPosition(left) && HaveEnemy(left) && Board.Piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Line +1, left.Column] = true;
                    }
                    Position right = new Position(pos.Line, pos.Column + 1);
                    if (Board.ValidPosition(right) && HaveEnemy(right) && Board.Piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Line +1, right.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
