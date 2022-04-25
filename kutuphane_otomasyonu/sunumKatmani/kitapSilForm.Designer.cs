namespace kutuphane_otomasyonu.sunumKatmani
{
    partial class kitapSilForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kitapSilButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kitap kodunu giriniz :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 1;
            // 
            // kitapSilButton
            // 
            this.kitapSilButton.Location = new System.Drawing.Point(204, 74);
            this.kitapSilButton.Name = "kitapSilButton";
            this.kitapSilButton.Size = new System.Drawing.Size(89, 46);
            this.kitapSilButton.TabIndex = 2;
            this.kitapSilButton.Text = "Kitabı Sil";
            this.kitapSilButton.UseVisualStyleBackColor = true;
            this.kitapSilButton.Click += new System.EventHandler(this.kitapSilButton_Click);
            // 
            // kitapSilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Violet;
            this.ClientSize = new System.Drawing.Size(305, 138);
            this.Controls.Add(this.kitapSilButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "kitapSilForm";
            this.Text = "kitapSilForm";
            this.Load += new System.EventHandler(this.kitapSilForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button kitapSilButton;
    }
}