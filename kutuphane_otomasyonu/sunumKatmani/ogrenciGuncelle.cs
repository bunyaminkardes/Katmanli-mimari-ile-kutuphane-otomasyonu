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
    public partial class ogrenciGuncelle : Form
    {
        public ogrenciGuncelle()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string numara = textBox1.Text; //öğrenci numarası bilgisini alalım.
            string alan = comboBox1.SelectedItem.ToString(); //hangi alan üzerinde güncellenme yapılacak bilgisini alalım.
            string deger = textBox2.Text; //yeni değer bilgisini alalım.
            
            bool sonuc; //boolean sonuç değişkenini oluşturalım. işlemin başarılı olup olmadığını bu değişkenle anlayacağız.

            OgrenciYonlendirici ogrenciYonlendirici = new OgrenciYonlendirici(); //yönlendiriciyi oluşturalım.
            sonuc = ogrenciYonlendirici.ogrenciGuncelle(alan, deger, numara); //yönlendiriciye ait öğrenci güncelleme metodunu çağıralım.
            if (sonuc == true) //yönlendiricinin return ettiği değere göre işlemin başarılı olup olmadığını anlayacağız.
            {
                MessageBox.Show("Güncelleme başarılı!");
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız!!!");
            }
        }
        private void ogrenciGuncelle_Load(object sender, EventArgs e)
        {

        }
    }
}
