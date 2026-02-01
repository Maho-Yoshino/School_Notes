namespace listBox_pelda
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
            addBtn = new Button();
            delSelectedBtn = new Button();
            delAllBtn = new Button();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // addBtn
            // 
            addBtn.Location = new Point(179, 12);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(130, 29);
            addBtn.TabIndex = 0;
            addBtn.Text = "Hozzáad";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // delSelectedBtn
            // 
            delSelectedBtn.Location = new Point(179, 47);
            delSelectedBtn.Name = "delSelectedBtn";
            delSelectedBtn.Size = new Size(130, 29);
            delSelectedBtn.TabIndex = 1;
            delSelectedBtn.Text = "Kijelölt törlése";
            delSelectedBtn.UseVisualStyleBackColor = true;
            delSelectedBtn.Click += delSelectedBtn_Click;
            // 
            // delAllBtn
            // 
            delAllBtn.Location = new Point(179, 82);
            delAllBtn.Name = "delAllBtn";
            delAllBtn.Size = new Size(130, 29);
            delAllBtn.TabIndex = 2;
            delAllBtn.Text = "Összes törlése";
            delAllBtn.UseVisualStyleBackColor = true;
            delAllBtn.Click += delAllBtn_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 47);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(161, 244);
            listBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(161, 27);
            textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 305);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(delAllBtn);
            Controls.Add(delSelectedBtn);
            Controls.Add(addBtn);
            MaximizeBox = false;
            Name = "Form1";
            Text = "A ListBox használata";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addBtn;
        private Button delSelectedBtn;
        private Button delAllBtn;
        private ListBox listBox1;
        private TextBox textBox1;
    }
}
