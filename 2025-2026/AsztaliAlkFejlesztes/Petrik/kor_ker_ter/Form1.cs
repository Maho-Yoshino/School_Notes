namespace kor_ker_ter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            double r = double.Parse(radiusInput.Text);
            double k = 2 * Math.PI * r;
            double t = Math.PI * r * r;
            MessageBox.Show($"A kör kerülete: {k}");
            MessageBox.Show($"A kör területe: {t}");
        }
    }
}
