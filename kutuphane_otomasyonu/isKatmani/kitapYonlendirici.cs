using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb; //access veritabanıyla alakalı işlemleri gerçekleştirebilmek için eklendi.
using kutuphane_otomasyonu.veriKatmani; //verikatmanı ile iletişime geçmek için eklendi.

namespace kutuphane_otomasyonu.isKatmani
{
    internal class kitapYonlendirici
    {
        public List<kitap> tumKitaplariGetir() //kitap türünde liste dönen ve parametre almayan kitapları listele metodunu yazalım.
        {
            List<kitap> kitaplar = new List<kitap>(); // kitap türünde liste döneceğiz, şimdiden bu listeyi oluşturalım.
            OleDbConnection baglanti = veritabani.baglantiAc(); // bağlantıyı açalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("SELECT * FROM kitaplar"); // sql komutumuzu yazalım.
            OleDbDataReader okuyucu = sqlkomutu.ExecuteReader(); // okuyucu nesnesi oluşturalım ve sql komutunu çalıştıralım. komut çalıştıkça veriler okuyucunun içine atılacak.
            while (okuyucu.Read()) // okuyucu okuma işlemi yaptığı sürece çalışan bir while döngüsü oluşturalım.
            {
                // okuma işlemi olduğu sürece kitap nesneleri oluşturalım.
                kitap kitapObj = new kitap(
                    Convert.ToInt32(okuyucu["kitap_id"].ToString()),
                    okuyucu["kitap_kodu"].ToString(),
                    okuyucu["kitap_adi"].ToString(),
                    okuyucu["kitap_tur"].ToString(),
                    okuyucu["kitap_yazar"].ToString(),
                    okuyucu["kitap_sayfa_sayisi"].ToString(),
                    okuyucu["kitap_basim_tarihi"].ToString());
                kitaplar.Add(kitapObj); // her oluşturduğumuz kitap nesnesini kitaplar listemize atalım.
            }
            okuyucu.Close(); //okuyucu nesnemizi kapatalım.
            baglanti.Close(); //bağlantıyı kapatalım.
            return kitaplar; //kitapları return edelim.
        }
        public List<kitap> tumKitaplariGetirKosullu(string kosul) //kitap türünde bir liste dönen ve koşul parametresi alan, koşula göre kitap listeleyen bir metod hazırlayalım.
        {
            List<kitap> kitaplar = new List<kitap>(); //kitap türünde bir liste döneceğimiz için listemizi oluşturalım.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("SELECT * FROM kitaplar WHERE kitap_adi = @kosul OR kitap_kodu = @kosul "); //koşullu sorgumuzu yazalım.
            sqlkomutu.Parameters.AddWithValue("@kosul", kosul); //koşul parametresini bağlayalım.
            OleDbDataReader okuyucu = sqlkomutu.ExecuteReader(); //veritabanında okuma işlemi yapıldıkça bunu okuyucu nesnesinin içerisine atalım.
            while (okuyucu.Read()) //okuyucu okuma işlemi yaptıkça çalışacak olan bir while döngüsü kuralım.
            {
                //okuma işlemi yapıldıkça kitap nesneleri oluşturalım.
                kitap kitapObj = new kitap(
                    Convert.ToInt32(okuyucu["kitap_id"].ToString()),
                    okuyucu["kitap_kodu"].ToString(),
                    okuyucu["kitap_adi"].ToString(),
                    okuyucu["kitap_tur"].ToString(),
                    okuyucu["kitap_yazar"].ToString(),
                    okuyucu["kitap_sayfa_sayisi"].ToString(),
                    okuyucu["kitap_basim_tarihi"].ToString());
                kitaplar.Add(kitapObj); //oluşturduğumuz kitap nesnelerini kitaplar listesine atalım.
            }
            okuyucu.Close(); //okuyucu nesnesini kapatalım.
            baglanti.Close(); //bağlantıyı kapatalım.
            return kitaplar; //kitapları return edelim.
        }

        //bool return eden ve kitaba ait bilgileri parametre olarak alan, kitap ekle metodunu yazalım.
        public bool kitapEkle(string kitapAdi,string kitapKodu, string kitapTuru, string kitapYazari,string sayfaSayisi,string basimTarihi)
        {
            bool sonuc = false; //boolean sonuç değişkenini oluşturalım. işlemin başarılı olup olmadığını belirleyecek. varsayılan olarak false olsun.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.

            //kitap ekleme için gerekli sql sorgumuzu yazalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("INSERT INTO kitaplar (kitap_adi,kitap_kodu,kitap_tur,kitap_yazar,kitap_sayfa_sayisi,kitap_basim_tarihi) VALUES (@kitap_adi,@kitap_kodu,@kitap_tur,@kitap_yazar,@kitap_sayfa_sayisi,@kitap_basim_tarihi)");

            //sorguda adı geçen parametreleri teker teker bağlayalım.
            sqlkomutu.Parameters.AddWithValue("@kitap_adi", kitapAdi);
            sqlkomutu.Parameters.AddWithValue("@kitap_kodu", kitapKodu);
            sqlkomutu.Parameters.AddWithValue("@kitap_tur", kitapTuru);
            sqlkomutu.Parameters.AddWithValue("@kitap_yazar", kitapYazari);
            sqlkomutu.Parameters.AddWithValue("@kitap_sayfa_sayisi", sayfaSayisi);
            sqlkomutu.Parameters.AddWithValue("@kitap_basim_tarihi", basimTarihi);

            if (sqlkomutu.ExecuteNonQuery() > 0) //sorguyu çalıştıralım, etkilenen satır sayısı 0'dan büyük ise işlem başarılı demektir.
            {
                sonuc = true;
            }
            baglanti.Close(); //bağlantıyı kapatalım.
            return sonuc; //sonucu return edelim.
        }

        public bool kitapSil(string kitapKodu) //bool geri döndüren ve kitap kodunu parametre olarak alan bir metod yazalım. kitap silme işlemi için bu metodu kullanacağız.
        {
            bool sonuc = false; //işlemin başarılı olup olmadığını anlamak için geriye boolean sonuç değişkeni döndüreceğiz, varsayılan olarak false olsun.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("DELETE * FROM kitaplar WHERE kitap_kodu = @kitapkodu"); //silme sql kodunu yazalım.
            sqlkomutu.Parameters.AddWithValue("@kitap_kodu", kitapKodu); //sql parametrelerini bağlayalım.
            if(sqlkomutu.ExecuteNonQuery()>0) //komutu çalıştıralım, eğer birden fazla satır komuttan etkilendiyse işlem başarılı demektir.
            {
                sonuc = true;
            }
            baglanti.Close(); //bağlantıyı kapatalım.
            return sonuc; //sonuç değişkenini return edelim.
        }
    }
}
