namespace fel_4_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pontszamInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!int.TryParse(this.pontszamInput.Text, out int pontszam) || pontszam < 0 || pontszam > 50)
                {
                    MessageBox.Show("Kérem megfelelõ adatot adjon meg!", "Hibás adat");
                    return;
                }
                if (pontszam <= 10)
                {
                    resultLabel.Text = "1 (Elégtelen)";
                }
                else if (pontszam <= 20)
                {
                    resultLabel.Text = "2 (Elégséges)";
                }
                else if (pontszam <= 30)
                {
                    resultLabel.Text = "3 (Közepes)";
                }
                else if (pontszam <= 40)
                {
                    resultLabel.Text = "4 (Jó)";
                }
                else
                {
                    resultLabel.Text = "5 (Jeles)";
                }
            }
        }
    }
}
