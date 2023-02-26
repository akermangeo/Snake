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

    private SquareStatus[,] _position;

    public void Fill(int randomX, int randomY)
    {
        _position[randomX, randomY] = SquareStatus.Filled;
    }

    public void Unfill(int randomX, int randomY)
    {
        _position[randomX, randomY] = SquareStatus.Unfilled;
    }
}