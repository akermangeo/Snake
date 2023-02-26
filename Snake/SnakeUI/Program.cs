using System.Security.Cryptography.X509Certificates;
using SnakeGameLib;
using SnakeGameLib.ModelObjects;

namespace SnakeUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var mainForm = new Form1();
            SnakeUiController controller = new SnakeUiController(mainForm);
            SnakeGame snakeGame = new SnakeGame();
            SnakeGameAsyncService snakeGameAsyncService = new SnakeGameAsyncService(snakeGame);
            snakeGame.GamePositionUpdated += controller.GamePositionUpdatedhandler;
            Task runGameTask = snakeGameAsyncService.RunGameAsync();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.Run(mainForm);
            runGameTask.Wait();
        }
    }

    internal class SnakeUiController
    {
        private readonly Form1 _mainForm;

        public SnakeUiController(Form1 mainForm)
        {
            _mainForm = mainForm;
        }

        public void GamePositionUpdatedhandler(object? sender, GameModel eventArgs)
        {
            Bitmap bmp = new Bitmap(100, 100);
            for (int x = 0; x < 100; ++x)
            {
                for (int y = 0; y < 100; ++y)
                {
                    if (eventArgs._position[x, y] == SquareStatus.Filled)
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, Color.Red);
                    }
                }
            }

            _mainForm.DisplayGame(bmp);
            //using (Graphics graph = Graphics.FromImage(bmp))
            //{
            //    Rectangle ImageSize = new Rectangle(0, 0, x, y);
            //    graph.FillRectangle(Brushes.White, ImageSize);
            //}
            //return bmp;
        }
    }
}