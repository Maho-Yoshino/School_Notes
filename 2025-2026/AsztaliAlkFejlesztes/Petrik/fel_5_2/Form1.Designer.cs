namespace fel_5_2
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
            loadBtn = new Button();
            listBox1 = new ListBox();
            avgBtn = new Button();
            countGroupBox = new GroupBox();
            countSmallerRadio = new RadioButton();
            countBiggerRadio = new RadioButton();
            countBtn = new Button();
            writeBtn = new Button();
            label3 = new Label();
            minMaxCombo = new ComboBox();
            minmaxBtn = new Button();
            label4 = new Label();
            textBox3 = new TextBox();
            checkBox1 = new CheckBox();
            searchBtn = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            countGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // loadBtn
            // 
            loadBtn.Location = new Point(12, 12);
            loadBtn.Name = "loadBtn";
            loadBtn.Size = new Size(224, 29);
            loadBtn.TabIndex = 2;
            loadBtn.Text = "Betöltés";
            loadBtn.UseVisualStyleBackColor = true;
            loadBtn.Click += loadBtn_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 82);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(224, 304);
            listBox1.TabIndex = 3;
            // 
            // avgBtn
            // 
            avgBtn.Location = new Point(12, 392);
            avgBtn.Name = "avgBtn";
            avgBtn.Size = new Size(224, 29);
            avgBtn.TabIndex = 4;
            avgBtn.Text = "Területek átlaga";
            avgBtn.UseVisualStyleBackColor = true;
            // 
            // countGroupBox
            // 
            countGroupBox.Controls.Add(countSmallerRadio);
            countGroupBox.Controls.Add(countBiggerRadio);
            countGroupBox.Location = new Point(242, 12);
            countGroupBox.Name = "countGroupBox";
            countGroupBox.Size = new Size(243, 82);
            countGroupBox.TabIndex = 5;
            countGroupBox.TabStop = false;
            countGroupBox.Text = "Mit számoljunk?";
            // 
            // countSmallerRadio
            // 
            countSmallerRadio.AutoSize = true;
            countSmallerRadio.Location = new Point(6, 56);
            countSmallerRadio.Name = "countSmallerRadio";
            countSmallerRadio.Size = new Size(211, 24);
            countSmallerRadio.TabIndex = 6;
            countSmallerRadio.TabStop = true;
            countSmallerRadio.Text = "Legfeljebb 100.000 területű";
            countSmallerRadio.UseVisualStyleBackColor = true;
            // 
            // countBiggerRadio
            // 
            countBiggerRadio.AutoSize = true;
            countBiggerRadio.Location = new Point(6, 26);
            countBiggerRadio.Name = "countBiggerRadio";
            countBiggerRadio.Size = new Size(225, 24);
            countBiggerRadio.TabIndex = 0;
            countBiggerRadio.TabStop = true;
            countBiggerRadio.Text = "100.000-nél nagyobb területű";
            countBiggerRadio.UseVisualStyleBackColor = true;
            // 
            // countBtn
            // 
            countBtn.Location = new Point(242, 98);
            countBtn.Name = "countBtn";
            countBtn.Size = new Size(243, 29);
            countBtn.TabIndex = 6;
            countBtn.Text = "Megszámolás";
            countBtn.UseVisualStyleBackColor = true;
            // 
            // writeBtn
            // 
            writeBtn.Location = new Point(242, 274);
            writeBtn.Name = "writeBtn";
            writeBtn.Size = new Size(243, 29);
            writeBtn.TabIndex = 9;
            writeBtn.Text = "Kiírás";
            writeBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(242, 130);
            label3.Name = "label3";
            label3.Size = new Size(184, 20);
            label3.TabIndex = 10;
            label3.Text = "Minimum vagy maximum?";
            // 
            // minMaxCombo
            // 
            minMaxCombo.FormattingEnabled = true;
            minMaxCombo.Items.AddRange(new object[] { "Minimum", "Maximum" });
            minMaxCombo.Location = new Point(242, 153);
            minMaxCombo.Name = "minMaxCombo";
            minMaxCombo.Size = new Size(243, 28);
            minMaxCombo.TabIndex = 11;
            // 
            // minmaxBtn
            // 
            minmaxBtn.Font = new Font("Segoe UI", 9F);
            minmaxBtn.Location = new Point(242, 187);
            minmaxBtn.Name = "minmaxBtn";
            minmaxBtn.Size = new Size(243, 29);
            minmaxBtn.TabIndex = 12;
            minmaxBtn.Text = "Minimum/maximum kiválasztása";
            minmaxBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(242, 306);
            label4.Name = "label4";
            label4.Size = new Size(118, 20);
            label4.TabIndex = 13;
            label4.Text = "Ország keresése:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(242, 329);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(243, 27);
            textBox3.TabIndex = 14;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(242, 362);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(224, 24);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Találatok kijelölése a listában";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(242, 392);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(243, 29);
            searchBtn.TabIndex = 16;
            searchBtn.Text = "Keresés";
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 437);
            Controls.Add(searchBtn);
            Controls.Add(checkBox1);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(minmaxBtn);
            Controls.Add(minMaxCombo);
            Controls.Add(label3);
            Controls.Add(writeBtn);
            Controls.Add(countBtn);
            Controls.Add(countGroupBox);
            Controls.Add(avgBtn);
            Controls.Add(listBox1);
            Controls.Add(loadBtn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            countGroupBox.ResumeLayout(false);
            countGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button loadBtn;
        private ListBox listBox1;
        private Button countBtn;
        private GroupBox countGroupBox;
        private RadioButton countSmallerRadio;
        private RadioButton countBiggerRadio;
        private Button writeBtn;
        private Button minmaxBtn;
        private Label label3;
        private ComboBox minMaxCombo;
        private Button avgBtn;
        private Label label4;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private Button searchBtn;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
