using System;

namespace Connect_Four
{
	// Board class - Logic for the grid, win check, display, etc. - NOTE: { I made some minor adjustments here for parity with the other stuff I added }
	class Board
	{
		public const int Rows = 6;
		public const int Columns = 7;
		private char[,] grid;

		public Board()
		{
			grid = new char[Rows, Columns];
			Clear();
		}

		public void Clear() // Clear the board
		{
			for (int r = 0; r < Rows; r++)
				for (int c = 0; c < Columns; c++)
					grid[r, c] = '.';
		}

		public void Display() // Display the board
		{
			Console.Clear();
			Console.WriteLine(" 1 2 3 4 5 6 7 ");
			for (int r = 0; r < Rows; r++)
			{
				for (int c = 0; c < Columns; c++)
				{
					Console.Write($" {grid[r, c]}");
				}
				Console.WriteLine();
			}
		}

		public bool CanPlace(int column)
		{
			return grid[0, column] == '.';
		}

		public bool DropPiece(int column, char symbol)
		{
			if (!CanPlace(column)) return false; // Invalid Column

			for (int row = Rows - 1; row >= 0; row--)
			{
				if (grid[row, column] == '.')
				{
					grid[row, column] = symbol;
					return true;
				}
			}
			return false;
		}

		public bool IsFull()
		{
			for (int c = 0; c < Columns; c++)
				if (grid[0, c] == '.')
					return false;
			return true;
		}

		public bool CheckWin(char symbol)
		{
			// Check horizontal
			for (int r = 0; r < Rows; r++)
				for (int c = 0; c <= Columns - 4; c++)
					if (grid[r, c] == symbol && grid[r, c + 1] == symbol &&
						grid[r, c + 2] == symbol && grid[r, c + 3] == symbol)
						return true;

			// Check vertical
			for (int c = 0; c < Columns; c++)
				for (int r = 0; r <= Rows - 4; r++)
					if (grid[r, c] == symbol && grid[r + 1, c] == symbol &&
						grid[r + 2, c] == symbol && grid[r + 3, c] == symbol)
						return true;

			// Check diagonal (/)
			for (int r = 3; r < Rows; r++)
				for (int c = 0; c <= Columns - 4; c++)
					if (grid[r, c] == symbol && grid[r - 1, c + 1] == symbol &&
						grid[r - 2, c + 2] == symbol && grid[r - 3, c + 3] == symbol)
						return true;

			// Check diagonal (\)
			for (int r = 0; r <= Rows - 4; r++)
				for (int c = 0; c <= Columns - 4; c++)
					if (grid[r, c] == symbol && grid[r + 1, c + 1] == symbol &&
						grid[r + 2, c + 2] == symbol && grid[r + 3, c + 3] == symbol)
						return true;

			return false; // If no win found
		}
	}
}