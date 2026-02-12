using Microsoft.VisualBasic;

namespace ciklus2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            do
            {
                num = int.Parse(Interaction.InputBox("Kérem a következõ számot:", "Adatbevitel", "0", 100, 100));
                if (num != 0)
                {
                    if (num % 2 == 0)
                    {
                        parosListBox.Items.Add(num);
                    }
                    else
                    {
                        paratlanListBox.Items.Add(num);
                    }

                }
            }
            while (num != 0);
        }
    }
}
