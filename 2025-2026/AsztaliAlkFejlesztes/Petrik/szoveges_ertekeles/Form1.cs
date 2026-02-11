namespace szoveges_ertekeles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            int grade = int.Parse(mainInput.Text);
            switch (grade)
            {
                case 1:
                    gradeLabel.Text = "Elégtelen";
                    break;
                case 2:
                    gradeLabel.Text = "Elégséges";
                    break;
                case 3:
                    gradeLabel.Text = "Közepes";
                    break;
                case 4:
                    gradeLabel.Text = "Jó";
                    break;
                case 5:
                    gradeLabel.Text = "Jeles";
                    break;
                default:
                    gradeLabel.Text = "Nem osztályzat!";
                    break;
            }
        }
    }
}
