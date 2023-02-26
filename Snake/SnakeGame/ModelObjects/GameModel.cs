namespace SnakeGameLib.ModelObjects
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
