using SnakeGameLib;
using SnakeGameLib.ModelObjects;

namespace SnakeUI
{
    internal static class Program
    {
        private SnakeUiController _controller;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var mainForm = new Form1();
            _controller = new SnakeUiController(mainForm);
            SnakeGame snakeGame = new SnakeGame();
            SnakeGameAsyncService snakeGameAsyncService = new SnakeGameAsyncService(snakeGame);
            snakeGame.GamePositionUpdated += GamePositionUpdatedhandler();
            Task runGameTask = snakeGameAsyncService.RunGameAsync();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run();
            runGameTask.Wait();
        }

        private static EventHandler<GameModel> GamePositionUpdatedhandler()
        {
            throw new NotImplementedException();
        }
    }

    internal class SnakeUiController
    {
        public SnakeUiController(Form1 mainForm)
        {
            throw new NotImplementedException();
        }
    }
}