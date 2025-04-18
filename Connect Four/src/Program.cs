using System;

namespace Connect_Four
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("==== Connect Four ====");
                Console.WriteLine("1. Human vs Human");
                Console.WriteLine("2. Human vs AI");
                Console.WriteLine("3. Exit");
                Console.Write("Select a mode: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Player 1's name: ");
                        string p1Name = Console.ReadLine();
                        Console.Write("Enter Player 2's name: ");
                        string p2Name = Console.ReadLine();
                        StartGame(new HumanPlayer(p1Name, 'X'), new HumanPlayer(p2Name, 'O'));
                        break;

                    case "2":
                        StartGame(new HumanPlayer("You", 'X'), new AIPlayer("Computer", 'O'));
                        break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }
            }
        }

        static void StartGame(IPlayer player1, IPlayer player2)
        {
            GameBase game = new GameBase(player1, player2);
            game.Play();
        }
    }
}
