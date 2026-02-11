namespace szoveges_ertekeles
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
            mainInput = new TextBox();
            calcBtn = new Button();
            gradeLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "Jegy:";
            // 
            // mainInput
            // 
            mainInput.Location = new Point(12, 32);
            mainInput.Name = "mainInput";
            mainInput.Size = new Size(125, 27);
            mainInput.TabIndex = 1;
            mainInput.Text = "5";
            // 
            // calcBtn
            // 
            calcBtn.Location = new Point(143, 32);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new Size(152, 29);
            calcBtn.TabIndex = 2;
            calcBtn.Text = "Szöveges kijelzés";
            calcBtn.UseVisualStyleBackColor = true;
            calcBtn.Click += calcBtn_Click;
            // 
            // gradeLabel
            // 
            gradeLabel.AutoSize = true;
            gradeLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            gradeLabel.Location = new Point(12, 80);
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Size = new Size(72, 35);
            gradeLabel.TabIndex = 3;
            gradeLabel.Text = "Jeles";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 143);
            Controls.Add(gradeLabel);
            Controls.Add(calcBtn);
            Controls.Add(mainInput);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox mainInput;
        private Button calcBtn;
        private Label gradeLabel;
    }
}
