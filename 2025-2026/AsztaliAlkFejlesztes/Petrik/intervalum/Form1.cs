namespace intervalum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ah = int.Parse(ahInput.Text);
            int fh = int.Parse(fhInput.Text);
            int num = int.Parse(numInput.Text);
            if (ah > fh)
            {
                resultLabel.Text = "Ez nem intervalum!";
                return;
            }
            if (num >= ah && num <= fh)
            {
                resultLabel.Text = "Benne van az intervalumban.";
                return;
            }
            resultLabel.Text = "Nincs benne az intervalumban.";
        }
    }
}
