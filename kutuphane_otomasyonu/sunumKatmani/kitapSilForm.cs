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
    public partial class kitapSilForm : Form
    {
        public kitapSilForm()
        {
            InitializeComponent();
        }

        private void kitapSilButton_Click(object sender, EventArgs e)
        {
            bool sonuc; //boolean sonuç değişkenini oluşturuyoruz. işlemin başarılı olup olmadığını bu değişkenle anlayacağız.

            //kitap kodu üzerinden kitap silme işlemi yapacağız. bunu textBox üzerinden alacağız.
            string kitapKodu = textBox1.Text;

            kitapYonlendirici kitapYonlendirici = new kitapYonlendirici(); //yönlendiriciyi oluşturuyoruz.

            sonuc = kitapYonlendirici.kitapSil(kitapKodu); //yönlendiriciye ait kitap silme metodunu çalıştırıyoruz.

            if(sonuc == true) //yönlendiricinin return ettiği değere göre işlemin başarılı olup olmadığını anlayacağız.
            {
                MessageBox.Show("Kitap başarıyla silindi!");
            }
            else 
            {
                MessageBox.Show("Kitap silinemedi!!!");
            }
        }

        private void kitapSilForm_Load(object sender, EventArgs e)
        {

        }
    }
}
