using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane_otomasyonu.veriKatmani
{
    internal class kitap
    {
        // kitaplar tablosundaki tüm alanlar için property'leri oluşturalım.
        public int kitap_id { get; set; }
        public string kitap_kodu { get; set; }
        public string kitap_adi { get; set; }
        public string kitap_tur { get; set; }
        public string kitap_yazar { get; set; }
        public string kitap_sayfa_sayisi { get; set; }
        public string kitap_basim_tarihi { get; set; }

        // kitap kurucu metodunu oluşturalım, bu sınıftan bir kitap nesnesi üretildiğinde bu kurucu metod çağırılacak ve içeriği otomatik olarak doldurulacak.
        public kitap(int kitap_id,string kitap_kodu, string kitap_adi,string kitap_tur,string kitap_yazar,string kitap_sayfa_sayisi,string kitap_basim_tarihi)
        {
            this.kitap_id = kitap_id;
            this.kitap_kodu = kitap_kodu;
            this.kitap_adi = kitap_adi;
            this.kitap_tur = kitap_tur;
            this.kitap_yazar = kitap_yazar;
            this.kitap_sayfa_sayisi = kitap_sayfa_sayisi;
            this.kitap_basim_tarihi = kitap_basim_tarihi;
        }
    }
}
