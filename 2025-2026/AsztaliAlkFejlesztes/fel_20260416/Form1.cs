using System.Text.RegularExpressions;

namespace fel_20260416
{
    public partial class Form1 : Form
    {
        List<Rekord> visibleData;
        Rekord[] allData;
        public Form1()
        {
            visibleData = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "data.txt")).Skip(1).ToList().ConvertAll(x => new Rekord(x));
            allData = visibleData.ToArray();
            InitializeComponent();
            dataGridViewBS.DataSource = visibleData;
            dataGridViewBS.Sort = "rendszam ASC";
            mainDataGrid.DataSource = dataGridViewBS;
            plateSelectBS.DataSource = Enum.GetValues(typeof(rendszamTipusEnum));
            plateSearchCombo.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            avgLbl.Text = $"Átlag értékelés: {Math.Round(visibleData.Average(x => x.ertekeles), 2)}";
        }

        private void decisionBtn_Click(object sender, EventArgs e)
        {
            bool customPlatePresent = allData.Any(x => x.rendszamTipus == rendszamTipusEnum.egyeni);
            MessageBox.Show($"{(customPlatePresent ? "Van" : "Nincs")} egyéni rendszám");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            searchPlateTextbox.Text = searchPlateTextbox.Text.ToUpper();
            visibleData = new List<Rekord>();
            foreach (Rekord rekord in allData)
            {
                if (rekord.rendszam.Contains(searchPlateTextbox.Text))
                {
                    visibleData.Add(rekord);
                }
            }
            dataGridViewBS.DataSource = visibleData;
            mainDataGrid.Refresh();
        }

        private void minMaxBtn_Click(object sender, EventArgs e)
        {
            Rekord? value;
            rendszamTipusEnum selected;
            switch (plateSearchCombo.SelectedItem.ToString())
            {
                case "AAA-000":
                    selected = rendszamTipusEnum.regi;
                    break;
                case "AA AA 000":
                    selected = rendszamTipusEnum.uj;
                    break;
                default:
                    selected = rendszamTipusEnum.egyeni;
                    break;
            }
            Rekord[] tmp = allData.Where(x => x.rendszamTipus == selected).ToArray();
            if (minMaxMaximumRadio.Checked)
            {
                value = tmp.MaxBy(x => x.ertekeles);
            }
            else
            {
                value = tmp.MinBy(x => x.ertekeles);
            }
            if (value == null)
            {
                MessageBox.Show("Nincs adat.");
                return;
            }
            MessageBox.Show($"A {(minMaxMaximumRadio.Checked ? "Maximum" : "Minimum")} értékelés {value.ertekeles} pont.");
        }

        private void countBtn_Click(object sender, EventArgs e)
        {

            if (countAboveRadio.Checked)
            {
                countTextbox.Text = allData.Count(x => x.ertekeles >= 75).ToString();
            }
            else
            {
                countTextbox.Text = allData.Count(x => x.ertekeles < 75).ToString();
            }
        }
    }
    public enum rendszamTipusEnum { regi, uj, egyeni }
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
                rendszamTipus = rendszamTipusEnum.egyeni;
            nev = _[1];
            kor = byte.Parse(_[2]);
            varos = _[3];
            ertekeles = byte.Parse(_[4]);
        }
    }
}
