using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb; //access veritabanıyla alakalı işlemleri gerçekleştirebilmek için eklendi.
using kutuphane_otomasyonu.veriKatmani; //verikatmanı ile iletişime geçmek için eklendi.

namespace kutuphane_otomasyonu.isKatmani
{
    internal class OgrenciYonlendirici
    {
        public bool ogrenciEkle(string ad,string soyad,string numara) //geriye bool dönen, öğrenci ekleme metodunu yazalım.
        {
            bool sonuc = false; //boolean sonuç değişkenini oluşturalım. varsayılan olarak false olacak.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.

            //ilgili sql sorgusunu yazalım ve parametrelerini bağlayalım.
            OleDbCommand sqlOnSorgusu = veritabani.baglantiOlustur("SELECT * FROM ogrenciler WHERE ogrenci_numara = @ogrNumara");
            sqlOnSorgusu.Parameters.AddWithValue("@ogrNumara", numara);

            //sorguyu çalıştıralım ve okuyucu nesnesini oluşturalım.
            OleDbDataReader okuyucu = sqlOnSorgusu.ExecuteReader();
            if (okuyucu.HasRows) //veritabanında böyle bir öğrenci numarası varsa insert işlemi yapılamasın.
            {
                sonuc = false;
            }
            else //aksi durumda işlem gerçekleştirilsin.
            {
                OleDbCommand sqlkomutu = veritabani.baglantiOlustur("INSERT INTO ogrenciler (ogrenci_ad,ogrenci_soyad,ogrenci_numara) VALUES (@ad,@soyad,@numara)");
                sqlkomutu.Parameters.AddWithValue("@ad", ad);
                sqlkomutu.Parameters.AddWithValue("@soyad", soyad);
                sqlkomutu.Parameters.AddWithValue("@numara", numara);
                if (sqlkomutu.ExecuteNonQuery() > 0)
                {
                    sonuc = true;
                }
            }
            baglanti.Close(); //veritabanı bağlantısını kapatalım.
            return sonuc; //sonuc değişkenini return edelim.
        }

        public bool ogrenciSil(string numara) //bool return eden öğrenci silme metodunu yazalım.
        {
            bool sonuc = false; //boolean sonuç değişkenini oluşturalım. varsayılan olarak false olacak.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.

            //öğrenciler tablosundaki ilgili öğrenciyi silecek olan sorguyu yazalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("DELETE * FROM ogrenciler WHERE ogrenci_numara = @numara");

            //öğrenci silindiğinde ogrKitap tablosunda bu öğrenciyle alakalı kayıt varsa onları da silsin.
            OleDbCommand sqlkomutu2 = veritabani.baglantiOlustur("DELETE * FROM ogrKitap WHERE ogrenci_numara = @numara"); 

            //iki sorguya da ait olan parametreleri bağlayalım.
            sqlkomutu.Parameters.AddWithValue("@numara", numara);
            sqlkomutu2.Parameters.AddWithValue("@numara", numara);

            //eğer ilk sorgu başarılı olursa boolean sonuç değişkeni true olsun, ikinci sorgu da ayrıca çalıştırılsın.
            if(sqlkomutu.ExecuteNonQuery()>0)
            {
                sonuc = true;
                sqlkomutu2.ExecuteNonQuery();
            }
            baglanti.Close(); //bağlantıyı kapatalım.
            return sonuc; //sonucu return edelim.
        }
        public bool ogrenciGuncelle(string alan, string deger, string numara) //öğrenci güncelle metodunu yazalım.
        {
            bool sonuc = false; //boolean sonuç değişkeni varsayılan olarak false olsun.
            OleDbConnection baglanti = veritabani.baglantiAc(); // bağlantıyı açalım.

            if(alan == "ogrenci_ad") //eğer güncellenecek alan adı öğrenci adı ise burası çalışsın.
            {
                OleDbCommand sqlkomutu = veritabani.baglantiOlustur("UPDATE ogrenciler SET ogrenci_ad = @deger WHERE ogrenci_numara = @numara");
                sqlkomutu.Parameters.AddWithValue("@deger", deger);
                sqlkomutu.Parameters.AddWithValue("@numara", numara);
                OleDbCommand sqlkomutu2 = veritabani.baglantiOlustur("UPDATE ogrKitap SET ogrenci_adi = @deger WHERE ogrenci_numara = @numara");
                sqlkomutu2.Parameters.AddWithValue("@deger", deger);
                sqlkomutu2.Parameters.AddWithValue("@numara", numara);
                if (sqlkomutu.ExecuteNonQuery() > 0 && sqlkomutu2.ExecuteNonQuery()>0)
                {
                    sonuc = true;
                }
            }
            else if(alan == "ogrenci_soyad") // eğer güncellenecek alan adı öğrenci soyadı ise burası çalışsın.
            {
                OleDbCommand sqlkomutu = veritabani.baglantiOlustur("UPDATE ogrenciler SET ogrenci_soyad = @deger WHERE ogrenci_numara = @numara");
                sqlkomutu.Parameters.AddWithValue("@deger", deger);
                sqlkomutu.Parameters.AddWithValue("@numara", numara);
                OleDbCommand sqlkomutu2 = veritabani.baglantiOlustur("UPDATE ogrKitap SET ogrenci_soyadi = @deger WHERE ogrenci_numara = @numara");
                sqlkomutu2.Parameters.AddWithValue("@deger", deger);
                sqlkomutu2.Parameters.AddWithValue("@numara", numara);
                if (sqlkomutu.ExecuteNonQuery() > 0 && sqlkomutu2.ExecuteNonQuery()>0)
                {
                    sonuc = true;
                }
            }
            else if(alan == "ogrenci_numara") //eğer güncellenecek alan adı öğrenci numarası ise burası çalışsın.
            {
                OleDbCommand sqlkomutu = veritabani.baglantiOlustur("UPDATE ogrenciler SET ogrenci_numara = @deger WHERE ogrenci_numara = @numara");
                sqlkomutu.Parameters.AddWithValue("@deger", deger);
                sqlkomutu.Parameters.AddWithValue("@numara", numara);
                OleDbCommand sqlkomutu2 = veritabani.baglantiOlustur("UPDATE ogrKitap SET ogrenci_numara = @deger WHERE ogrenci_numara = @numara");
                sqlkomutu2.Parameters.AddWithValue("@deger", deger);
                sqlkomutu2.Parameters.AddWithValue("@numara", numara);
                if (sqlkomutu.ExecuteNonQuery() > 0 && sqlkomutu2.ExecuteNonQuery()>0)
                {
                    sonuc = true;
                }
            }
            baglanti.Close(); //bağlantıyı kapatalım.
            return sonuc; //boolean sonuç değişkenini return edelim.
        }

        public List<ogrenci> ogrenciGetir(string ogrNumara) //geriye bir öğrenci listesi return edecek olan öğrenci getirme metodunu yazalım.
        {
            List<ogrenci> ogrenciler = new List<ogrenci>(); //öğrenciler listesini oluşturalım.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.

            //ilgili sql sorgusunu yazalım ve parametreleri bağlayalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("SELECT * FROM ogrenciler WHERE ogrenci_numara = @ogrNumara");
            sqlkomutu.Parameters.AddWithValue("@ogrNumara", ogrNumara);

            //komutu çalıştıralım ve okuyucu nesnesini oluşturalım.
            OleDbDataReader okuyucu = sqlkomutu.ExecuteReader();

            //okuyucu nesnesi okuma işlemi yaptığı sürece çalışacak bir while döngüsü oluşturalım.
            while (okuyucu.Read())
            {
                //okuma işlemi yapıldığı sürece öğrenci listesine gönderilmek üzere öğrenci nesnelerimizi oluşturalım.
                ogrenci ogrenci = new ogrenci(
                    Convert.ToInt32(okuyucu["ogrenci_id"].ToString()),
                    okuyucu["ogrenci_ad"].ToString(),
                    okuyucu["ogrenci_soyad"].ToString(),
                    okuyucu["ogrenci_numara"].ToString());
                ogrenciler.Add(ogrenci); //öğrenci nesnelerini öğrenciler listesine ekleyelim.
            }
            okuyucu.Close(); //okuyucuyu kapatalım.
            baglanti.Close(); //bağlantıyı kapatalım.
            return ogrenciler; //öğrenciler listesini return edelim.
        }
    }
}
