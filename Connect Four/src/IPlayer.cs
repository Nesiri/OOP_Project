namespace Connect_Four
{
    internal interface IPlayer
    {
        string Name { get; }
        char Symbol { get; }

        int MakeMove(Board board);
    }
}