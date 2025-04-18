using System;

namespace Connect_Four
{
    class AIPlayer : PlayerBase
    {
        private Random random = new Random();

        public AIPlayer(string name, char symbol) : base(name, symbol) { }

        public override int MakeMove(Board board)
        {
            int column;
            do
            {
                column = random.Next(0, Board.Columns);
            } while (!board.CanPlace(column));

            Console.WriteLine($"{Name} chooses column {column + 1}");
            return column;
        }
    }
}
