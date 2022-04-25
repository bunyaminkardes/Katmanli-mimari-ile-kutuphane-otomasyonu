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
    public partial class kitapTakip : Form
    {
        public kitapTakip()
        {
            InitializeComponent();
        }

        private void kitapTakip_Load(object sender, EventArgs e)
        {

        }

        private void kitapListele_Click(object sender, EventArgs e)
        {
            try
            {
                List<kitap> kitaplar = new List<kitap>(); //yönlendiricinin return edeceği listeyi tutabilmek için kitap türünde bir liste oluşturalım.
                kitapYonlendirici kitapYonlendirici = new kitapYonlendirici(); //kitap yönlendiricisini oluşturalım.
                kitaplar = kitapYonlendirici.tumKitaplariGetirKosullu(textBox1.Text.ToString()); //kitap yönlendiricisinin koşula göre kitap çekme metodunu çalıştıralım.
                dataGridView1.DataSource = kitaplar; //yönlendiricinin return ettiği kitap listesini datagridview1'in veri kaynağı olarak belirleyelim.

                List<ogrKitap> ogrKitaplar = new List<ogrKitap>(); //yönlendiricinin return edeceği listeyi tutabilmek için ogrKitap türünde bir liste oluşturalım.
                ogrKitapYonlendirici ogrKitapYonlendirici = new ogrKitapYonlendirici(); //ogrKitap yönlendiricisini oluşturalım.
                ogrKitaplar = ogrKitapYonlendirici.kosulluOgrenciTakip(dataGridView1.Rows[0].Cells[2].Value.ToString());//ogrKitap yönlendiricisinin koşula göre öğrenci takip metodunu çağıralım.
                dataGridView2.DataSource = ogrKitaplar; //ogrKitap yönlendiricisinin return ettiği ogrKitap listesini datagridview2'nin veri kaynağı olarak belirleyelim.
            }
            catch (Exception istisna)
            {

                MessageBox.Show("HATA MEYDANA GELDİ..." + "\n\n" + "HATA KODU :" + "\n\n" + istisna.Message.ToString());
            }
        }
    }
}
