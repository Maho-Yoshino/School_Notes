namespace fel_5_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            return;
        }
    }
    class Record
    {
        public string orszag { get; set; }
        public int terulet { get; set; }
        public Record(string line)
        {
            string[] data = line.Split(';');
            orszag = data[0];
            terulet = int.Parse(data[1]);
        }
    }
}
