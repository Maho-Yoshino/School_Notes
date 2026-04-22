namespace fel_20260422
{
    /*
     * Txt fájlokból való beolvasás
     * Követelmények:
     * - Unió
     * - Metszet
     * - Rendezés (választható legyen 2 közül)
     * - Rendezés után logaritmikus (bináris) keresés
     */
    public partial class Form1 : Form
    {
        List<Rekord> osszesRekord = new List<Rekord>();
        private bool readMagyarFile = false;
        private bool readMatekFile = false;
        public Form1()
        {
            string projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            InitializeComponent();
            inputFileMagyarDialog.InitialDirectory = projectRootDir;
            inputFileMatekDialog.InitialDirectory = projectRootDir;
            saveFileDialog.InitialDirectory = projectRootDir;
            saveFileDialog.FileName = "output.txt";
        }
        #region Input
        private void inputNameListBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = inputNameListDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            string filePath = inputNameListDialog.FileName;
            if (!File.Exists(filePath)) return;
            inputNameListFilename.Text = $"Névlista fájl: {filePath}";
            osszesRekord.Clear();
            foreach (string row in File.ReadAllLines(filePath))
            {
                osszesRekord.Add(new Rekord(row));
            }
            inputFileMagyarBtn.Enabled = true;
            inputFileMatekBtn.Enabled = true;
            inputNameListBtn.Enabled = false;
        }
        private void inputFileMagyarBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = inputFileMagyarDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            string filePath = inputFileMagyarDialog.FileName;
            if (!File.Exists(filePath)) return;
            inputFileMagyarFilename.Text = $"Magyaros fájl: {filePath}";
            foreach (Rekord rekord in osszesRekord)
            {
                if (!File.ReadAllLines(filePath).Contains(rekord.nev)) continue;
                switch (rekord.resztvetel)
                {
                    case Rekord.ResztvetelEnum.None:
                        rekord.resztvetel = Rekord.ResztvetelEnum.Magyar;
                        break;
                    case Rekord.ResztvetelEnum.Matek:
                        rekord.resztvetel = Rekord.ResztvetelEnum.Both;
                        break;
                }
            }
            inputFileMagyarBtn.Enabled = false;
            readMagyarFile = true;
            if (readMagyarFile && readMatekFile)
            {

            }
        }
        private void inputFileMatekBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = inputFileMatekDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            string filePath = inputFileMatekDialog.FileName;
            if (!File.Exists(filePath)) return;
            inputFileMatekFilename.Text = $"Matekos fájl: {filePath}";
            foreach (Rekord rekord in osszesRekord)
            {
                if (!File.ReadAllLines(filePath).Contains(rekord.nev)) continue;
                switch (rekord.resztvetel)
                {
                    case Rekord.ResztvetelEnum.None:
                        rekord.resztvetel = Rekord.ResztvetelEnum.Matek;
                        break;
                    case Rekord.ResztvetelEnum.Magyar:
                        rekord.resztvetel = Rekord.ResztvetelEnum.Both;
                        break;
                }
            }
            inputFileMatekBtn.Enabled = false;
            readMatekFile = true;
            if (readMagyarFile && readMatekFile)
            {

            }
        }
        #endregion
        #region Output
        private void outputToFileBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Search
        private void searchBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Filter
        private void unionFilterBtn_Click(object sender, EventArgs e)
        {

        }

        private void intersectionFilterBtn_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
    class Rekord
    {
        public enum ResztvetelEnum { None, Magyar, Matek, Both }
        public string nev;
        public ResztvetelEnum resztvetel { get; set; } = ResztvetelEnum.None;
        public Rekord(string name)
        {
            nev = name;
        }
    }
}
