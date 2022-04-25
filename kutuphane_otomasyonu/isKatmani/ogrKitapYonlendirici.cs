using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb; //access veritabanıyla alakalı işlemleri gerçekleştirebilmek için eklendi.
using kutuphane_otomasyonu.veriKatmani; //verikatmanı ile iletişime geçmek için eklendi.

namespace kutuphane_otomasyonu.isKatmani
{
    internal class ogrKitapYonlendirici
    {
        public List<ogrKitap> ogrenciTakip(string ogrNumara) //geriye ogrKitap türünde bir liste return eden ve öğrenci numarasını parametre olarak alan bir öğrenci takip metodu yazalım.
        {
            List<ogrKitap> ogrKitaplar = new List<ogrKitap>(); //ogrKitaplar listemizi oluşturalım.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.

            //ilgili sql sorgumuzu yazalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("SELECT * FROM ogrKitap WHERE ogrenci_numara = @ogrNumara");

            //öğrenci numarası parametresini bağlayalım.
            sqlkomutu.Parameters.AddWithValue("@ogrNumara", ogrNumara);

            //komutu çalıştıralım, okuma nesnesini oluşturalım.
            OleDbDataReader okuyucu = sqlkomutu.ExecuteReader();

            //okuma nesnesi okuma işlemini yaptıkça ogrKitap nesnelerini oluşturalım.
            while (okuyucu.Read())
            {
                ogrKitap ogrKitapObj = new ogrKitap(
                    okuyucu["ogrenci_numara"].ToString(),
                    okuyucu["ogrenci_adi"].ToString(),
                    okuyucu["ogrenci_soyadi"].ToString(),
                    okuyucu["kitap_adi"].ToString(),
                    okuyucu["teslim_durumu"].ToString(),
                    okuyucu["son_teslim_tarihi"].ToString(),
                    Convert.ToDouble(okuyucu["ceza"]),
                    okuyucu["teslim_alinma_tarihi"].ToString(),
                    okuyucu["teslim_iade_tarihi"].ToString());
                ogrKitaplar.Add(ogrKitapObj); //her bir ogrKitap nesnesini ogrKitaplar listesine ekleyelim.
            }
            okuyucu.Close(); //okuyucuyu kapatalım.
            baglanti.Close(); //bağlantıyı kapatalım.
            return ogrKitaplar; //ogrKitaplar listesini return edelim.
        }

        public List<ogrKitap> kosulluOgrenciTakip(string kitapAdi) //ogrKitap türünde bir liste return eden ve kitap adını parametre olarak alan, koşullu öğrenci takibi yapan bir metod hazırlayalım.
        {
            List<ogrKitap> ogrKitaplar = new List<ogrKitap>(); //ogrKitaplar listemizi oluşturalım.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("SELECT * FROM ogrKitap WHERE kitap_adi = @kitapAdi"); //ilgili sql sorgusunu yazalım.
            sqlkomutu.Parameters.AddWithValue("@kitapAdi", kitapAdi); //kitapAdi parametresini bağlayalım.
            OleDbDataReader okuyucu = sqlkomutu.ExecuteReader(); //sorguyu çalıştıralım ve okuyucu nesnesini oluşturalım.
            while (okuyucu.Read()) //okuyucu nesnesi okuma yaptıkça ogrKitap nesnelerini oluşturalım.
            {
                ogrKitap ogrKitapObj = new ogrKitap(
                    okuyucu["ogrenci_numara"].ToString(),
                    okuyucu["ogrenci_adi"].ToString(),
                    okuyucu["ogrenci_soyadi"].ToString(),
                    okuyucu["kitap_adi"].ToString(),
                    okuyucu["teslim_durumu"].ToString(),
                    okuyucu["son_teslim_tarihi"].ToString(),
                    Convert.ToDouble(okuyucu["ceza"]),
                    okuyucu["teslim_alinma_tarihi"].ToString(),
                    okuyucu["teslim_iade_tarihi"].ToString());
                ogrKitaplar.Add(ogrKitapObj); //oluşturduğumuz ogrKitap nesnelerini ogrKitaplar listesine ekleyelim.
            }
            okuyucu.Close(); //okuyucu nesnesini kapatalım.
            baglanti.Close(); //bağlantıyı kapatalım.
            return ogrKitaplar; //ogrKitaplar listesini return edelim.
        }
        public bool ogrKitapGuncelle(string kitapAdi,string numara,string iadeTarihi) //geriye bool sonucu return eden kitap güncelleme metodunu yazalım. bu metod çalıştırıldığında kitap teslim edilmiş durumuna getirilecek.
        {
            string teslim_durumu = "teslim edilmiş"; //teslim durumu değişkenini hazırlayalım.
            bool sonuc = false; // boolean sonuç değişkenini oluşturalım. varsayılan olarak false olsun.
            OleDbConnection baglanti = veritabani.baglantiAc(); //bağlantıyı açalım.

            //teslim durumunu teslim edilmiş yapacak olan sorguyu oluşturalım ve parametrelerini bağlayalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("UPDATE ogrKitap SET teslim_durumu = @teslim_durumu WHERE ogrenci_numara = @numara AND kitap_adi = @kitapAdi");
            sqlkomutu.Parameters.AddWithValue("@teslim_durumu", teslim_durumu);
            sqlkomutu.Parameters.AddWithValue("@numara", numara);
            sqlkomutu.Parameters.AddWithValue("@kitapAdi", kitapAdi);

            //yan sorgu olarak kitabın iade tarihini ekleyecek olan sorguyu yazalım ve parametrelerini bağlayalım.
            OleDbCommand sqlkomutu2 = veritabani.baglantiOlustur("UPDATE ogrKitap SET teslim_iade_tarihi = @iadeTarihi WHERE ogrenci_numara = @numara AND kitap_adi = @kitapAdi");
            sqlkomutu2.Parameters.AddWithValue("@iadeTarihi", iadeTarihi);
            sqlkomutu2.Parameters.AddWithValue("@numara", numara);
            sqlkomutu2.Parameters.AddWithValue("@kitapAdi", kitapAdi);

            //bu iki sorguyu da çalıştıralım, eğer ikisi de başarıyla çalıştıysa boolean sonuç değişkeni true olsun.
            if (sqlkomutu.ExecuteNonQuery() > 0 && sqlkomutu2.ExecuteNonQuery()>0)
            {
                sonuc = true;
            }
            baglanti.Close(); //bağlantıyı kapatalım.
            return sonuc; //boolean sonuç değişkenini return edelim.
        }

        //geriye bool dönen, mevcut öğrenci için kitap alım işlemi yaptıran metodu yazalım.
        public bool ogrKitapEkle(string kitapAdi,string numara,string ad,string soyad,string sonTeslimTarihi,double ceza,string teslim_alinma_tarihi)
        {
            string teslim_durumu = "teslim edilmemiş"; //teslim durumu varsayılan olarak teslim edilmemiş olacak.
            bool sonuc = false; //boolean sonuç değişkeni varsayılan olarak false olacak.
            OleDbConnection baglanti = veritabani.baglantiAc(); //veritabanı bağlantısını açalım.
            
            //ilgili sql sorgusunu yazalım ve parametreleri bağlayalım.
            OleDbCommand sqlkomutu = veritabani.baglantiOlustur("INSERT INTO ogrKitap(ogrenci_numara,ogrenci_adi,ogrenci_soyadi,kitap_adi,teslim_durumu,son_teslim_tarihi,ceza,teslim_alinma_tarihi) VALUES(@ogrenci_numara,@ogrenci_adi,@ogrenci_soyadi,@kitap_adi,@teslim_durumu,@son_teslim_tarihi,@ceza,@teslim_alinma_tarihi)");
            sqlkomutu.Parameters.AddWithValue("@ogrenci_numara", numara);
            sqlkomutu.Parameters.AddWithValue("@ogrenci_adi", ad);
            sqlkomutu.Parameters.AddWithValue("@ogrenci_soyadi", soyad);
            sqlkomutu.Parameters.AddWithValue("@kitap_adi", kitapAdi);
            sqlkomutu.Parameters.AddWithValue("@teslim_durumu", teslim_durumu);
            sqlkomutu.Parameters.AddWithValue("@son_teslim_tarihi", sonTeslimTarihi);
            sqlkomutu.Parameters.AddWithValue("@ceza", ceza);
            sqlkomutu.Parameters.AddWithValue("@teslim_alinma_tarihi", teslim_alinma_tarihi);

            //sorguyu çalıştıralım, eğer birden fazla satır etkilenmişse sorgu başarılıdır, boolean sonuç değişkenini true yapalım.
            if (sqlkomutu.ExecuteNonQuery()>0)
            {
                sonuc = true;
            }
            baglanti.Close(); //bağlantıyı kapatalım.
            return sonuc; //sonucu return edelim.
        }
    }
}
