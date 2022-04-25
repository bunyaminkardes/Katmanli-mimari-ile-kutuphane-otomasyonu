using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane_otomasyonu.veriKatmani
{
    internal class ogrKitap
    {
        // ogrKitap tablosundaki tüm alanlar için property'leri oluşturalım.
        public string ogrenci_numara { get; set; }
        public string ogrenci_ad { get; set; }
        public string ogrenci_soyadi { get; set; }
        public string kitap_adi { get; set; }
        public string teslim_durumu { get; set; }
        public string son_teslim_tarihi { get; set; }
        public double ceza { get; set; }
        public string teslim_alinma_tarihi { get; set; }
        public string teslim_iade_tarihi { get; set; }

        // ogrKitap kurucu metodunu oluşturalım, bu sınıftan bir ogrKitap nesnesi üretildiğinde bu kurucu metod çağırılacak ve içeriği otomatik olarak doldurulacak.
        public ogrKitap(string ogrenci_numara,string ogrenci_ad,string ogrenci_soyadi,string kitap_adi,string teslim_durumu,string son_teslim_tarihi,double ceza,string teslim_alinma_tarihi,string teslim_iade_tarihi)
        {
            this.ogrenci_numara = ogrenci_numara;
            this.ogrenci_ad = ogrenci_ad;
            this.ogrenci_soyadi = ogrenci_soyadi;
            this.kitap_adi = kitap_adi;
            this.teslim_durumu = teslim_durumu;
            this.son_teslim_tarihi = son_teslim_tarihi;
            this.ceza = ceza;
            this.teslim_alinma_tarihi = teslim_alinma_tarihi;
            this.teslim_iade_tarihi = teslim_iade_tarihi;
        }
    }
}
