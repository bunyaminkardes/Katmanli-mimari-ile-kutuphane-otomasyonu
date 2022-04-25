namespace kutuphane_otomasyonu.sunumKatmani
{
    partial class ogrenciTakip
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kitapIadesiEkle_button = new System.Windows.Forms.Button();
            this.kitapAlimiEkle_button = new System.Windows.Forms.Button();
            this.ogrListele_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(890, 312);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Öğrenci numarasını girin :";
            // 
            // kitapIadesiEkle_button
            // 
            this.kitapIadesiEkle_button.Location = new System.Drawing.Point(777, 387);
            this.kitapIadesiEkle_button.Name = "kitapIadesiEkle_button";
            this.kitapIadesiEkle_button.Size = new System.Drawing.Size(128, 51);
            this.kitapIadesiEkle_button.TabIndex = 3;
            this.kitapIadesiEkle_button.Text = "Kitap İade İşlemi";
            this.kitapIadesiEkle_button.UseVisualStyleBackColor = true;
            this.kitapIadesiEkle_button.Click += new System.EventHandler(this.kitapIadesiEkle_button_Click);
            // 
            // kitapAlimiEkle_button
            // 
            this.kitapAlimiEkle_button.Location = new System.Drawing.Point(643, 387);
            this.kitapAlimiEkle_button.Name = "kitapAlimiEkle_button";
            this.kitapAlimiEkle_button.Size = new System.Drawing.Size(128, 51);
            this.kitapAlimiEkle_button.TabIndex = 3;
            this.kitapAlimiEkle_button.Text = "Kitap Alım İşlemi";
            this.kitapAlimiEkle_button.UseVisualStyleBackColor = true;
            this.kitapAlimiEkle_button.Click += new System.EventHandler(this.kitapAlimiEkle_button_Click);
            // 
            // ogrListele_button
            // 
            this.ogrListele_button.Location = new System.Drawing.Point(327, 14);
            this.ogrListele_button.Name = "ogrListele_button";
            this.ogrListele_button.Size = new System.Drawing.Size(122, 33);
            this.ogrListele_button.TabIndex = 4;
            this.ogrListele_button.Text = "Listele";
            this.ogrListele_button.UseVisualStyleBackColor = true;
            this.ogrListele_button.Click += new System.EventHandler(this.ogrListele_button_Click);
            // 
            // ogrenciTakip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(917, 450);
            this.Controls.Add(this.ogrListele_button);
            this.Controls.Add(this.kitapAlimiEkle_button);
            this.Controls.Add(this.kitapIadesiEkle_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ogrenciTakip";
            this.Text = "Öğrenci Takibi";
            
            this.Load += new System.EventHandler(this.ogrenciTakip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kitapIadesiEkle_button;
        private System.Windows.Forms.Button kitapAlimiEkle_button;
        private System.Windows.Forms.Button ogrListele_button;
    }
}