using System;

namespace Connect_Four
{
	// Abstract Player class - Forces all player types to implement MakeMove()
	abstract class PlayerBase
	{
		public string Name { get; }
		public char Symbol { get; }

		protected PlayerBase(string name, char symbol)
		{
			Name = name;
			Symbol = symbol;
		}

		public abstract int MakeMove(Board board);
	}
}