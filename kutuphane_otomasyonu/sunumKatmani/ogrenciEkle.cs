using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kutuphane_otomasyonu.isKatmani; //yönlendirici oluşturabilmek için eklendi.

namespace kutuphane_otomasyonu.sunumKatmani
{
    public partial class ogrenciEkle : Form
    {
        public ogrenciEkle()
        {
            InitializeComponent();
        }

        private void ogrenciEkle_Load(object sender, EventArgs e)
        {

        }

        private void ogrEkle_button_Click(object sender, EventArgs e)
        {
            //eklenecek öğrencinin bilgileri lazım. bunları textboxlardan alıp string değişkenler üzerinde depolayalım.
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string numara = textBox3.Text;

            bool sonuc; //boolean sonuç değişkenini oluşturalım. işlemin başarılı olup olmadığını bu değişken sayesinde anlayacağız.
            
            //eğer tüm alanlar doldurulmamışsa uyarı verilsin ve ekleme işlemi yapılmasın. aksi durumda ekleme işlemi yapılsın.
            if(textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
            else
            {
                OgrenciYonlendirici yonlendirici = new OgrenciYonlendirici(); //yönlendiriciyi oluşturalım.

                sonuc = yonlendirici.ogrenciEkle(ad, soyad, numara); //yönlendiriciyi kullanarak öğrenci ekleme metodunu çağıralım.

                if (sonuc == true) //yönlendiricinin return ettiği sonuca göre işlemin başarılı olup olmadığını anlayacağız.
                {
                    MessageBox.Show("Öğrenci başarıyla eklendi!");
                }
                else
                {
                    MessageBox.Show("Öğrenci Eklenemedi!!!");
                }
            }
        }
    }
}
