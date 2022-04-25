using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb; // access veritabanıyla çalışabilmek için eklendi.

namespace kutuphane_otomasyonu.veriKatmani
{
    internal class veritabani
    {
        public static OleDbConnection baglantiAc()
        {
            //connectionstring (bağlantı metni) bilgisini girelim ve bağlantıyı açalım, ardından oledbconnection tipindeki bağlantı nesnesini return edelim.
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kutuphane_veritabani.accdb;");
            baglanti.Open();
            return baglanti;
        }
        public static OleDbCommand baglantiOlustur(string sorgu) //her sorgu işleminde bu method çalıştırılacak.
        {
            OleDbCommand sqlkomutu = new OleDbCommand(sorgu, baglantiAc()); //sorguyu ve bağlantı nesnesini parametre olarak alan bir oledbcommand nesnesi oluşturalım.
            return sqlkomutu;
        }
    }
}
