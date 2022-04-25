using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kutuphane_otomasyonu.isKatmani; //yönlendirici kullanımı için eklendi.
using kutuphane_otomasyonu.veriKatmani; //liste oluşturabilmek için eklendi.

namespace kutuphane_otomasyonu.sunumKatmani
{
    public partial class ogrenciTakip : Form
    {
        public ogrenciTakip()
        {
            InitializeComponent();
        }
        
        private void ogrListele_button_Click(object sender, EventArgs e)
        {
            List<ogrKitap> ogrenci = new List<ogrKitap>(); //ogrKitap yönlendiricisini kullanarak öğrenci takibi yapacağız, öğrencileri depolamak için ogrKitap türünde bir liste oluşturalım.
            ogrKitapYonlendirici yonlendirici = new ogrKitapYonlendirici(); //ogrKitap türündeki yönlendiriciyi oluşturalım.
            ogrenci = yonlendirici.ogrenciTakip(textBox1.Text.ToString()); //yönlendiriciyi kullanarak ogrenciTakibi yapalım. 
            dataGridView1.DataSource = ogrenci; //yönlendiricinin return ettiği öğrenci listesini datagridview'un veri kaynağı olarak belirleyelim.

            for(int i=0; i<ogrenci.Count; i++) //öğrenci listesinin eleman sayısı kadar çalışacak bir for döngüsü açalım, datagridview'un tüm satırlarına ve hücrelerine erişebilmek için.
            {
                if(dataGridView1.Rows[i].Cells[4].Value.ToString() == "teslim edilmiş") //teslim_durumu hücresine bakalım, eğer teslim edilmiş ise arkaplanı yeşil yapalım.
                {
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                }
                DateTime teslimTarihi = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value); //son teslim tarihi hücresini tarih veritipine çevirelim. tarihsel işlemlerde kullanacağız.
                DateTime simdikiZaman = DateTime.Now; //şimdiki zaman bilgisini elde edelim.
                TimeSpan tarihFark = teslimTarihi - simdikiZaman; //teslim tarihinden şimdiki zamanı çıkaralım, aradaki gün farkını bulalım.
                int tarihfarki = tarihFark.Days+1;
                int zamanKiyaslamaSonucu = DateTime.Compare(teslimTarihi, simdikiZaman); //teslim tarihini ve şimdiki zamanı kıyaslayalım. sonuç int dönecek, depo edelim.
                double ogrenciCeza = tarihfarki * 1 -1; 
                if(zamanKiyaslamaSonucu<0 && dataGridView1.Rows[i].Cells[4].Value.ToString() == "teslim edilmemiş") // teslim süresini aşan kitaplar için teslim_durumu hücresinin arka planını kırmızı renk yapalım.
                {
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.Red;
                }
                if(tarihfarki == 2 && dataGridView1.Rows[i].Cells[4].Value.ToString()=="teslim edilmemiş") //teslim süresine 2 gün kalan kitaplar için teslim_durumu hücresinin arka planını uyarı amaçlı sarı renk yapalım.
                {
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                }
                if (zamanKiyaslamaSonucu>0) //teslim tarihine daha varsa ceza yazmasın.
                {
                    ogrenciCeza = 0;
                }
                if (ogrenciCeza<0) //tarihten kaynaklı olarak değerler negatif çıkıyor, pozitife çevirelim.
                {
                    ogrenciCeza = ogrenciCeza * -1;
                }
                dataGridView1.Rows[i].Cells[6].Value = ogrenciCeza; //ceza değerimizi ceza hücresine yazdıralım.
            }
        }

        private void ogrenciTakip_Load(object sender, EventArgs e)
        {

        }

        private void kitapAlimiEkle_button_Click(object sender, EventArgs e)
        {
            KitapAlimFormu kitapAlimFormu = new KitapAlimFormu(); //kitap alım butonuna tıklandığında kitap alım formunun bir örneği oluşturulsun.
            kitapAlimFormu.mevcutOgrenci = textBox1.Text; //bu formdan kitap alım formuna mevcut öğrenci bilgisini aktaralım.
            kitapAlimFormu.mevcutOgrenciNumara = textBox1.Text; //bu formdan kitap alım formuna mevcut öğrencinin numara bilgisini aktaralım.
            kitapAlimFormu.Show(this); //kitap alım formunu gösterelim.
        }

        private void kitapIadesiEkle_button_Click(object sender, EventArgs e)
        {
            KitapIadeFormu kitapIadeFormu = new KitapIadeFormu(); //kitap iade butonuna tıklandığında kitap iade formunun bir örneğini oluşturalım.
            kitapIadeFormu.mevcutOgrenci = textBox1.Text; //bu formdan kitap iade formuna mevcut öğrenci bilgisini aktaralım.
            kitapIadeFormu.mevcutOgrenciNumara = textBox1.Text; //bu formdan kitap iade formuna mevcut öğrencinin numara bilgisini aktaralım.
            kitapIadeFormu.Show(this); //kitap iade formunu gösterelim.
        }

    }
}
