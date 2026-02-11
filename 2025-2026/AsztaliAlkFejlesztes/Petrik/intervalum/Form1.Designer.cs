namespace intervalum
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
            resultLabel = new Label();
            calcBtn = new Button();
            ahInput = new TextBox();
            fhInput = new TextBox();
            numInput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Alsó határ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 9);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 1;
            label2.Text = "Felső határ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 87);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 2;
            label3.Text = "A megadott szám:";
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.BackColor = SystemColors.Control;
            resultLabel.Cursor = Cursors.IBeam;
            resultLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            resultLabel.Location = new Point(5, 165);
            resultLabel.MinimumSize = new Size(285, 0);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(285, 20);
            resultLabel.TabIndex = 3;
            resultLabel.Text = "Nincs benne az intervallumban";
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // calcBtn
            // 
            calcBtn.Location = new Point(174, 108);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new Size(112, 29);
            calcBtn.TabIndex = 4;
            calcBtn.Text = "Megállapít";
            calcBtn.UseVisualStyleBackColor = true;
            calcBtn.Click += button1_Click;
            // 
            // fhInput
            // 
            ahInput.Location = new Point(12, 32);
            ahInput.Name = "fhInput";
            ahInput.Size = new Size(79, 27);
            ahInput.TabIndex = 5;
            // 
            // ahInput
            // 
            fhInput.Location = new Point(202, 32);
            fhInput.Name = "ahInput";
            fhInput.Size = new Size(84, 27);
            fhInput.TabIndex = 6;
            // 
            // numInput
            // 
            numInput.Location = new Point(12, 110);
            numInput.Name = "numInput";
            numInput.Size = new Size(146, 27);
            numInput.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 194);
            Controls.Add(numInput);
            Controls.Add(fhInput);
            Controls.Add(ahInput);
            Controls.Add(calcBtn);
            Controls.Add(resultLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label resultLabel;
        private Button calcBtn;
        private TextBox ahInput;
        private TextBox fhInput;
        private TextBox numInput;
    }
}
