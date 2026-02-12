namespace ciklus1
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
            mainBtn = new Button();
            SuspendLayout();
            // 
            // mainBtn
            // 
            mainBtn.Location = new Point(12, 12);
            mainBtn.Name = "mainBtn";
            mainBtn.Size = new Size(124, 29);
            mainBtn.TabIndex = 0;
            mainBtn.Text = "Indítás!";
            mainBtn.UseVisualStyleBackColor = true;
            mainBtn.Click += mainBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(148, 53);
            Controls.Add(mainBtn);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button mainBtn;
    }
}
