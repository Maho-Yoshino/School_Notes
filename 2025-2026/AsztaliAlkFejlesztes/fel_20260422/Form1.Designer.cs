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
            inputFileMagyarBtn = new Button();
            groupBox1 = new GroupBox();
            inputNameListBtn = new Button();
            inputFileMatekBtn = new Button();
            mainDataView = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            magyarSzakkor = new DataGridViewCheckBoxColumn();
            matekSzakkor = new DataGridViewCheckBoxColumn();
            unionFilterBtn = new Button();
            intersectionFilterBtn = new Button();
            filterGB = new GroupBox();
            clearFilterBtn = new Button();
            searchGB = new GroupBox();
            searchBtn = new Button();
            searchNameInput = new TextBox();
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
            inputFileMagyarDialog.FileName = "magyarSzakkor.txt";
            // 
            // inputFileMatekDialog
            // 
            inputFileMatekDialog.FileName = "matekSzakkor.txt";
            // 
            // inputFileMagyarBtn
            // 
            inputFileMagyarBtn.Enabled = false;
            inputFileMagyarBtn.Location = new Point(6, 84);
            inputFileMagyarBtn.Name = "inputFileMagyarBtn";
            inputFileMagyarBtn.Size = new Size(204, 29);
            inputFileMagyarBtn.TabIndex = 0;
            inputFileMagyarBtn.Text = "Magyar fájl kiválasztása";
            inputFileMagyarBtn.UseVisualStyleBackColor = true;
            inputFileMagyarBtn.Click += inputFileMagyarBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(inputNameListBtn);
            groupBox1.Controls.Add(inputFileMatekBtn);
            groupBox1.Controls.Add(inputFileMagyarBtn);
            groupBox1.Location = new Point(572, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(216, 160);
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
            // inputFileMatekBtn
            // 
            inputFileMatekBtn.Enabled = false;
            inputFileMatekBtn.Location = new Point(6, 119);
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
            mainDataView.Enabled = false;
            mainDataView.Location = new Point(12, 12);
            mainDataView.Name = "mainDataView";
            mainDataView.AutoGenerateColumns = false;
            mainDataView.RowHeadersWidth = 51;
            mainDataView.Size = new Size(554, 383);
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
            filterGB.Controls.Add(clearFilterBtn);
            filterGB.Controls.Add(unionFilterBtn);
            filterGB.Controls.Add(intersectionFilterBtn);
            filterGB.Enabled = false;
            filterGB.Location = new Point(572, 178);
            filterGB.Name = "filterGB";
            filterGB.Size = new Size(216, 147);
            filterGB.TabIndex = 6;
            filterGB.TabStop = false;
            filterGB.Text = "Szűrés";
            // 
            // clearFilterBtn
            // 
            clearFilterBtn.Location = new Point(6, 112);
            clearFilterBtn.Name = "clearFilterBtn";
            clearFilterBtn.Size = new Size(204, 29);
            clearFilterBtn.TabIndex = 6;
            clearFilterBtn.Text = "Szűrés törlése";
            clearFilterBtn.UseVisualStyleBackColor = true;
            clearFilterBtn.Click += clearFilterBtn_Click;
            // 
            // searchGB
            // 
            searchGB.Controls.Add(searchBtn);
            searchGB.Controls.Add(searchNameInput);
            searchGB.Enabled = false;
            searchGB.Location = new Point(572, 331);
            searchGB.Name = "searchGB";
            searchGB.Size = new Size(216, 99);
            searchGB.TabIndex = 7;
            searchGB.TabStop = false;
            searchGB.Text = "Keresés";
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(6, 59);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(204, 29);
            searchBtn.TabIndex = 2;
            searchBtn.Text = "Keresés";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchNameInput
            // 
            searchNameInput.Location = new Point(6, 26);
            searchNameInput.Name = "searchNameInput";
            searchNameInput.PlaceholderText = "Név";
            searchNameInput.Size = new Size(204, 27);
            searchNameInput.TabIndex = 1;
            // 
            // outputToFileBtn
            // 
            outputToFileBtn.Enabled = false;
            outputToFileBtn.Location = new Point(12, 401);
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
            ClientSize = new Size(800, 442);
            Controls.Add(outputToFileBtn);
            Controls.Add(searchGB);
            Controls.Add(filterGB);
            Controls.Add(mainDataView);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Szakkör részvétel elemző";
            groupBox1.ResumeLayout(false);
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
        private Button button1;
        private Button clearFilterBtn;
    }
}
