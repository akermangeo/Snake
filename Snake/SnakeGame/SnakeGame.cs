using SnakeGameLib.ModelObjects;

namespace SnakeGameLib
{
    public class SnakeGame
    {
        public event EventHandler<GameModel> GamePositionUpdated;

        public void RunGame()
        {
            Random random = new Random();
            GamePosition position = new GamePosition();
            while (true)
            {
                int random_x = random.Next(100);
                int random_y = random.Next(100);
                position.Fill(random_x, random_y);
                GamePositionUpdated?.Invoke(this, position.GetGameModel());
                Thread.Sleep(1000);
                position.Unfill(random_x, random_y);
            }
        }
    }
}