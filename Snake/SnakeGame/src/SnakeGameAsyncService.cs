using System;
using System.Drawing;
using System.Threading.Tasks;
using SnakeGameLib.ModelObjects;

namespace SnakeGameLib
{
    public class SnakeGameAsyncService
    {
        public event EventHandler<GameModel> GamePositionUpdated;
        public event EventHandler<Point> NewFoodPoint;
        public event EventHandler<Point> NewHeadPoint;
        public event EventHandler FailureDetected;
        private SnakeGame _snakeGame;

        public SnakeGameAsyncService(SnakeGame snakeGame)
        {
            _snakeGame = snakeGame;
            snakeGame.GamePositionUpdated += GamePositionUpdatedhandler;
            snakeGame.FailureDetected += FailureDetectedHandler;
            snakeGame.NewFoodPoint += SnakeGameOnNewFoodPoint;
            snakeGame.NewHeadPoint += SnakeGameOnNewHeadPoint;
        }

        private void SnakeGameOnNewHeadPoint(object sender, Point e)
        {
            NewHeadPoint?.Invoke(this, e);
        }

        private void SnakeGameOnNewFoodPoint(object sender, Point e)
        {
            NewFoodPoint?.Invoke(this, e);
        }

        private void FailureDetectedHandler(object? sender, EventArgs e)
        {
            FailureDetected?.Invoke(this, EventArgs.Empty);
        }

        public Task RunGameAsync()
        {
            return Task.Run(() => _snakeGame.RunGame());
        }

        private void GamePositionUpdatedhandler(object? sender, GameModel e)
        {
            GamePositionUpdated?.Invoke(this, e);
        }

        public void TogglePause()
        {
            _snakeGame.TogglePause();
        }

        public void ChangeDirection(Direction direction)
        {
            _snakeGame.ChangeDirection(direction);
        }

        public Snake GetSnake()
        {
            return _snakeGame.GetSnake();
        }
    }
}
