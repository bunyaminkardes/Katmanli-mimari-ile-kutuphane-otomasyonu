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
using kutuphane_otomasyonu.veriKatmani; //liste oluşturabilmek için eklendi.

namespace kutuphane_otomasyonu.sunumKatmani
{
    public partial class KitapAlimFormu : Form
    {
        public KitapAlimFormu()
        {
            InitializeComponent();
        }
        //mevcut öğrenci, öğrenciadı, soyadı ve numarası bilgilerini öğrenciTakip formundan çekeceğiz. burada tanımlamalarını yapmamız yeterli.
        public string mevcutOgrenci = string.Empty;
        public string mevcutOgrenciAd = string.Empty;
        public string mevcutOgrenciSoyad = string.Empty;
        public string mevcutOgrenciNumara = string.Empty;
        private void KitapAlimFormu_Load(object sender, EventArgs e)
        {
            try
            {
                // mevcut öğrenciyle işlem yapabilmek için öğrenci yönlendiricisini kullanarak öğrenci bilgisini alalım.
                label2.Text = mevcutOgrenci;
                List<ogrenci> ogrenci = new List<ogrenci>();
                List<ogrKitap> ogrKitap = new List<ogrKitap>();
                OgrenciYonlendirici yonlendirici = new OgrenciYonlendirici();
                ogrenci = yonlendirici.ogrenciGetir(mevcutOgrenci);
                label2.Text = ogrenci[0].ogrenci_ad + " " + ogrenci[0].ogrenci_soyad;
                mevcutOgrenci = ogrenci[0].ogrenci_ad + " " + ogrenci[0].ogrenci_soyad;
                mevcutOgrenciAd = ogrenci[0].ogrenci_ad;
                mevcutOgrenciSoyad = ogrenci[0].ogrenci_soyad;

                // öğrencinin tüm kitaplar arasından kitap alımı yapabilmesi için kitap yönlendiricisini kullanıp tüm kitapları getirelim ve comboBox üzerinde listeleyelim.
                kitapYonlendirici kitapYonlendirici = new kitapYonlendirici();
                List<kitap> kitaplar = new List<kitap>();
                kitaplar = kitapYonlendirici.tumKitaplariGetir();
                for (int i = 0; i < kitaplar.Count(); i++)
                {
                    comboBox1.Items.Add(kitaplar[i].kitap_adi);
                }
            }
            catch (Exception istisna)
            {
                MessageBox.Show("HATA MEYDANA GELDİ..."+"\n\n"+"HATA KODU :"+"\n\n"+istisna.Message.ToString());
                this.Close();
            }
        }

        private void kitapAlimiEkle_button_Click(object sender, EventArgs e)
        {
            //öğrenciye ait kitap alımı eklemek için öğrencinin adı, soyadı, numarası, alacağı kitap bilgisi, son teslim tarih bilgisi ve teslim alınma tarihi bilgisi gerekiyor. bunları değişkenlerimizde saklayalım.
            string ogrenciAd = mevcutOgrenciAd;
            string ogrenciSoyad = mevcutOgrenciSoyad;
            string ogrenciNumara = mevcutOgrenciNumara;
            string kitapAdi = comboBox1.SelectedItem.ToString();
            string son_teslim_tarihi = dateTimePicker1.Value.ToString();
            DateTime simdikiZaman = DateTime.Now;
            string teslim_alinma_tarihi = simdikiZaman.ToString();

            //varsayılan ceza değerini sıfır olarak belirleyelim.
            double ceza = 0;

            
            bool sonuc; //boolean sonuç değişkenini oluşturalım. yönlendiricinin return ettiği değere göre işlemin başarılı olup olmadığını anlayacağız.
            ogrKitapYonlendirici ogrKitapYonlendirici = new ogrKitapYonlendirici(); //ogrKitap yönlendiricisini oluşturalım.
            sonuc = ogrKitapYonlendirici.ogrKitapEkle(kitapAdi,ogrenciNumara,ogrenciAd,ogrenciSoyad,son_teslim_tarihi,ceza,teslim_alinma_tarihi); //kitap alım metodunu çağıralım.
            if(sonuc == true) //yönlendiricinin cevabına göre işlem başarılı veya başarısız olacaktır.
            {
                MessageBox.Show("Kitap alımı başarılı!");
            }
            else
            {
                MessageBox.Show("Kitap alımı başarısız!!!");
            }

        }
    }
}
