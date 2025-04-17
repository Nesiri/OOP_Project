using System;

// Team: Softwerewolves                        - This is terrible I know
// Developers: Nesru Abbamilki, Ollie Howes

namespace Connect_Four
{
    // Final game setup - entry point
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
                        Console.WriteLine("Enter Player 1's name: ");
                        string p1Name = Console.ReadLine();
                        Console.WriteLine("Enter Player 2's name: ");
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

        static void StartGame(PlayerBase player1, PlayerBase player2)
        {
            GameBase game = new GameBase(player1, player2);
            game.Play();
        }
    }
}
