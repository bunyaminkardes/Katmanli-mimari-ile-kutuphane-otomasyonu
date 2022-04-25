using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kutuphane_otomasyonu.sunumKatmani; //form örnekleri oluşturabilmek için eklendi.

namespace kutuphane_otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ogrEkle_button_Click(object sender, EventArgs e)
        {
            ogrenciEkle ogrenciEklemeFormu = new ogrenciEkle(); //öğrenci ekle butonuna tıklandığında öğrenci ekleme formunun bir örneği oluşturulsun.
            ogrenciEklemeFormu.Show(this); //öğrenci ekleme formunu gösterelim.
        }

        private void ogrSil_button_Click(object sender, EventArgs e)
        {
            ogrenciSil ogrenciSilmeFormu = new ogrenciSil(); //öğrenci silme butonuna tıklandığında öğrenci silme formunun bir örneği oluşturulsun.
            ogrenciSilmeFormu.Show(this); //öğrenci silme formunu gösterelim.
        }
        private void ogrTakip_button_Click(object sender, EventArgs e)
        {
            ogrenciTakip ogrenciTakipFormu = new ogrenciTakip(); //öğrenci takip butonuna tıklandığında öğrenci takip formunun bir örneği oluşturulsun.
            ogrenciTakipFormu.Show(this); //öğrenci takip formunu gösterelim.
        }

        private void ogrGuncelle_button_Click(object sender, EventArgs e)
        {
            ogrenciGuncelle ogrenciGuncellemeFormu = new ogrenciGuncelle(); //öğrenci güncelleme butonuna tıklandığında öğrenci güncelleme formunun bir örneği oluşturulsun.
            ogrenciGuncellemeFormu.Show(this); //öğrenci güncelleme formunu gösterelim.
        }

        private void kitapEkle_button_Click(object sender, EventArgs e)
        {
            kitapEkleForm kitapEklemeFormu = new kitapEkleForm(); //kitap ekleme butonuna tıklandığında kitap ekleme formunun bir örneği oluşturulsun.
            kitapEklemeFormu.Show(this); //kitap ekleme formunu gösterelim.
        }

        private void kitapGuncelle_button_Click(object sender, EventArgs e)
        {
            kitapGuncelleForm kitapGuncelleForm = new kitapGuncelleForm(); //kitap güncelleme butonuna tıklandığında kitap güncelleme formunun bir örneği oluşturulsun.
            kitapGuncelleForm.Show(this); //kitap güncelleme formunu gösterelim.
        }

        private void kitapSil_button_Click(object sender, EventArgs e)
        {
            kitapSilForm kitapSilForm = new kitapSilForm(); //kitap silme butonuna tıklandığında kitap silme formunun bir örneği oluşturulsun.
            kitapSilForm.Show(this); //kitap silme formunu gösterelim.
        }

        private void kitapTakibi_button_Click(object sender, EventArgs e)
        {
            kitapTakip kitapTakipFormu = new kitapTakip(); //kitap takibi butonuna tıklandığında kitap takibi formunun bir örneği oluşturulsun.
            kitapTakipFormu.Show(this); //kitap takibi formunu gösterelim.
        }

        private void zedGraphButton_Click(object sender, EventArgs e)
        {
            ZedGraphForm zedGraphForm = new ZedGraphForm(); //zedgraph butonuna tıklandığında zedgraph formunun bir örneği oluşturulsun.
            zedGraphForm.Show(this); //zedgraph formunu gösterelim.
        }
    }
}
