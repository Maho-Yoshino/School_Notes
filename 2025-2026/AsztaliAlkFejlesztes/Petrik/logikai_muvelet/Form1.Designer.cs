namespace logikai_muvelet
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
            Input1 = new CheckBox();
            Input2 = new CheckBox();
            changeBtn = new Button();
            ANDbtn = new Button();
            ORbtn = new Button();
            SuspendLayout();
            // 
            // Input1
            // 
            Input1.AutoSize = true;
            Input1.Location = new Point(12, 12);
            Input1.Name = "Input1";
            Input1.Size = new Size(66, 24);
            Input1.TabIndex = 0;
            Input1.Text = "Egyik";
            Input1.UseVisualStyleBackColor = true;
            // 
            // Input2
            // 
            Input2.AutoSize = true;
            Input2.Location = new Point(12, 42);
            Input2.Name = "Input2";
            Input2.Size = new Size(69, 24);
            Input2.TabIndex = 1;
            Input2.Text = "Másik";
            Input2.UseVisualStyleBackColor = true;
            // 
            // changeBtn
            // 
            changeBtn.Location = new Point(84, 12);
            changeBtn.Name = "changeBtn";
            changeBtn.Size = new Size(105, 54);
            changeBtn.TabIndex = 2;
            changeBtn.Text = "Állapot Váltása";
            changeBtn.UseVisualStyleBackColor = true;
            changeBtn.Click += changeBtn_Click;
            // 
            // ANDbtn
            // 
            ANDbtn.Location = new Point(12, 72);
            ANDbtn.Name = "ANDbtn";
            ANDbtn.Size = new Size(179, 29);
            ANDbtn.TabIndex = 3;
            ANDbtn.Text = "Logikai ÉS művelet";
            ANDbtn.UseVisualStyleBackColor = true;
            ANDbtn.Click += ANDbtn_Click;
            // 
            // ORbtn
            // 
            ORbtn.Location = new Point(12, 116);
            ORbtn.Name = "ORbtn";
            ORbtn.Size = new Size(179, 29);
            ORbtn.TabIndex = 4;
            ORbtn.Text = "Logikai VAGY művelet";
            ORbtn.UseVisualStyleBackColor = true;
            ORbtn.Click += ORbtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(201, 159);
            Controls.Add(ORbtn);
            Controls.Add(ANDbtn);
            Controls.Add(changeBtn);
            Controls.Add(Input2);
            Controls.Add(Input1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Logikai Műveletek";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox Input1;
        private CheckBox Input2;
        private Button button1;
        private Button button2;
        private Button changeBtn;
        private Button ANDbtn;
        private Button ORbtn;
    }
}
