using System;

namespace Connect_Four
{
    class HumanPlayer : PlayerBase
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        public override int MakeMove(Board board)
        {
            int column = -1;
            bool valid = false;

            while (!valid)
            {
                Console.Write($"{Name}, enter column (1-7): ");
                try
                {
                    string input = Console.ReadLine();
                    column = int.Parse(input) - 1; // Convert to 0-based index

                    if (column < 0 || column >= Board.Columns)
                    {
                        Console.WriteLine("Invalid column. Choose a number between 1 and 7.");
                    }
                    else if (!board.CanPlace(column))
                    {
                        Console.WriteLine("That column is full. Choose another one.");
                    }
                    else
                    {
                        valid = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 7.");
                }
            }

            return column;
        }
    }
}
