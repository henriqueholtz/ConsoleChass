using System;

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

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
