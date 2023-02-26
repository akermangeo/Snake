using System.Drawing;
using SnakeGameLib.ModelObjects;

namespace SnakeGameLib
{
    public class SnakeGame
    {
        public event EventHandler<GameModel> GamePositionUpdated;
        private bool _paused = false;

        public void RunGame()
        {
            Random random = new Random();
            GamePosition position = new GamePosition();
            int random_x = random.Next(100);
            int random_y = random.Next(100);
            var currentPoint = new Point(random_x, random_y);
            while (true)
            {
                if (!_paused)
                {
                    position.Fill(currentPoint);
                    GamePositionUpdated?.Invoke(this, position.GetGameModel());
                    Thread.Sleep(1000);
                    position.Unfill(currentPoint);
                    currentPoint = position.GetLeftPoint(currentPoint);
                }
            }
        }

        public void TogglePause()
        {
            _paused = !_paused;
        }
    }
}