using System;
using System.Drawing;
using SnakeGameLib.ModelObjects;

namespace SnakeGameLib;

public class GamePosition
{
    public GamePosition()
    {
        _position = new SquareStatus[100, 100];
        for (int x = 0; x < 100; ++x)
        {
            for (int y = 0; y < 100; ++y)
            {
                _position[x, y] = SquareStatus.Empty;
            }
        }
    }

    public GameModel GetGameModel()
    {
        return new GameModel(_position);
    }

    private readonly SquareStatus[,] _position;

    public Point GetPoint(Point currentPoint, Direction direction)
    {
        return direction switch
        {
            Direction.Left => GetLeftPoint(currentPoint),
            Direction.Right => GetRightPoint(currentPoint),
            Direction.Up => GetUpPoint(currentPoint),
            Direction.Down => GetDownPoint(currentPoint),
            _ => throw new ArgumentException("That direction is not supported.")
        };
    }

    public Point GetLeftPoint(Point currentPoint)
    {
        int newX = (currentPoint.X + 99) % 100;
        return currentPoint with { X = newX };
    }

    public Point GetDownPoint(Point currentPoint)
    {
        int X = currentPoint.X;
        int Y = currentPoint.Y;
        Y = Y + 1;
        if (Y == 100)
        {
            Y = 0;
        }
        Point newpoint = new Point(X, Y);
        return newpoint;
    }

    public Point GetRightPoint(Point currentPoint)
    {
        int newX = (currentPoint.X + 1) % 100;
        return currentPoint with { X = newX };
    }

    public Point GetUpPoint(Point currentPoint)
    {
        int X = currentPoint.X;
        int Y = currentPoint.Y;
        Y = Y - 1;
        if (Y == -1)
        {
            Y = 99;
        }
        Point newpoint = new Point(X, Y);
        return newpoint;
    }

    public void Food(Point point)
    {

        _position[point.X, point.Y] = SquareStatus.Food;
    }

    public void Head(Point point)
    {
        _position[point.X, point.Y] = SquareStatus.Head;
    }

    public void Body(Point point)
    {
        _position[point.X, point.Y] = SquareStatus.Body;
    }

    public void Empty(Point point)
    {
        _position[point.X, point.Y] = SquareStatus.Empty;
    }
}