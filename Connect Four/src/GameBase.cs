using System;

namespace Connect_Four
{
    // Game controller base
    class GameBase
    {
        protected Board board;
        protected IPlayer[] players;
        protected int currentPlayerIndex;

        public GameBase(IPlayer player1, IPlayer player2)
        {
            board = new Board();
            players = new IPlayer[] { player1, player2 }; // Use interface
            currentPlayerIndex = 0;
        }

        public virtual void Play() // Play can be overridden if needed
        {
            bool gameWon = false;
            bool isDraw = false;

            while (!gameWon && !isDraw)
            {
                board.Display();

                var currentPlayer = players[currentPlayerIndex];

                if (currentPlayer.Name == "You") // Singleplayer message
                {
                    Console.WriteLine($"Your turn ({currentPlayer.Symbol}):");
                }
                else // Multiplayer message
                {
                    Console.WriteLine($"{currentPlayer.Name}'s turn ({currentPlayer.Symbol}):");
                }

                int column = currentPlayer.MakeMove(board);

                if (board.DropPiece(column, currentPlayer.Symbol))
                {
                    gameWon = board.CheckWin(currentPlayer.Symbol);
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
            else if (isDraw)
            {
                Console.WriteLine("It's a draw!");
            }

            Console.WriteLine("Game Over! \n\nReturning to main menu...");
        }

        protected void SwitchPlayer()
        {
            currentPlayerIndex = 1 - currentPlayerIndex;
        }
    }
}
