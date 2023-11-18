using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using SnakeGameLib.ModelObjects;

namespace SnakeGameLib
{
    public class SnakeGame
    {
        public event EventHandler<GameModel>? GamePositionUpdated;
        public event EventHandler<Point>? NewFoodPoint;
        public event EventHandler<Point>? NewHeadPoint;
        public event EventHandler? FailureDetected;
        private volatile bool _paused = false;
        private volatile string _direction = "Right";
        private Random _random = new Random();

        private Snake snake_ = new Snake();

        public void RunGame()
        {
            List<Point> food = new List<Point>();
            GamePosition position = new GamePosition();
            Point snakePoint1 = GenerateRandomPointNoDuplicates(new List<Point>());
            Point snakePoint2 = position.GetLeftPoint(snakePoint1);
            Point snakePoint3 = position.GetLeftPoint(snakePoint2);

            snake_.Add(snakePoint3);
            snake_.Add(snakePoint2);
            snake_.Add(snakePoint1);

            Point foodPoint = GenerateFoodPoint(snake_.GetSnakePoints());
            food.Add(foodPoint);

            AddFoodPoint(position, foodPoint);

            position.Head(snakePoint1);
            position.Body(snakePoint2);
            position.Body(snakePoint3);

            while (true)
            {
                if (!_paused)
                {
                    GamePositionUpdated?.Invoke(this, position.GetGameModel());
                    Thread.Sleep(100);

                    Point lastPoint = snake_.Last();
                    if (food.Contains(lastPoint))
                    {
                        food.Remove(lastPoint);
                        position.Body(lastPoint);
                    }
                    else
                    {
                        snake_.RemoveLast();
                        position.Empty(lastPoint);
                    }

                    Point firstPoint = snake_.Head();

                    Point pointToFill = default;
                    
                    if (_direction == "Left")
                    {
                        pointToFill = position.GetLeftPoint(firstPoint);
                    }

                    if (_direction == "Right")
                    {
                        pointToFill = position.GetRightPoint(firstPoint);
                    }

                    if (_direction == "Down")
                    {
                        pointToFill = position.GetDownPoint(firstPoint);
                    }

                    if (_direction == "Up")
                    {
                        pointToFill = position.GetUpPoint(firstPoint);
                    }
                    if (snake_.Contains(pointToFill))
                    {
                        FailureDetected?.Invoke(this, EventArgs.Empty);
                    }
                    if (food.Contains(pointToFill))
                    {
                        Point newFood = GenerateFoodPoint(snake_.GetSnakePoints());
                        food.Add(newFood);
                        AddFoodPoint(position, newFood);
                    }
                   
                    position.Body(firstPoint);
                    NewHead(position, pointToFill);
                    snake_.Add(pointToFill);

                }
            }
        }

        private void NewHead(GamePosition position, Point point)
        {
            position.Head(point);
            NewHeadPoint?.Invoke(this, point);
        }

        private void AddFoodPoint(GamePosition position, Point foodPoint)
        {
            position.Food(foodPoint);
            NewFoodPoint?.Invoke(this, foodPoint);
        }

        private Point GenerateFoodPoint(List<Point> snake)
        {
            Point foodPoint = GenerateRandomPointNoDuplicates(snake);
            while (IsPointOnBoundary(foodPoint))
            {
                foodPoint = GenerateRandomPointNoDuplicates(snake);
            }

            return foodPoint;
        }

        private static bool IsPointOnBoundary(Point point)
        {
            return point.X == 0 || point.Y == 0 || point.X == 99 || point.Y == 99;
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

        public Snake GetSnake()
        {
            return snake_.GetCopy();
        }
    }
}