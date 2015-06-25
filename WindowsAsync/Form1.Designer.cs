namespace WindowsAsync
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startBtn = new System.Windows.Forms.Button();
            this.resultatTxt = new System.Windows.Forms.TextBox();
            this.skrivBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(107, 33);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Starta";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // resultatTxt
            // 
            this.resultatTxt.Location = new System.Drawing.Point(32, 142);
            this.resultatTxt.Multiline = true;
            this.resultatTxt.Name = "resultatTxt";
            this.resultatTxt.Size = new System.Drawing.Size(212, 146);
            this.resultatTxt.TabIndex = 1;
            // 
            // skrivBtn
            // 
            this.skrivBtn.Location = new System.Drawing.Point(107, 62);
            this.skrivBtn.Name = "skrivBtn";
            this.skrivBtn.Size = new System.Drawing.Size(75, 23);
            this.skrivBtn.TabIndex = 2;
            this.skrivBtn.Text = "Skriv medd";
            this.skrivBtn.UseVisualStyleBackColor = true;
            this.skrivBtn.Click += new System.EventHandler(this.skrivBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ej responsiv";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.skrivBtn);
            this.Controls.Add(this.resultatTxt);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox resultatTxt;
        private System.Windows.Forms.Button skrivBtn;
        private System.Windows.Forms.Button button1;
    }
}

