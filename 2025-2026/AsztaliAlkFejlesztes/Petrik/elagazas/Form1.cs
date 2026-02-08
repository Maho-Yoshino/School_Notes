namespace elagazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            bool isCircle = isCircleBtn.Checked;
            if (!double.TryParse(mainInput.Text, out double sideLength))
            {
                MessageBox.Show("Kérem, érvényes számot adjon meg az oldalhosszhoz!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isCircle)
            {
                double k = 2*sideLength*Math.PI;
                double t = sideLength*sideLength*Math.PI;
                kerLabel.Text = $"A kör kerülete: {k}";
                terLabel.Text = $"A kör területe: {t}";
            }
            else
            {
                double t = sideLength * sideLength;
                double k = 4 * sideLength;
                terLabel.Text = $"A négyzet területe: {t}";
                kerLabel.Text = $"A négyzet kerülete: {k}";
            }
        }

        private void isCircleBtn_CheckedChanged(object sender, EventArgs e)
        {
            mainLabel.Text = "A kör sugara:";
        }

        private void isSquareBtn_CheckedChanged(object sender, EventArgs e)
        {
            mainLabel.Text = "A négyzet oldalhossza:";
        }
    }
}
