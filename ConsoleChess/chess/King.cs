using board;

namespace chess
{
    class King : Piece
    {
        private ChessMatch Match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "R"; //King = Rei
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            //if (Board.ValidPosition(pos))
            //{
                return p == null || p.Color != Color;
            //}
            //return false;
        }

        private bool TestTowerForRock(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Tower && p.Color == Color && p.AmountMovements == 0;
        }

        public override bool[,] PossibleMovements() //movimentosPossiveis
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            //Top
            pos.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Top-Right
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Right
            pos.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Down-Right
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Down
            pos.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Down-Left
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Left
            pos.SetValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Top-Left
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //#SpecialMove
            if (AmountMovements == 0 && !Match.Check)
            {
                if (Color == Color.White)
                {
                    //#SmallRock White
                    Position PosT1 = new Position(Position.Line, Position.Column + 3);
                    if (Board.ValidPosition(PosT1))
                    {
                        if (TestTowerForRock(PosT1))
                        {
                            Position p1 = new Position(Position.Line, Position.Column + 1);
                            Position p2 = new Position(Position.Line, Position.Column + 2);
                            if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                            {
                                mat[Position.Line, Position.Column + 2] = true;
                            }
                        }
                    }

                    //#BigRock White
                    Position PosT2 = new Position(Position.Line, Position.Column - 4);
                    if (Board.ValidPosition(PosT2))
                    {
                        if (TestTowerForRock(PosT2))
                        {
                            Position p1 = new Position(Position.Line, Position.Column - 1);
                            Position p2 = new Position(Position.Line, Position.Column - 2);
                            Position p3 = new Position(Position.Line, Position.Column - 3);
                            if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                            {
                                mat[Position.Line, Position.Column - 2] = true;
                            }
                        }
                    }
                }
                else //Black
                {
                    //#SmallRock Black
                    Position PosT1 = new Position(Position.Line, Position.Column - 3);
                    if (Board.ValidPosition(PosT1))
                    {
                        if (TestTowerForRock(PosT1))
                        {
                            Position p1 = new Position(Position.Line, Position.Column - 1);
                            Position p2 = new Position(Position.Line, Position.Column - 2);
                            if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                            {
                                mat[Position.Line, Position.Column - 2] = true;
                            }
                        }
                    }

                    //#BigRock Black
                    Position PosT2 = new Position(Position.Line, Position.Column + 4);
                    if (Board.ValidPosition(PosT2))
                    {
                        if (TestTowerForRock(PosT2))
                        {
                            Position p1 = new Position(Position.Line, Position.Column + 1);
                            Position p2 = new Position(Position.Line, Position.Column + 2);
                            Position p3 = new Position(Position.Line, Position.Column + 3);
                            if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                            {
                                mat[Position.Line, Position.Column + 2] = true;
                            }
                        }
                    }
                }


            }
                return mat;
        }
    }
}
