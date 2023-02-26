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
                _position[x, y] = SquareStatus.Unfilled;
            }
        }
    }

    public GameModel GetGameModel()
    {
        return new GameModel(_position);
    }

    private readonly SquareStatus[,] _position;

    public void Fill(Point point)
    {
        _position[point.X, point.Y] = SquareStatus.Filled;
    }

    public void Unfill(Point point)
    {
        _position[point.X, point.Y] = SquareStatus.Unfilled;
    }

    public Point GetLeftPoint(Point currentPoint)
    {
        
        int newX = (currentPoint.X + 99) % 100;
        return currentPoint with { X = newX };
    }
}