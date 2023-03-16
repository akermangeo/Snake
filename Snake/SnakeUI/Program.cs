using System.Security.Cryptography.X509Certificates;
using SnakeGameLib;
using SnakeGameLib.ModelObjects;
using SnakeUI.Forms;

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
            
            SnakeGame snakeGame = new SnakeGame();
            SnakeGameAsyncService snakeGameAsyncService = new SnakeGameAsyncService(snakeGame);

            SnakeUiController controller = new SnakeUiController(mainForm, snakeGameAsyncService);
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
        private readonly SnakeGameAsyncService _snakeGameAsyncService;

        public SnakeUiController(Form1 mainForm, SnakeGameAsyncService snakeGameAsyncService)
        {
            _snakeGameAsyncService = snakeGameAsyncService;
            _snakeGameAsyncService.GamePositionUpdated += GamePositionUpdatedhandler;
            _snakeGameAsyncService.FailureDetected += FailureDetectedHandler;
            _mainForm = mainForm;
            _mainForm.KeyDown += KeyPressed;
        }

        private void FailureDetectedHandler(object? sender, EventArgs e)
        {
            MessageBox.Show("You lose");
        }

        private void KeyPressed(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _snakeGameAsyncService.TogglePause();
            }

            if (e.KeyCode == Keys.Left)
            {
                _snakeGameAsyncService.GoLeft();
            }

            if (e.KeyCode == Keys.Right)
            {
                _snakeGameAsyncService.GoRight();
            }

            if (e.KeyCode == Keys.Up)
            {
                _snakeGameAsyncService.GoUp();
            }

            if (e.KeyCode == Keys.Down)
            {
                _snakeGameAsyncService.GoDown();
            }








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
        }
    }
}