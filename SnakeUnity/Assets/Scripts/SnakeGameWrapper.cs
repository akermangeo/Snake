using System.Drawing;
using SnakeGameLib;
using SnakeGameLib.ModelObjects;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.UIElements;

public class SnakeGameWrapper
{
    private SnakeGameAsyncService _snakeGameAsyncService;

    private static readonly object GameModelLock = new object();
    private GameModel _gameModel;

    private static readonly object FoodPointLock = new object();
    private Point _foodPoint;
    private volatile bool _newFoodPoint = false;

    private SnakeGameWrapper(SnakeGameAsyncService snakeGameAsyncService)
    {
        _snakeGameAsyncService = snakeGameAsyncService;
        snakeGameAsyncService.RunGameAsync();
        snakeGameAsyncService.GamePositionUpdated += SnakeGameAsyncServiceOnGamePositionUpdated;
        snakeGameAsyncService.NewFoodPoint += SnakeGameAsyncServiceOnNewFoodPoint;
    }

    private void SnakeGameAsyncServiceOnNewFoodPoint(object sender, Point e)
    {
        lock (FoodPointLock)
        {
            _foodPoint = e;
            _newFoodPoint = true;
        }
    }

    private void SnakeGameAsyncServiceOnGamePositionUpdated(object sender, GameModel e)
    {
        lock (GameModelLock)
        {
            _gameModel = e;
        }
    }

    public static SnakeGameWrapper Create()
    {
        return new SnakeGameWrapper(new SnakeGameAsyncService(new SnakeGame()));

    }

    public Snake GetSnake()
    {
        Snake snake;
        do
        {
            snake = _snakeGameAsyncService.GetSnake();
        } while (snake.Empty());

        return snake;
    }

    public bool IsEmpty(Point point)
    {
        lock (GameModelLock)
        {
            return _gameModel._position[point.X, point.Y] == SquareStatus.Empty;
        }
    }

    public bool HasNewFoodPoint()
    {
        return _newFoodPoint;
    }

    public Point GetFoodPoint()
    {
        lock (FoodPointLock)
        {
            _newFoodPoint = false;
            return _foodPoint;
        }
    }
}