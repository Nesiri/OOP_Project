using System;

namespace Connect_Four
{
    // Game controller base
    class GameBase
    {
        protected Board board;
        protected PlayerBase[] players;
        protected int currentPlayerIndex;

        public GameBase(PlayerBase player1, PlayerBase player2)
        {
            board = new Board();
            players = new PlayerBase[] { player1, player2 }; // Assign players
            currentPlayerIndex = 0;
        }

        public virtual void Play() // Play can be overridden if needed
        {
            bool gameWon = false;
            bool isDraw = false;

            while (!gameWon && !isDraw)
            {
                board.Display();
                if (players[currentPlayerIndex].Name == "You") // Singleplayer message
                {
                    Console.WriteLine($"Your turn ({players[currentPlayerIndex].Symbol}):");
                }
                else // Multiplayer Message
                {
                    Console.WriteLine($"{players[currentPlayerIndex].Name}'s turn ({players[currentPlayerIndex].Symbol}):");
                }
                int column = players[currentPlayerIndex].MakeMove(board);
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
                if (players[currentPlayerIndex].Name == "You")
                {
                    Console.WriteLine($"{players[currentPlayerIndex].Name} win!");
                }
                else
                {
                    Console.WriteLine($"{players[currentPlayerIndex].Name} wins!");
                }
            else if (isDraw)
                Console.WriteLine("It's a draw!");

            Console.WriteLine("Game Over! Returning to main menu...");
        }

        protected void SwitchPlayer()
        {
            currentPlayerIndex = 1 - currentPlayerIndex;
        }
    }
}