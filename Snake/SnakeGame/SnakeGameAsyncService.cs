using SnakeGameLib.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameLib
{
    public class SnakeGameAsyncService
    {
        public event EventHandler<GameModel> GamePositionUpdated;
        private SnakeGame _snakeGame;

        public SnakeGameAsyncService(SnakeGame snakeGame)
        {
            _snakeGame = snakeGame;
            snakeGame.GamePositionUpdated += GamePositionUpdatedhandler;
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
