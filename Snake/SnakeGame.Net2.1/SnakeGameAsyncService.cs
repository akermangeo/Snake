using System;
using System.Threading.Tasks;
using SnakeGame.Net2._1.ModelObjects;

namespace SnakeGame.Net2._1
{
    public class SnakeGameAsyncService
    {
        public event EventHandler<GameModel> GamePositionUpdated;
        public event EventHandler FailureDetected;
        private SnakeGame _snakeGame;

        public SnakeGameAsyncService(SnakeGame snakeGame)
        {
            _snakeGame = snakeGame;
            snakeGame.GamePositionUpdated += GamePositionUpdatedhandler;
            snakeGame.FailureDetected += FailureDetectedHandler;
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

        public void GoLeft()
        {
            _snakeGame.GoLeft();
        }

        public void GoRight()
        {
            _snakeGame.GoRight();
        }

        public void GoUp()
        {
            _snakeGame.GoUp();
        }

        public void GoDown()
        { 
            _snakeGame.GoDown();
        }
    }
}
