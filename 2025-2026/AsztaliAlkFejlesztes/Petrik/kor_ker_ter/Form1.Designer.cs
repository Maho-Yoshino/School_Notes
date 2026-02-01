namespace kor_ker_ter
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
            radiusInput = new TextBox();
            calcBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "A kör sugara:";
            // 
            // radiusInput
            // 
            radiusInput.Location = new Point(14, 32);
            radiusInput.Name = "radiusInput";
            radiusInput.Size = new Size(125, 27);
            radiusInput.TabIndex = 4;
            radiusInput.Text = "0";
            // 
            // calcBtn
            // 
            calcBtn.Location = new Point(12, 65);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new Size(94, 29);
            calcBtn.TabIndex = 5;
            calcBtn.Text = "Kiszámol";
            calcBtn.UseVisualStyleBackColor = true;
            calcBtn.Click += calcBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 177);
            Controls.Add(calcBtn);
            Controls.Add(radiusInput);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Kör kerülete, területe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox radiusInput;
        private Button calcBtn;
    }
}
