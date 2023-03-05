namespace SnakeUI.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DisplayGame(Image game)
        {
            pictureBox1.Image = game;
        }
    }
}