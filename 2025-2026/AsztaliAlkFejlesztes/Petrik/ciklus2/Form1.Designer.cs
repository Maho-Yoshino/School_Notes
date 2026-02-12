using Microsoft.VisualBasic;

namespace ciklus2
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
            paratlanListBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            parosListBox = new ListBox();
            SuspendLayout();
            // 
            // paratlanListBox
            // 
            paratlanListBox.FormattingEnabled = true;
            paratlanListBox.Location = new Point(168, 39);
            paratlanListBox.Name = "paratlanListBox";
            paratlanListBox.Size = new Size(135, 304);
            paratlanListBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 2;
            label1.Text = "Páros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 9);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 3;
            label2.Text = "Páratlan";
            // 
            // button1
            // 
            button1.Location = new Point(12, 349);
            button1.Name = "button1";
            button1.Size = new Size(135, 29);
            button1.TabIndex = 4;
            button1.Text = "Adatbevitel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(150, 349);
            label3.MaximumSize = new Size(160, 0);
            label3.Name = "label3";
            label3.Size = new Size(159, 40);
            label3.TabIndex = 5;
            label3.Text = "Az adatok beolvasása 0 végjelig történik!";
            // 
            // parosListBox
            // 
            parosListBox.FormattingEnabled = true;
            parosListBox.Location = new Point(12, 39);
            parosListBox.Name = "parosListBox";
            parosListBox.Size = new Size(135, 304);
            parosListBox.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 399);
            Controls.Add(parosListBox);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(paratlanListBox);
            Name = "Form1";
            Text = "Páros - Páratlan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox paratlanListBox;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private ListBox parosListBox;
    }
}
