using System.Text.RegularExpressions;

namespace fel_20260416
{
    public partial class Form1 : Form
    {
        Rekord[] adatok;
        public Form1()
        {
            adatok = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "data.txt")).Skip(1).ToList().ConvertAll(x => new Rekord(x)).ToArray();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = adatok;
            bindingSource1.Sort = "rendszam ASC";
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();

            avgLbl.Text = $"Átlag értékelés: {Math.Round(adatok.Average(x => x.ertekeles), 2)}";


        }

        private void decisionBtn_Click(object sender, EventArgs e)
        {
            bool anyCustomPlate = adatok.Any(x => x.rendszamTipus == rendszamTipusEnum.sajat);
            if ()
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void minMaxBtn_Click(object sender, EventArgs e)
        {

        }

        private void countBtn_Click(object sender, EventArgs e)
        {

        }
    }
    public enum rendszamTipusEnum { regi, uj, sajat }
    public class Rekord
    {
        public string rendszam { get; set; }
        public rendszamTipusEnum rendszamTipus { get; set; }
        public string nev { get; set; }
        public byte kor { get; set; }
        public string varos { get; set; }
        public byte ertekeles { get; set; }

        public Rekord(string sor)
        {
            string[] _ = sor.Split(";");
            rendszam = _[0];
            string regiRendszamRgx = "[A-z]{3}-[0-9]{3}";
            string ujRendszamRgx = "[A-z]{2} [A-z]{2} [0-9]{3}";
            if ((new Regex(regiRendszamRgx)).IsMatch(rendszam))
                rendszamTipus = rendszamTipusEnum.regi;
            else if ((new Regex(ujRendszamRgx)).IsMatch(rendszam))
                rendszamTipus = rendszamTipusEnum.uj;
            else
                rendszamTipus = rendszamTipusEnum.sajat;
            nev = _[1];
            kor = byte.Parse(_[2]);
            varos = _[3];
            ertekeles = byte.Parse(_[4]);
        }
    }
}
