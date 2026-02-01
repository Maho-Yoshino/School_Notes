namespace teglalap_ker_ter
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
            resultsList = new ListBox();
            rectSideBInput = new TextBox();
            rectSideAInput = new TextBox();
            calculateBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 0;
            label1.Text = "A téglalap A oldala:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 1;
            label2.Text = "A téglalap B oldala:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 9);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 2;
            label3.Text = "Eredmények:";
            // 
            // resultsList
            // 
            resultsList.FormattingEnabled = true;
            resultsList.Location = new Point(184, 32);
            resultsList.Name = "resultsList";
            resultsList.Size = new Size(193, 144);
            resultsList.TabIndex = 3;
            // 
            // rectSideBInput
            // 
            rectSideBInput.Location = new Point(12, 85);
            rectSideBInput.Name = "rectSideBInput";
            rectSideBInput.Size = new Size(141, 27);
            rectSideBInput.TabIndex = 4;
            // 
            // rectSideAInput
            // 
            rectSideAInput.Location = new Point(12, 32);
            rectSideAInput.Name = "rectSideAInput";
            rectSideAInput.Size = new Size(141, 27);
            rectSideAInput.TabIndex = 5;
            // 
            // calculateBtn
            // 
            calculateBtn.Location = new Point(12, 118);
            calculateBtn.Name = "calculateBtn";
            calculateBtn.Size = new Size(94, 29);
            calculateBtn.TabIndex = 6;
            calculateBtn.Text = "Kiszámol";
            calculateBtn.UseVisualStyleBackColor = true;
            calculateBtn.Click += calculateBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 186);
            Controls.Add(calculateBtn);
            Controls.Add(rectSideAInput);
            Controls.Add(rectSideBInput);
            Controls.Add(resultsList);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Téglalap kerülete, területe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox resultsList;
        private TextBox rectSideBInput;
        private TextBox rectSideAInput;
        private Button calculateBtn;
    }
}
