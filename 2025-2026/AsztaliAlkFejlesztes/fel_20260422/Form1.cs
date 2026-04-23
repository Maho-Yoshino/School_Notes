using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;

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
        List<Rekord> visibleRecords = new List<Rekord>();
        private bool readMagyarFile = false;
        private bool readMatekFile = false;
        public Form1()
        {
            string projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            InitializeComponent();
            inputNameListDialog.InitialDirectory = projectRootDir;
            inputFileMagyarDialog.InitialDirectory = projectRootDir;
            inputFileMatekDialog.InitialDirectory = projectRootDir;
            saveFileDialog.InitialDirectory = projectRootDir;
            saveFileDialog.FileName = "output.txt";
            mainDataView.DataSource = visibleRecords;
        }
        #region Helpers
        private enum SortingMethods { BubbleSort, QuickSort }
        private IEnumerable<T> sort<T>(IEnumerable<T> obj, Func<T, object> selectBy, SortingMethods method = SortingMethods.BubbleSort)
        {
            if (method == SortingMethods.BubbleSort)
            {

            }
            else if (method == SortingMethods.QuickSort)
            {

            }
            else
            {
                throw new ArgumentException($"Invalid sorting algorithm '{method}' given");
            }
        }
        #endregion
        #region Input
        private void inputNameListBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = inputNameListDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            string filePath = inputNameListDialog.FileName;
            if (!File.Exists(filePath)) return;
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
            string[] fileContent = File.ReadAllLines(filePath);
            foreach (Rekord rekord in osszesRekord)
            {
                if (!fileContent.Contains(rekord.Nev)) continue;
                switch (rekord.Resztvetel)
                {
                    case Rekord.ResztvetelEnum.None:
                        rekord.Resztvetel = Rekord.ResztvetelEnum.Magyar;
                        break;
                    case Rekord.ResztvetelEnum.Matek:
                        rekord.Resztvetel = Rekord.ResztvetelEnum.Both;
                        break;
                }
            }
            inputFileMagyarBtn.Enabled = false;
            readMagyarFile = true;
            tryEnableUI();
        }
        private void inputFileMatekBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = inputFileMatekDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            string filePath = inputFileMatekDialog.FileName;
            if (!File.Exists(filePath)) return;
            string[] fileContent = File.ReadAllLines(filePath);
            foreach (Rekord rekord in osszesRekord)
            {
                if (!fileContent.Contains(rekord.Nev)) continue;
                switch (rekord.Resztvetel)
                {
                    case Rekord.ResztvetelEnum.None:
                        rekord.Resztvetel = Rekord.ResztvetelEnum.Matek;
                        break;
                    case Rekord.ResztvetelEnum.Magyar:
                        rekord.Resztvetel = Rekord.ResztvetelEnum.Both;
                        break;
                }
            }
            inputFileMatekBtn.Enabled = false;
            readMatekFile = true;
            tryEnableUI();
        }
        private void tryEnableUI()
        {
            if (!readMagyarFile || !readMatekFile) return;
            filterGB.Enabled = true;
            searchGB.Enabled = true;
            outputToFileBtn.Enabled = true;
            mainDataView.Enabled = true;
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
            List<Rekord> sortedList = new List<Rekord>(); 
                        
        }
        #endregion
        #region Filter
        private void unionFilterBtn_Click(object sender, EventArgs e)
        {
            unionFilterBtn.Enabled = false;
            visibleRecords.Clear();
            visibleRecords = osszesRekord.Where(rekord => rekord.Resztvetel != Rekord.ResztvetelEnum.None).ToList();
            mainDataView.Refresh();
            unionFilterBtn.Enabled = true;
        }

        private void intersectionFilterBtn_Click(object sender, EventArgs e)
        {
            intersectionFilterBtn.Enabled = false;
            visibleRecords.Clear();
            visibleRecords = osszesRekord.Where(rekord => rekord.Resztvetel == Rekord.ResztvetelEnum.Both).ToList();
            mainDataView.Refresh();
            intersectionFilterBtn.Enabled = true;
        }
        private void clearFilterBtn_Click(object sender, EventArgs e)
        {
            visibleRecords = osszesRekord;
            mainDataView.Refresh();
        }
        #endregion
    }
    class Rekord
    {
        public enum ResztvetelEnum { None, Magyar, Matek, Both }
        public string Nev { get; set; }
        public ResztvetelEnum Resztvetel { get; set; } = ResztvetelEnum.None;
        public Rekord(string name)
        {
            Nev = name;
        }
    }
}
