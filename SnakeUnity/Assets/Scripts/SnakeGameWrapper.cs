using SnakeGameLib;
using SnakeGameLib.ModelObjects;

internal class SnakeGameWrapper
{
    private SnakeGameAsyncService snakeGameAsyncService_;
    private SnakeGameWrapper(SnakeGameAsyncService snakeGameAsyncService)
    {
        snakeGameAsyncService_ = snakeGameAsyncService;
        snakeGameAsyncService.RunGameAsync();
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
            snake = snakeGameAsyncService_.GetSnake();
        } while (snake.Empty());

        return snake;
    }
}