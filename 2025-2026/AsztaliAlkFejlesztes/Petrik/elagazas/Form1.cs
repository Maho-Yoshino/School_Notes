namespace elagazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isCircle = radioButton1.Checked;
            if (!double.TryParse(textBox1.Text, out double sideLength))
            {
                MessageBox.Show("Kérem, érvényes számot adjon meg az oldalhosszhoz!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isCircle)
            {
                double k = 4 * sideLength;
                double t = 
                label2.Text = $"A kör kerülete: {k}";
            }
            else
            {
                double area = sideLength * sideLength;
                label2.Text = $"A négyzet területe: {area}";
            }
        }
    }
}
