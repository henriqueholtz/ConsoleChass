using System;
using board;

namespace chess
{
    class PositionChess
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public PositionChess(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPosition()
        {
            if (Line > 8 || ( Column != 'a' && Column != 'a' && Column != 'b' && Column != 'c' && Column != 'd' && Column != 'e' && Column != 'f' && Column != 'g' && Column != 'h') || Column == ' ')
            {
                throw new BoardException("Invalid position!");
            }
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
