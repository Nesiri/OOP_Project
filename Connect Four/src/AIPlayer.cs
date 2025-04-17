using System;

namespace Connect_Four
{
    // AI player - Random moves
    class AIPlayer : PlayerBase
    {
        private Random random;

        public AIPlayer(string name, char symbol) : base(name, symbol)
        {
            random = new Random();
        }

        public override int MakeMove(Board board)
        {
            int column;
            do
            {
                column = random.Next(0, Board.Columns); // Chooses randomly from the columns
            } while (!board.CanPlace(column));

            Console.WriteLine($"{Name} (AI) chooses column {column + 1}");
            return column;
        }
    }
}