using System;

namespace Connect_Four
{
    // Base class for the game
    class GameBase
    {
        protected Board board;
        protected PlayerBase[] players;
        protected int currentPlayerIndex;

        public GameBase(PlayerBase player1, PlayerBase player2)
        {
            board = new Board();
            players = new PlayerBase[2]; // Two players
            players[0] = player1;
            players[1] = player2;
            currentPlayerIndex = 0;
        }

        // Make Play virtual so it can be overridden
        public virtual void Play()
        {
            bool gameWon = false;
            bool isDraw = false;

            while (!gameWon && !isDraw)
            {
                board.Display();
                Console.WriteLine($"{players[currentPlayerIndex].Name}'s turn:");

                int column = players[currentPlayerIndex].MakeMove();
                if (board.DropPiece(column, players[currentPlayerIndex].Symbol))
                {
                    gameWon = board.CheckWin(players[currentPlayerIndex].Symbol);
                    isDraw = board.IsFull();
                    if (!gameWon && !isDraw)
                    {
                        SwitchPlayer();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }

            board.Display();
            if (gameWon)
            {
                Console.WriteLine($"{players[currentPlayerIndex].Name} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        protected void SwitchPlayer()
        {
            currentPlayerIndex = 1 - currentPlayerIndex;
        }
    }

    // Connect 4 game inherits from GameBase
    class Connect4Game : GameBase
    {
        public Connect4Game(PlayerBase player1, PlayerBase player2) : base(player1, player2) { }

        public override void Play()
        {
            Console.WriteLine("Starting Connect 4 Game...");
            base.Play();
        }
    }

    // Base class for players
    class PlayerBase
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public PlayerBase(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public virtual  int MakeMove()
        {
            return 1;
        }
    }

    // Human player subclass
    class HumanPlayer : PlayerBase
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        public override int MakeMove()
        {
            int column;
            while (true)
            {
                Console.Write("Enter column (0-6): ");
                column = int.Parse(Console.ReadLine());

                if (column >= 0 && column <= 6)
                {
                    // Valid input
                    Console.WriteLine($"You entered column {column}");
                }
                else
                {
                    // Invalid input
                    Console.WriteLine("Invalid column. Please enter a number between 0 and 6.");
                }

            }
        }
    }

    // Board class (Manages grid, dropping pieces, checking win conditions)
    class Board
    {
        public char[,] grid;
        private const int Rows = 6;
        private const int Cols = 7;

        public Board()
        {
            grid = new char[Rows, Cols];
            ClearBoard();
        }

        public void ClearBoard()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    grid[i, j] = '.';
        }

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("0 1 2 3 4 5 6");
        }

        public bool DropPiece(int col, char symbol)
        {
            if (col < 0 || col >= Cols) return false;

            for (int row = Rows - 1; row >= 0; row--)
            {
                if (grid[row, col] == '.')
                {
                    grid[row, col] = symbol;
                    return true;
                }
            }
            return false;  // Column full
        }

        public bool CheckWin(char symbol)
        {
           

            return false;
        }

        public bool IsFull()
        {
           
            return true;
        }

        public bool IsColumnOpen(int col)
        {
            return grid[0, col] == '.';
        }

        public int GetNextOpenRow(int col)
        {
            
            return -1; 
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string ans;
            do
            {
                Console.WriteLine("Starting Connect 4 Game...");

                // Create two human players
                PlayerBase player1 = new HumanPlayer("Player 1", 'X');
                PlayerBase player2 = new HumanPlayer("Player 2", 'O');

                // Start the game
                Connect4Game game = new Connect4Game(player1, player2);
                game.Play();

                // Ask if the players want to play again
                Console.WriteLine("Play Again? (yes/no)");
                ans = Console.ReadLine().ToLower().Trim();
            } while (ans == "yes");
        }
    }
}