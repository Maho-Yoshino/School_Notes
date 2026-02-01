namespace masodfok_egyenlet
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            this.calcBtn = new Button();
            this.InputA = new TextBox();
            this.InputB = new TextBox();
            InputC = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 3;
            label1.Text = "a =";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 4;
            label2.Text = "b =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 78);
            label3.Name = "label3";
            label3.Size = new Size(30, 20);
            label3.TabIndex = 5;
            label3.Text = "c =";
            // 
            // calcBtn
            // 
            this.calcBtn.Location = new Point(12, 108);
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.Size = new Size(190, 29);
            this.calcBtn.TabIndex = 6;
            this.calcBtn.Text = "Kiszámít";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Click += this.calcBtn_Click;
            // 
            // InputA
            // 
            this.InputA.Location = new Point(49, 9);
            this.InputA.Name = "InputA";
            this.InputA.Size = new Size(153, 27);
            this.InputA.TabIndex = 7;
            // 
            // InputB
            // 
            this.InputB.Location = new Point(49, 42);
            this.InputB.Name = "InputB";
            this.InputB.Size = new Size(153, 27);
            this.InputB.TabIndex = 8;
            // 
            // InputC
            // 
            InputC.Location = new Point(48, 75);
            InputC.Name = "InputC";
            InputC.Size = new Size(154, 27);
            InputC.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(214, 145);
            Controls.Add(InputC);
            Controls.Add(this.InputB);
            Controls.Add(this.InputA);
            Controls.Add(this.calcBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Másodfokú Egyenlet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button calcBtn;
        private TextBox InputA;
        private TextBox InputB;
        private TextBox InputC;
    }
}
