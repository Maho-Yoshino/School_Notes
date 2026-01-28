namespace Petrik_Proba1
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
            src_file_label = new Label();
            source_file_txtbox = new TextBox();
            listBox1 = new ListBox();
            terulet_atlag_btn = new Button();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            count_btn = new Button();
            label1 = new Label();
            result_file_txtbox = new TextBox();
            output_btn = new Button();
            label2 = new Label();
            minmax_combo = new ComboBox();
            minmax_select_btn = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            showInList_chkbox = new CheckBox();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // src_file_label
            // 
            src_file_label.AutoSize = true;
            src_file_label.Location = new Point(5, 11);
            src_file_label.Name = "src_file_label";
            src_file_label.Size = new Size(108, 20);
            src_file_label.TabIndex = 0;
            src_file_label.Text = "Forrásfájl neve:";
            // 
            // source_file_txtbox
            // 
            source_file_txtbox.Location = new Point(5, 34);
            source_file_txtbox.Name = "source_file_txtbox";
            source_file_txtbox.Size = new Size(231, 27);
            source_file_txtbox.TabIndex = 1;
            source_file_txtbox.Text = "adat.txt";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(5, 67);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(231, 344);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // terulet_atlag_btn
            // 
            terulet_atlag_btn.Location = new Point(5, 419);
            terulet_atlag_btn.Name = "terulet_atlag_btn";
            terulet_atlag_btn.Size = new Size(231, 29);
            terulet_atlag_btn.TabIndex = 3;
            terulet_atlag_btn.Text = "Területek átlaga";
            terulet_atlag_btn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(256, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 88);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mit számoljunk?";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 53);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(211, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Legfeljebb 100.000 területű";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(6, 23);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(225, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "100.000-nél nagyobb területű";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // count_btn
            // 
            count_btn.Location = new Point(256, 105);
            count_btn.Name = "count_btn";
            count_btn.Size = new Size(250, 29);
            count_btn.TabIndex = 5;
            count_btn.Text = "Megszámolás";
            count_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(256, 137);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 6;
            label1.Text = "Eredményfájl neve:";
            // 
            // result_file_txtbox
            // 
            result_file_txtbox.Location = new Point(256, 160);
            result_file_txtbox.Name = "result_file_txtbox";
            result_file_txtbox.Size = new Size(250, 27);
            result_file_txtbox.TabIndex = 7;
            result_file_txtbox.Text = "eredmeny.txt";
            // 
            // output_btn
            // 
            output_btn.Location = new Point(256, 198);
            output_btn.Name = "output_btn";
            output_btn.Size = new Size(250, 29);
            output_btn.TabIndex = 8;
            output_btn.Text = "Kiírás";
            output_btn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 230);
            label2.Name = "label2";
            label2.Size = new Size(184, 20);
            label2.TabIndex = 9;
            label2.Text = "Minimum vagy maximum?";
            // 
            // minmax_combo
            // 
            minmax_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            minmax_combo.FormattingEnabled = true;
            minmax_combo.Items.AddRange(new object[] { "Minimum", "Maximum" });
            minmax_combo.Location = new Point(256, 260);
            minmax_combo.Name = "minmax_combo";
            minmax_combo.Size = new Size(250, 28);
            minmax_combo.TabIndex = 10;
            minmax_combo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // minmax_select_btn
            // 
            minmax_select_btn.Location = new Point(256, 294);
            minmax_select_btn.Name = "minmax_select_btn";
            minmax_select_btn.Size = new Size(250, 29);
            minmax_select_btn.TabIndex = 11;
            minmax_select_btn.Text = "Minimum/Maximum kiválasztása";
            minmax_select_btn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 326);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 12;
            label3.Text = "Ország keresése";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(256, 349);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 27);
            textBox1.TabIndex = 13;
            // 
            // showInList_chkbox
            // 
            showInList_chkbox.AutoSize = true;
            showInList_chkbox.Checked = true;
            showInList_chkbox.CheckState = CheckState.Checked;
            showInList_chkbox.Location = new Point(259, 385);
            showInList_chkbox.Name = "showInList_chkbox";
            showInList_chkbox.Size = new Size(224, 24);
            showInList_chkbox.TabIndex = 14;
            showInList_chkbox.Text = "Találatok kijelölése a listában";
            showInList_chkbox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(256, 419);
            button1.Name = "button1";
            button1.Size = new Size(250, 29);
            button1.TabIndex = 15;
            button1.Text = "Keresés";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 460);
            Controls.Add(button1);
            Controls.Add(showInList_chkbox);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(minmax_select_btn);
            Controls.Add(minmax_combo);
            Controls.Add(label2);
            Controls.Add(output_btn);
            Controls.Add(result_file_txtbox);
            Controls.Add(label1);
            Controls.Add(count_btn);
            Controls.Add(groupBox1);
            Controls.Add(terulet_atlag_btn);
            Controls.Add(listBox1);
            Controls.Add(source_file_txtbox);
            Controls.Add(src_file_label);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Példa Windows Forms alkalmazás";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label src_file_label;
        private TextBox source_file_txtbox;
        private ListBox listBox1;
        private Button terulet_atlag_btn;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button count_btn;
        private Label label1;
        private TextBox result_file_txtbox;
        private Button output_btn;
        private Label label2;
        private ComboBox minmax_combo;
        private Button minmax_select_btn;
        private Label label3;
        private TextBox textBox1;
        private CheckBox showInList_chkbox;
        private Button button1;
    }
}
