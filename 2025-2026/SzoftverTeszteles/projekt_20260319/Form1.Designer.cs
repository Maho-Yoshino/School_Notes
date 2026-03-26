namespace projekt_20260319
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainTabControl = new TabControl();
            rectTab = new TabPage();
            szamitasBtn = new Button();
            bOldalTxt = new TextBox();
            aOldalTxt = new TextBox();
            teruletLbl = new Label();
            terDisplayLbl = new Label();
            bSideLbl = new Label();
            aSideLbl = new Label();
            pizzaTab = new TabPage();
            orderBtn = new Button();
            priceLbl = new Label();
            overallPriceLbl = new Label();
            extrasGroupBox = new GroupBox();
            extraCheesePriceLbl = new Label();
            pepperoniPriceLbl = new Label();
            mushroomPriceLbl = new Label();
            olivePriceLbl = new Label();
            cornPriceLbl = new Label();
            extraCheeseChk = new CheckBox();
            pepperoniChk = new CheckBox();
            mushroomChk = new CheckBox();
            oliveChk = new CheckBox();
            cornChk = new CheckBox();
            sizeGroupBox = new GroupBox();
            csaladiPriceLbl = new Label();
            mediumPriceLbl = new Label();
            csaladiSizeRadio = new RadioButton();
            mediumSizeRadio = new RadioButton();
            mainTabControl.SuspendLayout();
            rectTab.SuspendLayout();
            pizzaTab.SuspendLayout();
            extrasGroupBox.SuspendLayout();
            sizeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(rectTab);
            mainTabControl.Controls.Add(pizzaTab);
            mainTabControl.Location = new Point(1, 0);
            mainTabControl.Multiline = true;
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(241, 381);
            mainTabControl.TabIndex = 0;
            mainTabControl.SelectedIndexChanged += mainTabControl_SelectedIndexChanged;
            // 
            // rectTab
            // 
            rectTab.Controls.Add(szamitasBtn);
            rectTab.Controls.Add(bOldalTxt);
            rectTab.Controls.Add(aOldalTxt);
            rectTab.Controls.Add(teruletLbl);
            rectTab.Controls.Add(terDisplayLbl);
            rectTab.Controls.Add(bSideLbl);
            rectTab.Controls.Add(aSideLbl);
            rectTab.Location = new Point(4, 29);
            rectTab.Name = "rectTab";
            rectTab.Padding = new Padding(3);
            rectTab.Size = new Size(233, 348);
            rectTab.TabIndex = 0;
            rectTab.Text = "Téglalap";
            rectTab.UseVisualStyleBackColor = true;
            // 
            // szamitasBtn
            // 
            szamitasBtn.Location = new Point(0, 165);
            szamitasBtn.Name = "szamitasBtn";
            szamitasBtn.Size = new Size(233, 29);
            szamitasBtn.TabIndex = 6;
            szamitasBtn.Text = "Számítás";
            szamitasBtn.UseVisualStyleBackColor = true;
            szamitasBtn.Click += szamitasBtn_Click;
            // 
            // bOldalTxt
            // 
            bOldalTxt.Location = new Point(71, 61);
            bOldalTxt.Name = "bOldalTxt";
            bOldalTxt.Size = new Size(125, 27);
            bOldalTxt.TabIndex = 5;
            bOldalTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // aOldalTxt
            // 
            aOldalTxt.Location = new Point(71, 8);
            aOldalTxt.Name = "aOldalTxt";
            aOldalTxt.Size = new Size(125, 27);
            aOldalTxt.TabIndex = 4;
            aOldalTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // teruletLbl
            // 
            teruletLbl.BorderStyle = BorderStyle.FixedSingle;
            teruletLbl.Location = new Point(71, 124);
            teruletLbl.MaximumSize = new Size(125, 0);
            teruletLbl.MinimumSize = new Size(125, 0);
            teruletLbl.Name = "teruletLbl";
            teruletLbl.Size = new Size(125, 20);
            teruletLbl.TabIndex = 3;
            teruletLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // terDisplayLbl
            // 
            terDisplayLbl.AutoSize = true;
            terDisplayLbl.Location = new Point(7, 124);
            terDisplayLbl.Name = "terDisplayLbl";
            terDisplayLbl.Size = new Size(57, 20);
            terDisplayLbl.TabIndex = 2;
            terDisplayLbl.Text = "Terület:";
            // 
            // bSideLbl
            // 
            bSideLbl.AutoSize = true;
            bSideLbl.Location = new Point(44, 64);
            bSideLbl.Name = "bSideLbl";
            bSideLbl.Size = new Size(21, 20);
            bSideLbl.TabIndex = 1;
            bSideLbl.Text = "b:";
            // 
            // aSideLbl
            // 
            aSideLbl.AutoSize = true;
            aSideLbl.Location = new Point(44, 11);
            aSideLbl.Name = "aSideLbl";
            aSideLbl.Size = new Size(20, 20);
            aSideLbl.TabIndex = 0;
            aSideLbl.Text = "a:";
            // 
            // pizzaTab
            // 
            pizzaTab.Controls.Add(orderBtn);
            pizzaTab.Controls.Add(priceLbl);
            pizzaTab.Controls.Add(overallPriceLbl);
            pizzaTab.Controls.Add(extrasGroupBox);
            pizzaTab.Controls.Add(sizeGroupBox);
            pizzaTab.Location = new Point(4, 29);
            pizzaTab.Name = "pizzaTab";
            pizzaTab.Padding = new Padding(3);
            pizzaTab.Size = new Size(233, 348);
            pizzaTab.TabIndex = 1;
            pizzaTab.Text = "Pizza rendelés";
            pizzaTab.UseVisualStyleBackColor = true;
            // 
            // orderBtn
            // 
            orderBtn.Location = new Point(7, 312);
            orderBtn.Name = "orderBtn";
            orderBtn.Size = new Size(212, 29);
            orderBtn.TabIndex = 4;
            orderBtn.Text = "Megrendelés";
            orderBtn.UseVisualStyleBackColor = true;
            orderBtn.Click += orderBtn_Click;
            // 
            // priceLbl
            // 
            priceLbl.BorderStyle = BorderStyle.FixedSingle;
            priceLbl.Location = new Point(85, 284);
            priceLbl.Name = "priceLbl";
            priceLbl.Size = new Size(134, 25);
            priceLbl.TabIndex = 3;
            priceLbl.Text = "2000 Ft";
            priceLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // overallPriceLbl
            // 
            overallPriceLbl.AutoSize = true;
            overallPriceLbl.Location = new Point(7, 284);
            overallPriceLbl.Name = "overallPriceLbl";
            overallPriceLbl.Size = new Size(72, 20);
            overallPriceLbl.TabIndex = 2;
            overallPriceLbl.Text = "Összesen:";
            // 
            // extrasGroupBox
            // 
            extrasGroupBox.Controls.Add(extraCheesePriceLbl);
            extrasGroupBox.Controls.Add(pepperoniPriceLbl);
            extrasGroupBox.Controls.Add(mushroomPriceLbl);
            extrasGroupBox.Controls.Add(olivePriceLbl);
            extrasGroupBox.Controls.Add(cornPriceLbl);
            extrasGroupBox.Controls.Add(extraCheeseChk);
            extrasGroupBox.Controls.Add(pepperoniChk);
            extrasGroupBox.Controls.Add(mushroomChk);
            extrasGroupBox.Controls.Add(oliveChk);
            extrasGroupBox.Controls.Add(cornChk);
            extrasGroupBox.Location = new Point(7, 101);
            extrasGroupBox.Name = "extrasGroupBox";
            extrasGroupBox.Size = new Size(212, 180);
            extrasGroupBox.TabIndex = 1;
            extrasGroupBox.TabStop = false;
            extrasGroupBox.Text = "Extra Feltétek";
            // 
            // extraCheesePriceLbl
            // 
            extraCheesePriceLbl.AutoSize = true;
            extraCheesePriceLbl.Location = new Point(147, 147);
            extraCheesePriceLbl.Name = "extraCheesePriceLbl";
            extraCheesePriceLbl.Size = new Size(59, 20);
            extraCheesePriceLbl.TabIndex = 9;
            extraCheesePriceLbl.Text = "+100 Ft";
            extraCheesePriceLbl.Visible = false;
            // 
            // pepperoniPriceLbl
            // 
            pepperoniPriceLbl.AutoSize = true;
            pepperoniPriceLbl.Location = new Point(147, 116);
            pepperoniPriceLbl.Name = "pepperoniPriceLbl";
            pepperoniPriceLbl.Size = new Size(59, 20);
            pepperoniPriceLbl.TabIndex = 8;
            pepperoniPriceLbl.Text = "+200 Ft";
            pepperoniPriceLbl.Visible = false;
            // 
            // mushroomPriceLbl
            // 
            mushroomPriceLbl.AutoSize = true;
            mushroomPriceLbl.Location = new Point(155, 86);
            mushroomPriceLbl.Name = "mushroomPriceLbl";
            mushroomPriceLbl.Size = new Size(51, 20);
            mushroomPriceLbl.TabIndex = 7;
            mushroomPriceLbl.Text = "+50 Ft";
            mushroomPriceLbl.Visible = false;
            // 
            // olivePriceLbl
            // 
            olivePriceLbl.AutoSize = true;
            olivePriceLbl.Location = new Point(147, 56);
            olivePriceLbl.Name = "olivePriceLbl";
            olivePriceLbl.Size = new Size(59, 20);
            olivePriceLbl.TabIndex = 6;
            olivePriceLbl.Text = "+200 Ft";
            olivePriceLbl.Visible = false;
            // 
            // cornPriceLbl
            // 
            cornPriceLbl.AutoSize = true;
            cornPriceLbl.Location = new Point(147, 30);
            cornPriceLbl.Name = "cornPriceLbl";
            cornPriceLbl.Size = new Size(59, 20);
            cornPriceLbl.TabIndex = 5;
            cornPriceLbl.Text = "+100 Ft";
            cornPriceLbl.Visible = false;
            // 
            // extraCheeseChk
            // 
            extraCheeseChk.AutoSize = true;
            extraCheeseChk.Location = new Point(6, 146);
            extraCheeseChk.Name = "extraCheeseChk";
            extraCheeseChk.Size = new Size(93, 24);
            extraCheeseChk.TabIndex = 4;
            extraCheeseChk.Text = "Extra Sajt";
            extraCheeseChk.UseVisualStyleBackColor = true;
            extraCheeseChk.CheckedChanged += extraCheeseChk_CheckedChanged;
            // 
            // pepperoniChk
            // 
            pepperoniChk.AutoSize = true;
            pepperoniChk.Location = new Point(6, 116);
            pepperoniChk.Name = "pepperoniChk";
            pepperoniChk.Size = new Size(98, 24);
            pepperoniChk.TabIndex = 3;
            pepperoniChk.Text = "Pepperoni";
            pepperoniChk.UseVisualStyleBackColor = true;
            pepperoniChk.CheckedChanged += pepperoniChk_CheckedChanged;
            // 
            // mushroomChk
            // 
            mushroomChk.AutoSize = true;
            mushroomChk.Location = new Point(6, 86);
            mushroomChk.Name = "mushroomChk";
            mushroomChk.Size = new Size(80, 24);
            mushroomChk.TabIndex = 2;
            mushroomChk.Text = "Gomba";
            mushroomChk.UseVisualStyleBackColor = true;
            mushroomChk.CheckedChanged += mushroomChk_CheckedChanged;
            // 
            // oliveChk
            // 
            oliveChk.AutoSize = true;
            oliveChk.Location = new Point(6, 56);
            oliveChk.Name = "oliveChk";
            oliveChk.Size = new Size(108, 24);
            oliveChk.TabIndex = 1;
            oliveChk.Text = "Olívabogyó";
            oliveChk.UseVisualStyleBackColor = true;
            oliveChk.CheckedChanged += oliveChk_CheckedChanged;
            // 
            // cornChk
            // 
            cornChk.AutoSize = true;
            cornChk.Location = new Point(6, 26);
            cornChk.Name = "cornChk";
            cornChk.Size = new Size(88, 24);
            cornChk.TabIndex = 0;
            cornChk.Text = "Kukorica";
            cornChk.UseVisualStyleBackColor = true;
            cornChk.CheckedChanged += cornChk_CheckedChanged;
            // 
            // sizeGroupBox
            // 
            sizeGroupBox.Controls.Add(csaladiPriceLbl);
            sizeGroupBox.Controls.Add(mediumPriceLbl);
            sizeGroupBox.Controls.Add(csaladiSizeRadio);
            sizeGroupBox.Controls.Add(mediumSizeRadio);
            sizeGroupBox.Location = new Point(7, 6);
            sizeGroupBox.Name = "sizeGroupBox";
            sizeGroupBox.Size = new Size(212, 89);
            sizeGroupBox.TabIndex = 0;
            sizeGroupBox.TabStop = false;
            sizeGroupBox.Text = "Méret";
            // 
            // csaladiPriceLbl
            // 
            csaladiPriceLbl.AutoSize = true;
            csaladiPriceLbl.Location = new Point(149, 56);
            csaladiPriceLbl.Name = "csaladiPriceLbl";
            csaladiPriceLbl.Size = new Size(57, 20);
            csaladiPriceLbl.TabIndex = 3;
            csaladiPriceLbl.Text = "4000 Ft";
            // 
            // mediumPriceLbl
            // 
            mediumPriceLbl.AutoSize = true;
            mediumPriceLbl.Location = new Point(149, 26);
            mediumPriceLbl.Name = "mediumPriceLbl";
            mediumPriceLbl.Size = new Size(57, 20);
            mediumPriceLbl.TabIndex = 2;
            mediumPriceLbl.Text = "2000 Ft";
            // 
            // csaladiSizeRadio
            // 
            csaladiSizeRadio.AutoSize = true;
            csaladiSizeRadio.Location = new Point(6, 56);
            csaladiSizeRadio.Name = "csaladiSizeRadio";
            csaladiSizeRadio.Size = new Size(78, 24);
            csaladiSizeRadio.TabIndex = 1;
            csaladiSizeRadio.Text = "Családi";
            csaladiSizeRadio.UseVisualStyleBackColor = true;
            csaladiSizeRadio.CheckedChanged += csaladiSizeRadio_CheckedChanged;
            // 
            // mediumSizeRadio
            // 
            mediumSizeRadio.AutoSize = true;
            mediumSizeRadio.Checked = true;
            mediumSizeRadio.Location = new Point(6, 26);
            mediumSizeRadio.Name = "mediumSizeRadio";
            mediumSizeRadio.Size = new Size(86, 24);
            mediumSizeRadio.TabIndex = 0;
            mediumSizeRadio.TabStop = true;
            mediumSizeRadio.Text = "Közepes";
            mediumSizeRadio.UseVisualStyleBackColor = true;
            mediumSizeRadio.CheckedChanged += mediumSizeRadio_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(249, 383);
            Controls.Add(mainTabControl);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Téglalap Terület";
            mainTabControl.ResumeLayout(false);
            rectTab.ResumeLayout(false);
            rectTab.PerformLayout();
            pizzaTab.ResumeLayout(false);
            pizzaTab.PerformLayout();
            extrasGroupBox.ResumeLayout(false);
            extrasGroupBox.PerformLayout();
            sizeGroupBox.ResumeLayout(false);
            sizeGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainTabControl;
        private TabPage rectTab;
        private TabPage pizzaTab;
        private Button szamitasBtn;
        private TextBox bOldalTxt;
        private TextBox aOldalTxt;
        private Label teruletLbl;
        private Label terDisplayLbl;
        private Label bSideLbl;
        private Label aSideLbl;
        private GroupBox extrasGroupBox;
        private CheckBox extraCheeseChk;
        private CheckBox pepperoniChk;
        private CheckBox mushroomChk;
        private CheckBox oliveChk;
        private CheckBox cornChk;
        private GroupBox sizeGroupBox;
        private RadioButton csaladiSizeRadio;
        private RadioButton mediumSizeRadio;
        private Label mediumPriceLbl;
        private Label cornPriceLbl;
        private Label csaladiPriceLbl;
        private Label olivePriceLbl;
        private Label overallPriceLbl;
        private Label extraCheesePriceLbl;
        private Label pepperoniPriceLbl;
        private Label mushroomPriceLbl;
        private Label priceLbl;
        private Button orderBtn;
    }
}
