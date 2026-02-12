namespace fel_4_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yearInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Return;
            if (e.KeyChar != (char)Keys.Return)
            {
                return;
            }
            if (!int.TryParse(yearInput.Text, out int year))
            {
                MessageBox.Show("Kérem, érvényes számot adjon meg!");
                return;
            }
            bool isLeapYear = DateTime.IsLeapYear(year);
            this.resultLabel.Text = $"Az év{(isLeapYear ? "":" nem")} szökõév";
        }
    }
}
