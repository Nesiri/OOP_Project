using System;

namespace Connect_Four
{
    class AIPlayer :IPlayer
    {
        private Random random = new Random();
        public string Name { get; set; }

        public char Symbol { get; set; }

        public AIPlayer(string name, char symbol)  {
            Name = name;
            Symbol = symbol;
        
        }

        public  int MakeMove(Board board)
        {
            int column;
            do
            {
                column = random.Next(0, Board.Columns); // Chooses randomly from the columns
            } while (!board.CanPlace(column));

            Console.WriteLine($"{Name} chooses column {column + 1}");
            return column;
        }
    }
}
