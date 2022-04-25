using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane_otomasyonu.veriKatmani
{
    internal class ogrenci
    {
        // öğrenciler tablosundaki tüm alanlar için property'leri oluşturalım.
        public int ogrenci_id { get; set; }
        public string ogrenci_ad { get; set; }
        public string ogrenci_soyad { get; set; }
        public string ogrenci_numara { get; set; }

        // öğrenci kurucu metodunu oluşturalım, bu sınıftan bir öğrenci nesnesi üretildiğinde bu kurucu metod çağırılacak ve içeriği otomatik olarak doldurulacak.
        public ogrenci(int ogrenci_id, string ogrenci_ad, string ogrenci_soyad, string ogrenci_numara)
        {
            this.ogrenci_id = ogrenci_id;
            this.ogrenci_ad = ogrenci_ad;
            this.ogrenci_soyad = ogrenci_soyad;
            this.ogrenci_numara = ogrenci_numara;
        }

    }
}
