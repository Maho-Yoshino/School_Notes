namespace projekt_20260319
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 0)
            {
                this.Text = "Téglalap terület";
            }
            else
            {
                this.Text = "Pizza rendelő";
            }
        }
        #region Téglalap terület
        private void szamitasBtn_Click(object sender, EventArgs e)
        {
            double a, b;
            if (double.TryParse(aOldalTxt.Text, out a) && double.TryParse(bOldalTxt.Text, out b))
            {
                double terulet = a * b;
                teruletLbl.Text = terulet.ToString();
                MessageBox.Show($"A téglalap kerülete: {2*(a+b)}", "Téglalap kerület");
            }
            else
            {
                MessageBox.Show("Kérem, adjon meg érvényes számokat az a és b oldalhoz.");
            }
        }
        #endregion
        #region Pizza rendelő
        const byte deliveryFeePercent = 10;
        private void orderBtn_Click(object sender, EventArgs e)
        {
            string msgText = "A következő pizzát rendelte:\n-========================-\n";
            msgText += $"Méret: {(mediumSizeRadio.Checked ? "Közepes":"Családi")}\n";
            msgText += $"Pizza ára: {priceLbl.Text}\n";

            HashSet<string> feltetek = new HashSet<string>();
            if (cornChk.Checked) feltetek.Add(cornChk.Text);
            if (oliveChk.Checked) feltetek.Add(oliveChk.Text);
            if (mushroomChk.Checked) feltetek.Add(mushroomChk.Text);
            if (pepperoniChk.Checked) feltetek.Add(pepperoniChk.Text);
            if (extraCheeseChk.Checked) feltetek.Add(extraCheeseChk.Text);
            if (feltetek.Count > 0)
                msgText += $"Extra Feltétek:\n\t{string.Join("\n\t", feltetek)}\n";
            
            msgText += $"Kiszállítási díj: +{deliveryFeePercent}%\n";
            msgText += $"Végösszeg: {getPrice(priceLbl)*(1+deliveryFeePercent/(double)100)} Ft\n";
            msgText += "-========================-\nEz megfelel az elvárásainak?";
            MessageBox.Show(msgText, "Rendelés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #region Helper funkciók
        private int getPrice(Label label)
        {
            return int.Parse(label.Text.ToLower().Replace("ft", "").Replace("+", "").Trim());
        }
        private void setPrice(Label itemPriceLabel, CheckBox itemCheckBox)
        {
            priceLbl.Text = (getPrice(priceLbl) + getPrice(itemPriceLabel) * (itemCheckBox.Checked ? 1 : -1)).ToString() + " Ft";
        }
        #endregion
        #region Feltétek
        private void cornChk_CheckedChanged(object sender, EventArgs e)
        {
            cornPriceLbl.Visible = cornChk.Checked;
            setPrice(cornPriceLbl, cornChk);
        }
        private void oliveChk_CheckedChanged(object sender, EventArgs e)
        {
            olivePriceLbl.Visible = oliveChk.Checked;
            setPrice(olivePriceLbl, oliveChk);
        }
        private void mushroomChk_CheckedChanged(object sender, EventArgs e)
        {
            mushroomPriceLbl.Visible = mushroomChk.Checked;
            setPrice(mushroomPriceLbl, mushroomChk);
        }
        private void pepperoniChk_CheckedChanged(object sender, EventArgs e)
        {
            pepperoniPriceLbl.Visible = pepperoniChk.Checked;
            setPrice(pepperoniPriceLbl, pepperoniChk);
        }
        private void extraCheeseChk_CheckedChanged(object sender, EventArgs e)
        {
            extraCheesePriceLbl.Visible = extraCheeseChk.Checked;
            setPrice(extraCheesePriceLbl, extraCheeseChk);
        }
        #endregion
        #region Méretek
        private void mediumSizeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!mediumSizeRadio.Checked) { return; }
            priceLbl.Text = (getPrice(priceLbl) - getPrice(csaladiPriceLbl) + getPrice(mediumPriceLbl)).ToString() + " Ft";
        }
        private void csaladiSizeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!csaladiSizeRadio.Checked) { return; }
            priceLbl.Text = (getPrice(priceLbl) - getPrice(mediumPriceLbl) + getPrice(csaladiPriceLbl)).ToString() + " Ft";
        }
        #endregion
        #endregion
    }
}
