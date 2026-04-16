namespace fel_20260416
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            platenumber = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            age = new DataGridViewTextBoxColumn();
            city = new DataGridViewTextBoxColumn();
            score = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            label1 = new Label();
            countBtn = new Button();
            countBelowRadio = new RadioButton();
            countAboveRadio = new RadioButton();
            groupBox2 = new GroupBox();
            minMaxMinimumRadio = new RadioButton();
            minMaxMaximumRadio = new RadioButton();
            minMaxBtn = new Button();
            label2 = new Label();
            plateSearchCombo = new ComboBox();
            groupBox3 = new GroupBox();
            label4 = new Label();
            textBox2 = new TextBox();
            searchBtn = new Button();
            groupBox4 = new GroupBox();
            decisionBtn = new Button();
            radioButton6 = new RadioButton();
            customPlate = new RadioButton();
            avgLbl = new Label();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { platenumber, name, age, city, score });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(678, 506);
            dataGridView1.TabIndex = 0;
            // 
            // platenumber
            // 
            platenumber.DataPropertyName = "rendszam";
            platenumber.HeaderText = "Rendszám";
            platenumber.MinimumWidth = 6;
            platenumber.Name = "platenumber";
            platenumber.Width = 125;
            // 
            // name
            // 
            name.DataPropertyName = "nev";
            name.HeaderText = "Név";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // age
            // 
            age.DataPropertyName = "kor";
            age.HeaderText = "Kor";
            age.MinimumWidth = 6;
            age.Name = "age";
            age.Width = 125;
            // 
            // city
            // 
            city.DataPropertyName = "varos";
            city.HeaderText = "Város";
            city.MinimumWidth = 6;
            city.Name = "city";
            city.Width = 125;
            // 
            // score
            // 
            score.DataPropertyName = "ertekeles";
            score.HeaderText = "Értékelés";
            score.MinimumWidth = 6;
            score.Name = "score";
            score.Width = 125;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(countBtn);
            groupBox1.Controls.Add(countBelowRadio);
            groupBox1.Controls.Add(countAboveRadio);
            groupBox1.Location = new Point(696, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(320, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Megszámlálás";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(182, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 60);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 3;
            label1.Text = "Találatok";
            // 
            // countBtn
            // 
            countBtn.Location = new Point(6, 86);
            countBtn.Name = "countBtn";
            countBtn.Size = new Size(170, 29);
            countBtn.TabIndex = 2;
            countBtn.Text = "Összegzés";
            countBtn.UseVisualStyleBackColor = true;
            countBtn.Click += countBtn_Click;
            // 
            // countBelowRadio
            // 
            countBelowRadio.AutoSize = true;
            countBelowRadio.Location = new Point(6, 56);
            countBelowRadio.Name = "countBelowRadio";
            countBelowRadio.Size = new Size(147, 24);
            countBelowRadio.TabIndex = 1;
            countBelowRadio.TabStop = true;
            countBelowRadio.Text = "75 alatti értékelés";
            countBelowRadio.UseVisualStyleBackColor = true;
            // 
            // countAboveRadio
            // 
            countAboveRadio.AutoSize = true;
            countAboveRadio.Checked = true;
            countAboveRadio.Location = new Point(6, 26);
            countAboveRadio.Name = "countAboveRadio";
            countAboveRadio.Size = new Size(170, 24);
            countAboveRadio.TabIndex = 0;
            countAboveRadio.TabStop = true;
            countAboveRadio.Text = "75 és feletti értékelés";
            countAboveRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(minMaxMinimumRadio);
            groupBox2.Controls.Add(minMaxMaximumRadio);
            groupBox2.Controls.Add(minMaxBtn);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(plateSearchCombo);
            groupBox2.Location = new Point(696, 143);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(320, 125);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Értékelés Minimum/Maximum";
            // 
            // minMaxMinimumRadio
            // 
            minMaxMinimumRadio.AutoSize = true;
            minMaxMinimumRadio.Location = new Point(182, 50);
            minMaxMinimumRadio.Name = "minMaxMinimumRadio";
            minMaxMinimumRadio.Size = new Size(93, 24);
            minMaxMinimumRadio.TabIndex = 4;
            minMaxMinimumRadio.Text = "Minimum";
            minMaxMinimumRadio.UseVisualStyleBackColor = true;
            // 
            // minMaxMaximumRadio
            // 
            minMaxMaximumRadio.AutoSize = true;
            minMaxMaximumRadio.Checked = true;
            minMaxMaximumRadio.Location = new Point(182, 23);
            minMaxMaximumRadio.Name = "minMaxMaximumRadio";
            minMaxMaximumRadio.Size = new Size(96, 24);
            minMaxMaximumRadio.TabIndex = 3;
            minMaxMaximumRadio.TabStop = true;
            minMaxMaximumRadio.Text = "Maximum";
            minMaxMaximumRadio.UseVisualStyleBackColor = true;
            // 
            // minMaxBtn
            // 
            minMaxBtn.Location = new Point(6, 80);
            minMaxBtn.Name = "minMaxBtn";
            minMaxBtn.Size = new Size(301, 29);
            minMaxBtn.TabIndex = 2;
            minMaxBtn.Text = "Keresés";
            minMaxBtn.UseVisualStyleBackColor = true;
            minMaxBtn.Click += minMaxBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 1;
            label2.Text = "Rendszám típus";
            // 
            // plateSearchCombo
            // 
            plateSearchCombo.FormattingEnabled = true;
            plateSearchCombo.Items.AddRange(new object[] { "AAA-000", "AA AA 000", "Saját" });
            plateSearchCombo.Location = new Point(6, 46);
            plateSearchCombo.Name = "plateSearchCombo";
            plateSearchCombo.Size = new Size(151, 28);
            plateSearchCombo.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(searchBtn);
            groupBox3.Location = new Point(696, 274);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(320, 87);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Keresés";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 23);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 2;
            label4.Text = "Rendszám";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 46);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(147, 27);
            textBox2.TabIndex = 1;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(167, 44);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(147, 29);
            searchBtn.TabIndex = 0;
            searchBtn.Text = "Keresés";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(decisionBtn);
            groupBox4.Controls.Add(radioButton6);
            groupBox4.Controls.Add(customPlate);
            groupBox4.Location = new Point(696, 367);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(320, 100);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Eldöntés";
            // 
            // decisionBtn
            // 
            decisionBtn.Location = new Point(187, 21);
            decisionBtn.Name = "decisionBtn";
            decisionBtn.Size = new Size(120, 59);
            decisionBtn.TabIndex = 2;
            decisionBtn.Text = "Keresés";
            decisionBtn.UseVisualStyleBackColor = true;
            decisionBtn.Click += decisionBtn_Click;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(6, 56);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(175, 24);
            radioButton6.TabIndex = 1;
            radioButton6.TabStop = true;
            radioButton6.Text = "Nincs 'saját' rendszám";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // customPlate
            // 
            customPlate.AutoSize = true;
            customPlate.Checked = true;
            customPlate.Location = new Point(6, 26);
            customPlate.Name = "customPlate";
            customPlate.Size = new Size(163, 24);
            customPlate.TabIndex = 0;
            customPlate.TabStop = true;
            customPlate.Text = "Van 'saját' rendszám";
            customPlate.UseVisualStyleBackColor = true;
            // 
            // avgLbl
            // 
            avgLbl.AutoSize = true;
            avgLbl.Location = new Point(696, 498);
            avgLbl.Name = "avgLbl";
            avgLbl.Size = new Size(123, 20);
            avgLbl.TabIndex = 6;
            avgLbl.Text = "Átlag értékelés: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 533);
            Controls.Add(avgLbl);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Városlátogatás kiértékelő";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn platenumber;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn age;
        private DataGridViewTextBoxColumn city;
        private DataGridViewTextBoxColumn score;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Label label1;
        private Button countBtn;
        private RadioButton countBelowRadio;
        private RadioButton countAboveRadio;
        private GroupBox groupBox2;
        private RadioButton minMaxMaximumRadio;
        private Button minMaxBtn;
        private Label label2;
        private ComboBox plateSearchCombo;
        private RadioButton minMaxMinimumRadio;
        private GroupBox groupBox3;
        private Button searchBtn;
        private Label label4;
        private TextBox textBox2;
        private GroupBox groupBox4;
        private Button decisionBtn;
        private RadioButton radioButton6;
        private RadioButton customPlate;
        private Label avgLbl;
        private BindingSource bindingSource1;
    }
}
