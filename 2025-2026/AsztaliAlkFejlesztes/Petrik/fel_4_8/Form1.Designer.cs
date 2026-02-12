namespace fel_4_8
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
            yearInput = new TextBox();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 0;
            label1.Text = "Év:";
            // 
            // yearInput
            // 
            yearInput.Location = new Point(45, 9);
            yearInput.Name = "yearInput";
            yearInput.Size = new Size(125, 27);
            yearInput.TabIndex = 1;
            yearInput.KeyPress += yearInput_KeyPress;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(12, 39);
            resultLabel.MaximumSize = new Size(160, 0);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(160, 40);
            resultLabel.TabIndex = 2;
            resultLabel.Text = "Kérem adjon meg egy évszámot";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(182, 94);
            Controls.Add(resultLabel);
            Controls.Add(yearInput);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox yearInput;
        private Label resultLabel;
    }
}
