namespace SnakeGameLib.ModelObjects
{
    public struct GameModel
    {
        public GameModel(SquareStatus[,] position)
        {
            _position = position;
        }

        private SquareStatus[,] _position;
    }
}
