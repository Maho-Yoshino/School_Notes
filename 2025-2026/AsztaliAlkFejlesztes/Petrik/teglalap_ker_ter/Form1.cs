namespace teglalap_ker_ter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(rectSideAInput.Text, out int sideA) || !int.TryParse(rectSideBInput.Text, out int sideB))
            {
                MessageBox.Show("Kérem, érvényes számokat adjon meg a téglalap oldalaihoz!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int k = 2 * (sideA + sideB);
            int t = sideA * sideB;
            resultsList.Items.Add($"A = {sideA}, B = {sideB}, K = {k}, T = {t}");
        }
    }
}
