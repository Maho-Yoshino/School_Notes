namespace projekt_20260319
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
            tabControl1 = new TabControl();
            rectTab = new TabPage();
            pizzaTab = new TabPage();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            aOldalTxt = new TextBox();
            bOldalTxt = new TextBox();
            szamitasBtn = new Button();
            tabControl1.SuspendLayout();
            rectTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(rectTab);
            tabControl1.Controls.Add(pizzaTab);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 448);
            tabControl1.TabIndex = 0;
            // 
            // rectTab
            // 
            rectTab.Controls.Add(szamitasBtn);
            rectTab.Controls.Add(bOldalTxt);
            rectTab.Controls.Add(aOldalTxt);
            rectTab.Controls.Add(label4);
            rectTab.Controls.Add(label3);
            rectTab.Controls.Add(label2);
            rectTab.Controls.Add(label1);
            rectTab.Location = new Point(4, 29);
            rectTab.Name = "rectTab";
            rectTab.Padding = new Padding(3);
            rectTab.Size = new Size(792, 415);
            rectTab.TabIndex = 0;
            rectTab.Text = "Téglalap";
            rectTab.UseVisualStyleBackColor = true;
            // 
            // pizzaTab
            // 
            pizzaTab.Location = new Point(4, 29);
            pizzaTab.Name = "pizzaTab";
            pizzaTab.Padding = new Padding(3);
            pizzaTab.Size = new Size(792, 415);
            pizzaTab.TabIndex = 1;
            pizzaTab.Text = "Pizza rendelés";
            pizzaTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 17);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 70);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(182, 130);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(238, 130);
            label4.MaximumSize = new Size(125, 0);
            label4.MinimumSize = new Size(125, 0);
            label4.Name = "label4";
            label4.Size = new Size(125, 20);
            label4.TabIndex = 3;
            label4.Text = "teruletLbl";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // aOldalTxt
            // 
            aOldalTxt.Location = new Point(238, 14);
            aOldalTxt.Name = "aOldalTxt";
            aOldalTxt.Size = new Size(125, 27);
            aOldalTxt.TabIndex = 4;
            aOldalTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // bOldalTxt
            // 
            bOldalTxt.Location = new Point(238, 67);
            bOldalTxt.Name = "bOldalTxt";
            bOldalTxt.Size = new Size(125, 27);
            bOldalTxt.TabIndex = 5;
            bOldalTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // szamitasBtn
            // 
            szamitasBtn.Location = new Point(211, 221);
            szamitasBtn.Name = "szamitasBtn";
            szamitasBtn.Size = new Size(94, 29);
            szamitasBtn.TabIndex = 6;
            szamitasBtn.Text = "Számítás";
            szamitasBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            rectTab.ResumeLayout(false);
            rectTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage rectTab;
        private TabPage pizzaTab;
        private Button szamitasBtn;
        private TextBox bOldalTxt;
        private TextBox aOldalTxt;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
