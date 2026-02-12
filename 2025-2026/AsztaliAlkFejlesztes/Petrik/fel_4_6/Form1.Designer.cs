namespace fel_4_6
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
            pontszamInput = new TextBox();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Pontszám:";
            // 
            // pontszamInput
            // 
            pontszamInput.Location = new Point(90, 6);
            pontszamInput.Name = "pontszamInput";
            pontszamInput.Size = new Size(125, 27);
            pontszamInput.TabIndex = 1;
            pontszamInput.KeyPress += pontszamInput_KeyPress;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            resultLabel.Location = new Point(12, 43);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(179, 20);
            resultLabel.TabIndex = 2;
            resultLabel.Text = "Adjon meg pontszámot!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 94);
            Controls.Add(resultLabel);
            Controls.Add(pontszamInput);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox pontszamInput;
        private Label resultLabel;
    }
}
