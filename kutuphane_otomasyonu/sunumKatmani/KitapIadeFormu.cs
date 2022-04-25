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
    public partial class KitapIadeFormu : Form
    {
        public KitapIadeFormu()
        {
            InitializeComponent();
        }
        //ogrenciTakip formundan bu forma mevcut öğrenci ve mevcut öğrenci numarası bilgileri aktarılacak. şimdilik tanımlamalar yapılsa yeterli.
        public string mevcutOgrenci = string.Empty;
        public string mevcutOgrenciNumara = string.Empty;

        private void KitapIadeFormu_Load(object sender, EventArgs e)
        {
            try
            {
                //hangi öğrenci için iade işlemi yapacağımızı anlamak için mevcut öğrenci bilgilerini formumuzda kullanıyoruz.
                label2.Text = mevcutOgrenci;
                List<ogrenci> ogrenci = new List<ogrenci>();
                OgrenciYonlendirici yonlendirici = new OgrenciYonlendirici();
                ogrenci = yonlendirici.ogrenciGetir(mevcutOgrenci);
                label2.Text = ogrenci[0].ogrenci_ad + " " + ogrenci[0].ogrenci_soyad;

                //hangi kitabı iade edeceğimizi bilebilmemiz için bir ogrKitap yönlendiricisi oluşturarak öğrencinin almış olduğu kitapları getirip comboBox'a yerleştiriyoruz.
                List<ogrKitap> ogrKitap = new List<ogrKitap>();
                ogrKitapYonlendirici ogrKitapYonlendirici = new ogrKitapYonlendirici();
                ogrKitap = ogrKitapYonlendirici.ogrenciTakip(mevcutOgrenci);
                for (int i = 0; i < ogrKitap.Count(); i++)
                {
                    comboBox1.Items.Add(ogrKitap[i].kitap_adi);
                }
            }
            catch (Exception istisna)
            {
                MessageBox.Show("HATA MEYDANA GELDİ..." + "\n\n" + "HATA KODU :" + "\n\n" + istisna.Message.ToString());
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // kitap iadesi yapıldığında sadece teslim edilmiş kısmı teslim edilmiş olarak update edilecek.

            //kitap iadesi işlemi için kitap adı ve öğrenci numarası bilgilerine ihtiyaç duyuyoruz. bunları string tipli değişkenlerde saklayalım.
            string kitapAdi = comboBox1.SelectedItem.ToString();
            string numara = mevcutOgrenciNumara;

            bool sonuc; //boolean sonuç değişkenini oluşturalım. yönlendiricinin return sonucuna göre işlemin başarılı olup olmadığını anlayacağız.

            DateTime simdikiZaman = DateTime.Now; //iade tarihi için şimdiki zaman bilgisi lazım.
            string teslim_iade_tarihi = simdikiZaman.ToString(); // şimdiki zaman bilgisini string'e çevirip teslim_iade_tarihi olarak ayarlıyoruz.

            ogrKitapYonlendirici ogrKitapYonlendirici = new ogrKitapYonlendirici(); //ilgili yönlendiriciyi oluşturuyoruz.

            sonuc = ogrKitapYonlendirici.ogrKitapGuncelle(kitapAdi,numara,teslim_iade_tarihi); //yönlendiriciyi kullanarak kitap iade işlemi için ogrKitap tablosunda güncelleme yapıyoruz.

            if(sonuc == true) //yönlendiricinin sonucuna göre işlemin başarılı olup olmadığını anlayacağız.
            {
                MessageBox.Show("Kitap iade edildi!");
            }
            else
            {
                MessageBox.Show("Kitap iadesi başarısız!!!");
            }
        }
    }
}
