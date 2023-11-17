using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SnakeGameLib.ModelObjects;

public class Snake
{
    private static readonly object SnakeLock_ = new object();
    private List<Point> snakePoints_ = new List<Point>();

    public Snake()
    {
    }

    public Snake(List<Point> snakePoints)
    {
        this.snakePoints_ = snakePoints;
    }

    public Snake GetCopy()
    {
        lock (SnakeLock_)
        {
            return new Snake(snakePoints_);
        }
    }

    public void Add(Point snakePoint)
    {
        lock (SnakeLock_)
        {
            snakePoints_.Add(snakePoint);
        }
    }

    public List<Point> GetSnakePoints()
    {
        lock (SnakeLock_)
        {
            return snakePoints_;
        }
    }

    public Point Last()
    {
        lock (SnakeLock_)
        {
            return snakePoints_.First();
        }
    }

    public Point Head()
    {
        lock (SnakeLock_)
        {
            return snakePoints_.Last();
        }
    }

    public void RemoveLast()
    {
        lock (SnakeLock_)
        {
            snakePoints_.RemoveAt(0);
        }
    }

    public bool Contains(Point point)
    {
        lock (SnakeLock_)
        {
            return snakePoints_.Contains(point);
        }
    }

    public bool Empty()
    {
        lock (SnakeLock_)
        {
            return !snakePoints_.Any();
        }
    }
}