using System.Drawing;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using SnakeGameLib.ModelObjects;

namespace SnakeGameLib
{
    public class SnakeGame
    {
        public event EventHandler<GameModel>? GamePositionUpdated;
        public event EventHandler? FailureDetected;
        private volatile bool _paused = false;
        private volatile string _direction = "Right";
        private Random _random = new Random();

        public void RunGame()
        {
            List<Point> food = new List<Point>();
            GamePosition position = new GamePosition();
            List<Point> snake = new List<Point>();
            Point snakePoint1 = GenerateRandomPointNoDuplicates(new List<Point>());
            Point snakePoint2 = position.GetLeftPoint(snakePoint1);
            Point snakePoint3 = position.GetLeftPoint(snakePoint2);

            snake.Add(snakePoint3);
            snake.Add(snakePoint2);
            snake.Add(snakePoint1);

            Point foodPoint = GenerateRandomPointNoDuplicates(snake);
            food.Add(foodPoint);

            position.Fill(foodPoint);

            position.Fill(snakePoint1);
            position.Fill(snakePoint2);
            position.Fill(snakePoint3);

            while (true)
            {
                if (!_paused)
                {
                    GamePositionUpdated?.Invoke(this, position.GetGameModel());
                    Thread.Sleep(100);

                    Point lastPoint = snake.First();
                    if (food.Contains(lastPoint))
                    {
                        food.Remove(lastPoint);
                    }
                    else
                    {
                        snake.RemoveAt(0);
                        position.Unfill(lastPoint);
                    }

                    Point firstPoint = snake.Last();

                    Point point_to_fill = default;
                    
                    if (_direction == "Left")
                    {
                        point_to_fill = position.GetLeftPoint(firstPoint);
                    }

                    if (_direction == "Right")
                    {
                        point_to_fill = position.GetRightPoint(firstPoint);
                    }

                    if (_direction == "Down")
                    {
                        point_to_fill = position.GetDownPoint(firstPoint);
                    }

                    if (_direction == "Up")
                    {
                        point_to_fill = position.GetUpPoint(firstPoint);
                    }
                    if (snake.Contains(point_to_fill))
                    {
                        FailureDetected?.Invoke(this, EventArgs.Empty);
                    }
                    if (food.Contains(point_to_fill))
                    {
                        Point newFood = GenerateRandomPointNoDuplicates(snake);
                        food.Add(newFood);
                        position.Fill(newFood);
                    }

                    position.Fill(point_to_fill);
                    snake.Add(point_to_fill);

                }
            }
        }

        private Point GenerateRandomPointNoDuplicates(List<Point> duplicates)
        {
            int randomX = _random.Next(100);
            int randomY = _random.Next(100);
            Point point = new Point(randomX, randomY);
            if (duplicates.Contains(point))
            {
                return GenerateRandomPointNoDuplicates(duplicates);
            }
            return point;
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