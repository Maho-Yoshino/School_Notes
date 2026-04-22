namespace fel_20260422
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
            inputFileMagyarDialog = new OpenFileDialog();
            inputFileMatekDialog = new OpenFileDialog();
            this.inputFileMagyarBtn = new Button();
            inputFileMagyarFilename = new Label();
            groupBox1 = new GroupBox();
            inputNameListBtn = new Button();
            inputNameListFilename = new Label();
            inputFileMatekFilename = new Label();
            inputFileMatekBtn = new Button();
            mainDataView = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            magyarSzakkor = new DataGridViewCheckBoxColumn();
            matekSzakkor = new DataGridViewCheckBoxColumn();
            unionFilterBtn = new Button();
            intersectionFilterBtn = new Button();
            filterGB = new GroupBox();
            searchGB = new GroupBox();
            searchBtn = new Button();
            searchNameInput = new TextBox();
            label1 = new Label();
            saveFileDialog = new SaveFileDialog();
            outputToFileBtn = new Button();
            inputNameListDialog = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataView).BeginInit();
            filterGB.SuspendLayout();
            searchGB.SuspendLayout();
            SuspendLayout();
            // 
            // inputFileMagyarDialog
            // 
            inputFileMagyarDialog.FileName = "input1.txt";
            // 
            // inputFileMatekDialog
            // 
            inputFileMatekDialog.FileName = "input2.txt";
            // 
            // inputFileMagyarBtn
            // 
            this.inputFileMagyarBtn.Enabled = false;
            this.inputFileMagyarBtn.Location = new Point(6, 105);
            this.inputFileMagyarBtn.Name = "inputFileMagyarBtn";
            this.inputFileMagyarBtn.Size = new Size(204, 29);
            this.inputFileMagyarBtn.TabIndex = 0;
            this.inputFileMagyarBtn.Text = "Magyar fájl kiválasztása";
            this.inputFileMagyarBtn.UseVisualStyleBackColor = true;
            this.inputFileMagyarBtn.Click += this.inputFileMagyarBtn_Click;
            // 
            // inputFileMagyarFilename
            // 
            inputFileMagyarFilename.AutoSize = true;
            inputFileMagyarFilename.Location = new Point(6, 172);
            inputFileMagyarFilename.Name = "inputFileMagyarFilename";
            inputFileMagyarFilename.Size = new Size(112, 20);
            inputFileMagyarFilename.TabIndex = 1;
            inputFileMagyarFilename.Text = "Magyaros fájl: -";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(inputNameListBtn);
            groupBox1.Controls.Add(inputNameListFilename);
            groupBox1.Controls.Add(inputFileMatekFilename);
            groupBox1.Controls.Add(inputFileMatekBtn);
            groupBox1.Controls.Add(this.inputFileMagyarBtn);
            groupBox1.Controls.Add(inputFileMagyarFilename);
            groupBox1.Location = new Point(572, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(216, 215);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Beviteli Adatok";
            // 
            // inputNameListBtn
            // 
            inputNameListBtn.Location = new Point(6, 26);
            inputNameListBtn.Name = "inputNameListBtn";
            inputNameListBtn.Size = new Size(204, 29);
            inputNameListBtn.TabIndex = 5;
            inputNameListBtn.Text = "Névlista beolvasása";
            inputNameListBtn.UseVisualStyleBackColor = true;
            inputNameListBtn.Click += inputNameListBtn_Click;
            // 
            // inputNameListFilename
            // 
            inputNameListFilename.AutoSize = true;
            inputNameListFilename.Location = new Point(6, 58);
            inputNameListFilename.Name = "inputNameListFilename";
            inputNameListFilename.Size = new Size(101, 20);
            inputNameListFilename.TabIndex = 4;
            inputNameListFilename.Text = "Névlista Fájl: -";
            // 
            // inputFileMatekFilename
            // 
            inputFileMatekFilename.AutoSize = true;
            inputFileMatekFilename.Location = new Point(6, 192);
            inputFileMatekFilename.Name = "inputFileMatekFilename";
            inputFileMatekFilename.Size = new Size(103, 20);
            inputFileMatekFilename.TabIndex = 3;
            inputFileMatekFilename.Text = "Matekos fájl: -";
            // 
            // inputFileMatekBtn
            // 
            inputFileMatekBtn.Enabled = false;
            inputFileMatekBtn.Location = new Point(6, 140);
            inputFileMatekBtn.Name = "inputFileMatekBtn";
            inputFileMatekBtn.Size = new Size(204, 29);
            inputFileMatekBtn.TabIndex = 2;
            inputFileMatekBtn.Text = "Matek fájl kiválasztása";
            inputFileMatekBtn.UseVisualStyleBackColor = true;
            inputFileMatekBtn.Click += inputFileMatekBtn_Click;
            // 
            // mainDataView
            // 
            mainDataView.AllowUserToAddRows = false;
            mainDataView.AllowUserToDeleteRows = false;
            mainDataView.AllowUserToOrderColumns = true;
            mainDataView.AllowUserToResizeColumns = false;
            mainDataView.AllowUserToResizeRows = false;
            mainDataView.ColumnHeadersHeight = 29;
            mainDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            mainDataView.Columns.AddRange(new DataGridViewColumn[] { name, magyarSzakkor, matekSzakkor });
            mainDataView.Location = new Point(12, 12);
            mainDataView.Name = "mainDataView";
            mainDataView.RowHeadersWidth = 51;
            mainDataView.Size = new Size(554, 418);
            mainDataView.TabIndex = 3;
            // 
            // name
            // 
            name.HeaderText = "Név";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 250;
            // 
            // magyarSzakkor
            // 
            magyarSzakkor.HeaderText = "Magyar Szakkör";
            magyarSzakkor.MinimumWidth = 6;
            magyarSzakkor.Name = "magyarSzakkor";
            magyarSzakkor.ReadOnly = true;
            magyarSzakkor.Width = 125;
            // 
            // matekSzakkor
            // 
            matekSzakkor.HeaderText = "Matek Szakkör";
            matekSzakkor.MinimumWidth = 6;
            matekSzakkor.Name = "matekSzakkor";
            matekSzakkor.ReadOnly = true;
            matekSzakkor.Width = 125;
            // 
            // unionFilterBtn
            // 
            unionFilterBtn.Location = new Point(6, 26);
            unionFilterBtn.Name = "unionFilterBtn";
            unionFilterBtn.Size = new Size(204, 29);
            unionFilterBtn.TabIndex = 4;
            unionFilterBtn.Text = "Unió";
            unionFilterBtn.UseVisualStyleBackColor = true;
            unionFilterBtn.Click += unionFilterBtn_Click;
            // 
            // intersectionFilterBtn
            // 
            intersectionFilterBtn.Location = new Point(6, 61);
            intersectionFilterBtn.Name = "intersectionFilterBtn";
            intersectionFilterBtn.Size = new Size(204, 29);
            intersectionFilterBtn.TabIndex = 5;
            intersectionFilterBtn.Text = "Metszet";
            intersectionFilterBtn.UseVisualStyleBackColor = true;
            intersectionFilterBtn.Click += intersectionFilterBtn_Click;
            // 
            // filterGB
            // 
            filterGB.Controls.Add(unionFilterBtn);
            filterGB.Controls.Add(intersectionFilterBtn);
            filterGB.Location = new Point(572, 233);
            filterGB.Name = "filterGB";
            filterGB.Size = new Size(216, 101);
            filterGB.TabIndex = 6;
            filterGB.TabStop = false;
            filterGB.Text = "Szűrés";
            // 
            // searchGB
            // 
            searchGB.Controls.Add(searchBtn);
            searchGB.Controls.Add(searchNameInput);
            searchGB.Controls.Add(label1);
            searchGB.Location = new Point(572, 340);
            searchGB.Name = "searchGB";
            searchGB.Size = new Size(216, 125);
            searchGB.TabIndex = 7;
            searchGB.TabStop = false;
            searchGB.Text = "Keresés";
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(6, 79);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(204, 29);
            searchBtn.TabIndex = 2;
            searchBtn.Text = "Keresés";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchNameInput
            // 
            searchNameInput.Location = new Point(6, 46);
            searchNameInput.Name = "searchNameInput";
            searchNameInput.Size = new Size(204, 27);
            searchNameInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 0;
            label1.Text = "Érték";
            // 
            // outputToFileBtn
            // 
            outputToFileBtn.Location = new Point(12, 436);
            outputToFileBtn.Name = "outputToFileBtn";
            outputToFileBtn.Size = new Size(554, 29);
            outputToFileBtn.TabIndex = 8;
            outputToFileBtn.Text = "Fájlba kiírás";
            outputToFileBtn.UseVisualStyleBackColor = true;
            outputToFileBtn.Click += outputToFileBtn_Click;
            // 
            // inputNameListDialog
            // 
            inputNameListDialog.FileName = "nevlista.txt";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 477);
            Controls.Add(outputToFileBtn);
            Controls.Add(searchGB);
            Controls.Add(filterGB);
            Controls.Add(mainDataView);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Szakkör részvétel elemző";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataView).EndInit();
            filterGB.ResumeLayout(false);
            searchGB.ResumeLayout(false);
            searchGB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog inputFileMagyarDialog;
        private OpenFileDialog inputFileMatekDialog;
        private Button inputFileMagyarBtn;
        private Label inputFileMagyarFilename;
        private GroupBox groupBox1;
        private Label inputFileMatekFilename;
        private Button inputFileMatekBtn;
        private DataGridView mainDataView;
        private DataGridViewTextBoxColumn name;
        private DataGridViewCheckBoxColumn magyarSzakkor;
        private DataGridViewCheckBoxColumn matekSzakkor;
        private Button unionFilterBtn;
        private Button intersectionFilterBtn;
        private GroupBox filterGB;
        private GroupBox searchGB;
        private Button searchBtn;
        private TextBox searchNameInput;
        private Label label1;
        private SaveFileDialog saveFileDialog;
        private Button outputToFileBtn;
        private Button inputNameListBtn;
        private Label inputNameListFilename;
        private OpenFileDialog inputNameListDialog;
    }
}
