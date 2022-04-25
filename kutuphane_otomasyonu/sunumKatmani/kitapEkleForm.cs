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
    public partial class kitapEkleForm : Form
    {
        public kitapEkleForm()
        {
            InitializeComponent();
        }

        private void kitapEkleForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // eklenecek kitap bilgilerini textBox'lardan alıp string tipli değişkenlerimize atıyoruz.
            string kitapAdi = textBox1.Text;
            string kitapTur = textBox2.Text;
            string yazar = textBox3.Text;
            string sayfaSayisi = textBox4.Text;
            string basimTarihi = textBox5.Text;
            string kitapKodu = textBox6.Text;

            bool sonuc; //boolean sonuç değişkenimizi oluşturalım, yönlendiricinin cevabına göre işlemin başarılı olup olmadığını anlayacağız.

            kitapYonlendirici kitapYonlendirici = new kitapYonlendirici(); //yönlendiriciyi oluşturalım.


            //alanlar boş girilmişse uyarı verilsin ve işlem yapılmasın, eğer tüm alanlar doluysa kitap ekleme metodunu çağıralım.
            if(textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty || textBox6.Text == string.Empty)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
            else
            {
                sonuc = kitapYonlendirici.kitapEkle(kitapAdi, kitapKodu, kitapTur, yazar, sayfaSayisi, basimTarihi); //yönlendiriciyi kullanarak kitapEkle metodunu çağıralım.

                if (sonuc == true) //yönlendiricinin cevabına göre işlem başarılı ya da başarısız olacaktır.
                {
                    MessageBox.Show("Kitap başarıyla eklendi!");
                }
                else
                {
                    MessageBox.Show("Kitap eklenemedi!!!");
                }
            }

        }
    }
}
