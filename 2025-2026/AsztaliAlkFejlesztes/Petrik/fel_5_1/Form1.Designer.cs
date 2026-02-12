namespace fel_5_1
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
            this.parosLabel = new Label();
            paratlanLabel = new Label();
            this.parosLB = new ListBox();
            paratlanLB = new ListBox();
            readBtn = new Button();
            writeBtn = new Button();
            SuspendLayout();
            // 
            // parosLabel
            // 
            this.parosLabel.AutoSize = true;
            this.parosLabel.Location = new Point(12, 9);
            this.parosLabel.Name = "parosLabel";
            this.parosLabel.Size = new Size(44, 20);
            this.parosLabel.TabIndex = 0;
            this.parosLabel.Text = "Páros";
            // 
            // paratlanLabel
            // 
            paratlanLabel.AutoSize = true;
            paratlanLabel.Location = new Point(188, 9);
            paratlanLabel.Name = "paratlanLabel";
            paratlanLabel.Size = new Size(62, 20);
            paratlanLabel.TabIndex = 1;
            paratlanLabel.Text = "Páratlan";
            // 
            // parosLB
            // 
            this.parosLB.FormattingEnabled = true;
            this.parosLB.Location = new Point(12, 36);
            this.parosLB.Name = "parosLB";
            this.parosLB.Size = new Size(150, 324);
            this.parosLB.TabIndex = 2;
            // 
            // paratlanLB
            // 
            paratlanLB.FormattingEnabled = true;
            paratlanLB.Location = new Point(188, 36);
            paratlanLB.Name = "paratlanLB";
            paratlanLB.Size = new Size(150, 324);
            paratlanLB.TabIndex = 3;
            // 
            // readBtn
            // 
            readBtn.Location = new Point(12, 366);
            readBtn.Name = "readBtn";
            readBtn.Size = new Size(150, 29);
            readBtn.TabIndex = 4;
            readBtn.Text = "Beolvasás";
            readBtn.UseVisualStyleBackColor = true;
            readBtn.Click += readBtn_Click;
            // 
            // writeBtn
            // 
            writeBtn.Location = new Point(188, 366);
            writeBtn.Name = "writeBtn";
            writeBtn.Size = new Size(150, 29);
            writeBtn.TabIndex = 5;
            writeBtn.Text = "Kiíratás";
            writeBtn.UseVisualStyleBackColor = true;
            writeBtn.Click += writeBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 406);
            Controls.Add(writeBtn);
            Controls.Add(readBtn);
            Controls.Add(paratlanLB);
            Controls.Add(this.parosLB);
            Controls.Add(paratlanLabel);
            Controls.Add(this.parosLabel);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Páros-Páratlan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label parosLabel;
        private Label paratlanLabel;
        private ListBox parosLB;
        private ListBox paratlanLB;
        private Button readBtn;
        private Button writeBtn;
    }
}
