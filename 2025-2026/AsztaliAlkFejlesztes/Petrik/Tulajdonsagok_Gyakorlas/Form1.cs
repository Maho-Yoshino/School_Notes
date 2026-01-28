namespace Tulajdonsagok_Gyakorlas
{
    public partial class Form_Gyakorlas : Form
    {
        public Form_Gyakorlas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.CornflowerBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Size = new Size(100, 50);
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            label1.Location = new Point(10, 10);
            label1.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size + 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size + 2);
            label1.Size = new Size(label1.Size.Width + 10, label1.Size.Height + 10);
        }
    }
}
