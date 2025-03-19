using System;

namespace Connect_Four
{
    // Base class for the game
    class GameBase
    {
        protected Board board;
        protected PlayerBase[] players;
        protected int currentPlayerIndex;

        public GameBase()
        {
            board = new Board();
            players = new PlayerBase[2]; // Two players
            currentPlayerIndex = 0;
        }

        public void Play();
        protected void SwitchPlayer()
        {
            currentPlayerIndex = 1 - currentPlayerIndex;
        }
    }

    // Connect 4 game inherits from GameBase
    class Connect4Game : GameBase
    {
        public override void Play()
        {
            // Game logic (handling turns, checking win conditions, etc.)
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

        public  int MakeMove();
    }

    // Human player subclass
    class HumanPlayer : PlayerBase
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) {
        
        
        }

        public override int MakeMove()
        {
            // Take input from the user
            return 0;
        }
    }

    // AI player subclass (Optional)
    class AIPlayer : PlayerBase
    {
        public AIPlayer(string name, char symbol) : base(name, symbol) {
        
        
        }

        public override int MakeMove()
        {
            // Implement AI logic (Optional)
            return 0;
        }
    }

    // Board class (Manages grid, dropping pieces, checking win conditions)
    class Board
    {
        // Board logic
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nesru");

        }
    }
}
