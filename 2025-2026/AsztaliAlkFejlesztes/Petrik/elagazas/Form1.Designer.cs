namespace elagazas
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
            mainLabel = new Label();
            kerLabel = new Label();
            terLabel = new Label();
            mainInput = new TextBox();
            isCircleBtn = new RadioButton();
            isSquareBtn = new RadioButton();
            typeGroupBox = new GroupBox();
            calcBtn = new Button();
            typeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.Location = new Point(12, 9);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(160, 20);
            mainLabel.TabIndex = 0;
            mainLabel.Text = "A kör sugara:";
            // 
            // kerLabel
            // 
            kerLabel.AutoSize = true;
            kerLabel.Location = new Point(12, 125);
            kerLabel.Name = "kerLabel";
            kerLabel.Size = new Size(124, 20);
            kerLabel.TabIndex = 1;
            kerLabel.Text = "A kör kerülete: 48";
            // 
            // terLabel
            // 
            terLabel.AutoSize = true;
            terLabel.Location = new Point(12, 157);
            terLabel.Name = "terLabel";
            terLabel.Size = new Size(130, 20);
            terLabel.TabIndex = 2;
            terLabel.Text = "A kör területe: 144";
            // 
            // mainInput
            // 
            mainInput.Location = new Point(12, 32);
            mainInput.Name = "mainInput";
            mainInput.Size = new Size(160, 27);
            mainInput.TabIndex = 3;
            mainInput.Text = "12";
            // 
            // isCircleBtn
            // 
            isCircleBtn.AutoSize = true;
            isCircleBtn.Checked = true;
            isCircleBtn.Location = new Point(6, 26);
            isCircleBtn.Name = "isCircleBtn";
            isCircleBtn.Size = new Size(53, 24);
            isCircleBtn.TabIndex = 4;
            isCircleBtn.TabStop = true;
            isCircleBtn.Text = "Kör";
            isCircleBtn.UseVisualStyleBackColor = true;
            isCircleBtn.CheckedChanged += isCircleBtn_CheckedChanged;
            // 
            // isSquareBtn
            // 
            isSquareBtn.AutoSize = true;
            isSquareBtn.Location = new Point(6, 56);
            isSquareBtn.Name = "isSquareBtn";
            isSquareBtn.Size = new Size(85, 24);
            isSquareBtn.TabIndex = 5;
            isSquareBtn.Text = "Négyzet";
            isSquareBtn.UseVisualStyleBackColor = true;
            isSquareBtn.CheckedChanged += isSquareBtn_CheckedChanged;
            // 
            // typeGroupBox
            // 
            typeGroupBox.Controls.Add(isCircleBtn);
            typeGroupBox.Controls.Add(isSquareBtn);
            typeGroupBox.Location = new Point(178, 9);
            typeGroupBox.Name = "typeGroupBox";
            typeGroupBox.Size = new Size(152, 93);
            typeGroupBox.TabIndex = 6;
            typeGroupBox.TabStop = false;
            typeGroupBox.Text = "Kör vagy négyzet?";
            // 
            // calcBtn
            // 
            calcBtn.Location = new Point(12, 73);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new Size(160, 29);
            calcBtn.TabIndex = 7;
            calcBtn.Text = "Kiszámol";
            calcBtn.UseVisualStyleBackColor = true;
            calcBtn.Click += calcBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 201);
            Controls.Add(calcBtn);
            Controls.Add(typeGroupBox);
            Controls.Add(mainInput);
            Controls.Add(kerLabel);
            Controls.Add(terLabel);
            Controls.Add(mainLabel);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Alakzatok kerülete, területe";
            typeGroupBox.ResumeLayout(false);
            typeGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label mainLabel;
        private Label kerLabel;
        private Label terLabel;
        private TextBox mainInput;
        private RadioButton isCircleBtn;
        private RadioButton isSquareBtn;
        private GroupBox typeGroupBox;
        private Button calcBtn;
    }
}
