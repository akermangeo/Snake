namespace SnakeUI
{
    public partial class Form1 : Form
    {
        internal event EventHandler<KeyEventArgs> KeyDownInGame;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void DisplayGame(Image game)
        {
            pictureBox1.Image = game;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownInGame?.Invoke(this, e);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    KeyDown?.Invoke(this, new KeyEventArgs(keyData));
        //    // Handle key at form level.
        //    // Do not send event to focused control by returning true.
        //    return true;
        //}
    }
}