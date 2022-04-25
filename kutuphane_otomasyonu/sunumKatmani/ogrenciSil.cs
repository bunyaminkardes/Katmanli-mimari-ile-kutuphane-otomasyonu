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
    public partial class ogrenciSil : Form
    {
        public ogrenciSil()
        {
            InitializeComponent();
        }

        private void ogrenciSil_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numara = textBox1.Text; //silinecek öğrenci için gerekli öğrenci numarasını textbox üzerinden alalım.

            bool sonuc; //boolean sonuç değişkenini oluşturalım. işlemin başarılı olup olmadığını bu değişken sayesinde anlayacağız.

            OgrenciYonlendirici yonlendirici = new OgrenciYonlendirici(); //yönlendiriciyi oluşturalım.

            sonuc = yonlendirici.ogrenciSil(numara); //yönlendiricinin öğrenci sil metodunu çağıralım.

            if(sonuc == true) //yönlendiricinin return ettiği sonuca göre işlemin başarılı olup olmadığını anlayacağız.
            {
                MessageBox.Show("Öğrenci başarıyla silindi!");
            }
            else
            {
                MessageBox.Show("Öğrenci silinemedi!!!");
            }

        }
    }
}
