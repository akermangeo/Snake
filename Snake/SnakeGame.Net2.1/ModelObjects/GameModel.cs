namespace SnakeGame.Net2._1.ModelObjects
{
    public struct GameModel
    {
        public GameModel(SquareStatus[,] position)
        {
            _position = position;
        }

        public SquareStatus[,] _position { get; }
    }
}
