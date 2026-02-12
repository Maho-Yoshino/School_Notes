namespace ciklus1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mainBtn_Click(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width-this.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height-this.Height;
            while (this.Left < screenWidth)
            {
                this.Left++;
            }
            while (this.Top < screenHeight)
            {
                this.Top++;
            }
            while (this.Left > 0)
            {
                this.Left--;
            }
            while (this.Top > 0)
            {
                this.Top--;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
        }
    }
}
