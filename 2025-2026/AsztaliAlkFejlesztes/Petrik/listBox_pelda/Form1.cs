namespace listBox_pelda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void delSelectedBtn_Click(object sender, EventArgs e)
        {
            object? item = listBox1.SelectedItem;
            if (item is null)
            {
                MessageBox.Show("Nem válaszott ki egy elemet sem!");
                return;
            }
            listBox1.Items.Remove(item);
        }

        private void delAllBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
