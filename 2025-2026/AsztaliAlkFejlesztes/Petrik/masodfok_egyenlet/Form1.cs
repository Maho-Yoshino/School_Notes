namespace masodfok_egyenlet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(InputA.Text, out double A) || A == 0)
            {
                MessageBox.Show("Nem megfelelõ \"A\" érték lett megadva. Kérem adjon meg egy másik értéket");
                return;
            }
            if (!double.TryParse(InputB.Text, out double B))
            {
                MessageBox.Show("Nem megfelelõ \"B\" érték lett megadva. Kérem adjon meg egy másik értéket");
                return;
            }
            if (!double.TryParse(InputC.Text, out double C))
            {
                MessageBox.Show("Nem megfelelõ \"C\" érték lett megadva. Kérem adjon meg egy másik értéket");
                return;
            }
            double discriminant = Math.Pow(B, 2) - 4 * A * C;
            double sol1 = ((-1 * B) + Math.Sqrt(discriminant)) / (2 * A);
            double sol2 = ((-1 * B) - Math.Sqrt(discriminant)) / (2 * A);
            string text;
            if (discriminant < 0)
            {
                text = "Nincs megoldás a valós számok halmazán";
            }
            else if (discriminant == 0)
            {
                text = $"Megoldás: {sol1}";
            }
            else
            {
                text = $"Megoldások:\n\tÖsszeadás: {sol1}\n\tKivonás: {sol2}";
            }
            MessageBox.Show(text, "Megoldás", MessageBoxButtons.OK);
        }
    }
}
