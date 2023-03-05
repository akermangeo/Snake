using System.Drawing;
using SnakeGameLib.ModelObjects;

namespace SnakeGameLib
{
    public class SnakeGame
    {
        public event EventHandler<GameModel>? GamePositionUpdated;
        private volatile bool _paused = false;
        private volatile string _direction = "Right";

        public void RunGame()
        {
            Random random = new Random();
            GamePosition position = new GamePosition();
            int randomX = random.Next(100);
            int randomY = random.Next(100);
            Point currentPoint = new Point(randomX, randomY);
            while (true)
            {
                if (!_paused)
                {
                    position.Fill(currentPoint);
                    GamePositionUpdated?.Invoke(this, position.GetGameModel());
                    Thread.Sleep(1000);
                    position.Unfill(currentPoint);
                    if (_direction == "Left")
                    {
                        currentPoint = position.GetLeftPoint(currentPoint);
                    }

                    if (_direction == "Right")
                    {
                        currentPoint = position.GetRightPoint(currentPoint);
                    }

                    if (_direction == "Down")
                    {
                        currentPoint = position.GetDownPoint(currentPoint);
                    }

                    if (_direction == "Up")
                    {
                        currentPoint = position.GetUpPoint(currentPoint);
                    }

                }
            }
        }

        public void TogglePause()
        {
            _paused = !_paused;
        }

        public void GoLeft()
        {
            _direction = "Left";
        }

        public void GoRight()
        {
            _direction = "Right";
        }

        public void GoUp()
        {
            _direction = "Up";
        }

        public void GoDown()
        {
            _direction = "Down";
        }
    }
}