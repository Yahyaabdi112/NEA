namespace gameUI
{
    public partial class Form1 : Form
    {
        public Rectangle buttonOriginalRectangle;
        private Rectangle originalFormSize;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            GameWindow window = new GameWindow();
            window.Show();
            this.Hide();
        }

        private void btntutorial_Click(object sender, EventArgs e)
        {
            TutorialWindow window = new TutorialWindow();
            window.Show();
            this.Hide();
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            
            this.Size = new Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));

            this.Location = new Point(10, 10);

        }



        private void Form1_Resize(object sender, EventArgs e)
        {



        }

        private void btnplay_Click_1(object sender, EventArgs e)
        {
            GameWindow window = new GameWindow();
            window.Show();
            this.Hide();
        }
    }
}
