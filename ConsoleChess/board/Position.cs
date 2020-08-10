
namespace board //Tabuleiro
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public void SetValues(int line, int column)
        {
            //if (line >= 0 && line <= 7 && Column >= 0 && Column <= 7)
            //{
                Line = line;
                Column = column;
            //}
            //não precisa lançar exceção
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}
