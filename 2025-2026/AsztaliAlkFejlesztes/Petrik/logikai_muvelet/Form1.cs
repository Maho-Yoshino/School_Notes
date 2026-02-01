namespace logikai_muvelet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            Input1.Checked = !Input1.Checked;
            Input2.Checked = !Input2.Checked;
        }

        private void ANDbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"A logikai ÉS eredménye: {Input1.Checked && Input2.Checked}");
        }

        private void ORbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"A logikai VAGY eredménye: {Input1.Checked || Input2.Checked}");
        }
    }
}
