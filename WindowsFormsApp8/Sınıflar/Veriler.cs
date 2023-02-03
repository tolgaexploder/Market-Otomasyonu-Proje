using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using MetroSet_UI.Controls;
using System.Data.SqlClient;
using MetroFramework.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Bunifu.UI.WinForms;
using Bunifu.Framework.UI;
using System.Security.Cryptography;

namespace WindowsFormsApp8
{
    public class veriler
    {
        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\alisveris.mdb");
        public OleDbCommand komut;
        public void KullaniciEkle(TextBox username, TextBox userpass, TextBox ad, TextBox soyad, TextBox tc, TextBox tel, TextBox adres, TextBox email, Form g)
        {

            OleDbDataReader ReadUserData;
            OpenConnection();
            ReadUserData = ReadDatabase("Select * from Uyeler WHERE UserName='" + username.Text + "'");
            if (ReadUserData.Read())
            {
                MessageBox.Show("Bu kullanıcı daha önce alınmış");
            }
            else
            {
                AddOrUpdateDatabase("insert into Uyeler(UserName,UserPassword,ad,soyad,tcno,telefonno,adres,email) values('" + username.Text + "','" + userpass.Text + "','" + ad.Text + "','" + soyad.Text + "','" + tc.Text + "','" + tel.Text + "','" + adres.Text + "','" + email.Text + "')");
                MessageBox.Show("Başarılı Bir şekilde üye oldunuz", "Üye Olma Başarılı");
                Temizle(g);
            }
            CloseConnection();
        }

        public void Temizle(Control ctr)
        {
            foreach (Control c in ctr.Controls)
            {
                if (c is TextBox box)
                    box.Clear();
                if (c.Controls.Count > 0)
                    Temizle(c);
            }

        }
        private void OpenConnection() => baglanti.Open();
        private void CloseConnection() => baglanti.Close();
        private OleDbDataReader ReadDatabase(string sorgu)
        {
            OleDbDataReader ReadData;
            komut = new OleDbCommand(sorgu, baglanti);
            ReadData = komut.ExecuteReader();
            return ReadData;
        }
        private string AddOrUpdateDatabase(string sorgu)
        {
            komut = new OleDbCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            return "Islem Basarili.";
        }

        private string DeleteRow(int numara)
        {
            string sql = "DELETE FROM Sepet";
            komut = new OleDbCommand(sql, baglanti);
            //komut.Parameters.AddWithValue("@urunBarkodNo", numara);
            komut.ExecuteNonQuery();
            return "Islem Basarili.";
        }

        public string DeleteRow2(BunifuDataGridView dataGrid)
        {
            OpenConnection();
            for (int i = 0; i < dataGrid.SelectedRows.Count; i++)
            {
                string sql = "DELETE FROM Sepet WHERE urunBarkodNo='" + dataGrid.SelectedRows[i].Cells[1].Value.ToString() + "'";
                komut = new OleDbCommand(sql, baglanti);
                komut.ExecuteNonQuery();
            }
            CloseConnection();
            return "Islem Basarili.";
        }

        public int VarMi(string urunBarkodNo)
        {
            string userName = Singleton.Instance.currentUser.UserName;

            string sorgu = "SELECT COUNT(urunBarkodNo) FROM Sepet WHERE urunBarkodNo = @urunBarkodNo AND UserName = @userName";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@urunBarkodNo", urunBarkodNo);
            komut.Parameters.AddWithValue("@userName", userName);

            baglanti.Open();
            int result = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();

            return result;
        }

        public void SkyKomisyon(double komisyon)
        {
            if (baglanti.State != ConnectionState.Open) { baglanti.Open(); };
            OleDbDataReader ReadData;
            ReadData = ReadDatabase("Select * from Sky WHERE soyad='" + "Market" + "'");
            if (ReadData.Read())
            {
                double kasabutce = Convert.ToDouble(ReadData["hesapBakiyesi"].ToString());
                Singleton.Instance.currentUser.kasabutce = kasabutce;
                kasabutce += komisyon;
                AddOrUpdateDatabase("update Sky set hesapBakiyesi='" + kasabutce + "' where soyad='" + "Market" + "'");
            }
            baglanti.Close();
        }
        public void siparis_kontrol(string urunAdi, string kacadet, string kacpara, int urunAdetSepet)
        {
            int urunFiyat = 0, urunAdet = 0;
            string saticiAdi = "", barkodNo = "";
            string urunResim = "", urunBirim = "";
            double toplamfiyat = Convert.ToDouble(kacadet) * Convert.ToDouble(kacpara);
            
            double skykomisyon = 0;
            if (toplamfiyat > 50) skykomisyon = toplamfiyat * 0.02;
            else skykomisyon = toplamfiyat * 0.03;
            //50 TL arası olanlardan %3, daha fazlası için %2 komisyon alınır.
            DialogResult onay = MessageBox.Show("Ürün Adı : "+urunAdi+ "\nÜrün Adedi : " + kacadet+ "\nÜrün Birim Fiyati : " + kacpara+"\nToplam fiyat : "+toplamfiyat.ToString() + "\nKomisyon Ucreti: " + skykomisyon.ToString() + " ₺\n\n\n Not: İstediğiniz fiyattan ürünün satışa konulması durumunda işlem otomatik yapılacaktır.", "Onaylıyor musunuz ?", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                OpenConnection();
                OleDbDataReader ReadMinFiyatData = ReadDatabase("Select * from Uruns Where UrunName='" + urunAdi + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
                if (ReadMinFiyatData.Read())
                {
                    urunFiyat = Convert.ToInt32(ReadMinFiyatData["UrunFiyati"].ToString());
                    urunAdet = Convert.ToInt32(ReadMinFiyatData["UrunMiktari"].ToString());
                    saticiAdi = ReadMinFiyatData["UrunSatici"].ToString();
                    barkodNo = ReadMinFiyatData["urunBarkodNo"].ToString();
                    urunResim = ReadMinFiyatData["UrunResimm"].ToString();
                    urunBirim = ReadMinFiyatData["urunBirimi"].ToString();
                }
                CloseConnection();
                if (urunFiyat == 0 || urunAdet == 0)
                {
                    SiparisOlustur(urunAdi, kacadet, kacpara);
                    MessageBox.Show("Siparişiniz beklemeye alınmıştır.\n", "Talep Oluşturuldu!");
                }
                else if (Convert.ToInt32(kacpara) >= urunFiyat && Convert.ToInt32(kacadet) <= urunAdet)
                {
                    MessageBox.Show("Girmiş olduğunuz fiyat şu an marketteki olan ürünün fiyatından yüksek olduğu için talebinize istinaden sepete ekleme işlem, yapıldı.");
                    Singleton.Instance.islem.Talep_Tab_Sepet(Singleton.Instance.currentUser.UserName, barkodNo, urunAdi, urunFiyat, urunAdet, saticiAdi, urunBirim, urunResim, urunAdetSepet);
                }
                else
                {
                    SiparisOlustur(urunAdi, Convert.ToInt32(kacadet).ToString(), kacpara);
                    MessageBox.Show("Siparisiniz beklemeye alinmistir.", "Talep Olusturuldu!");
                }

            }
            else MessageBox.Show("Iptal Edildi", "Iptal Edildi!");

        }
        public void SiparisOlustur(string urunAdi, string kacadet, string kacpara)
        {
            OpenConnection();
            string sorgu = "insert into Siparisler(urunAdi,KacParayaAlacak,KacAdetAlacak,siparisVerenKisi,siparisOlusturulmaTarihi) values('" + urunAdi + "','" + kacpara + "','" + kacadet + "','" + Singleton.Instance.currentUser.UserName + "','" + DateTime.Parse(DateTime.Now.ToString()).ToString() + "')";
            AddOrUpdateDatabase(sorgu);
            CloseConnection();
        }
        public int GetUrunToplamAdet(string urunname)
        {
            int toplamurun = 0;
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
            while (ReadData.Read())
                toplamurun += Convert.ToInt32(ReadData["UrunMiktari"].ToString());
            CloseConnection();
            return toplamurun;
        }
        public double GetToplamPara(string urunname, int miktar)
        {
            double toplamPara = 0;

            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
            while (ReadData.Read())
            {
                int sattigimmiktar;
                if (Convert.ToInt32(ReadData["UrunMiktari"].ToString()) <= miktar)
                {
                    sattigimmiktar = Convert.ToInt32(ReadData["UrunMiktari"].ToString());
                    miktar -= sattigimmiktar;
                    toplamPara += sattigimmiktar * Convert.ToDouble(ReadData["UrunFiyati"].ToString());
                }
                else if (Convert.ToInt32(ReadData["UrunMiktari"].ToString()) > miktar && miktar > 0)
                {
                    sattigimmiktar = miktar;
                    miktar -= sattigimmiktar;
                    toplamPara += sattigimmiktar * Convert.ToDouble(ReadData["UrunFiyati"].ToString());
                }
            }
            CloseConnection();
            return toplamPara;
        }
        public void ParaCek(double toplamfiyat)
        {
            OleDbDataReader ReadData;
            ReadData = ReadDatabase("Select * from Uyeler WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            if (ReadData.Read())
            {
                double x = Convert.ToDouble(ReadData["hesapBakiye"].ToString());
                x -= toplamfiyat;
                AddOrUpdateDatabase("update Uyeler set hesapBakiye='" + x + "' where UserName='" + Singleton.Instance.currentUser.UserName + "'");
            }
        }
        public void SiparisParaCekByUserName(double toplamfiyat, string userName)
        {
            //şu an için kullanmayacağım çünkü sipariş markete eklendiğinde direkt satın almak yerine sepete ekliyorum
            OleDbDataReader ReadData;

            ReadData = ReadDatabase("Select * from Uyeler WHERE UserName='" + userName + "'");
            if (ReadData.Read())
            {
                double x = Convert.ToDouble(ReadData["hesapBakiye"].ToString());
                x -= toplamfiyat;
                AddOrUpdateDatabase("update Uyeler set hesapBakiye='" + x + "' where UserName='" + userName + "'");
            }
        }
        public void Buybox_Sepete_Ekle(string urunname, int miktar)
        {
            int miktar2 = miktar;
            double toplamPara = 0;
            string mesaj = "";
            string urunbirimi = "";
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uruns Where UrunName='" + urunname + "' AND UrunMiktari>0  AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC ");
            while (ReadData.Read())
            {
                urunbirimi = ReadData["UrunBirimi"].ToString();
                int sattigimmiktar = Math.Min(miktar, Convert.ToInt32(ReadData["UrunMiktari"].ToString()));
                miktar -= sattigimmiktar;
                toplamPara += sattigimmiktar * Convert.ToDouble(ReadData["UrunFiyati"].ToString());
                AddOrUpdateDatabase("insert into Sepet(UserName, urunBarkodNo, UrunName, UrunFiyati, UrunMiktari, UrunSatici, UrunBirimi, UrunResimm, urun_adet) values('" + Singleton.Instance.currentUser.UserName + "','" + ReadData["urunBarkodNo"].ToString() + "','" + ReadData["UrunName"].ToString() + "','" + ReadData["UrunFiyati"].ToString() + "','" + Convert.ToInt32(ReadData["UrunMiktari"]) + "','" + ReadData["UrunSatici"].ToString() + "','" + ReadData["UrunBirimi"].ToString() + "','" + ReadData["UrunResimm"].ToString() + "','" + sattigimmiktar.ToString() + "')");
                mesaj += sattigimmiktar + " " + urunbirimi + " --> Birim fiyati :" + Convert.ToDouble(ReadData["UrunFiyati"].ToString()) + " ₺ --> Toplam Fiyat :" + (sattigimmiktar * Convert.ToDouble(ReadData["UrunFiyati"].ToString())).ToString() + " ₺ den sepete eklendi .\n";
            }           
            string topMesaj = "Sepete eklendi: " + miktar2.ToString() + " " + urunbirimi + " " + urunname + ". Toplam Fiyat: " + toplamPara.ToString() + " ₺\n\n";
            MessageBox.Show(topMesaj + mesaj);
            CloseConnection();
            Refresh();
        }
        //Buybox sisteminde kullanıyordum ancak şu an gerekli değil çünkü direkt olarak satın almak yerine sepete ekliyorum
        private void Satinal(OleDbDataReader ReadUrunData, int satismiktari)
        {
            double fiyat = Convert.ToDouble(ReadUrunData["UrunFiyati"].ToString()) * satismiktari;
            string saticiadi = ReadUrunData["UrunSatici"].ToString();
            OleDbDataReader ReadUserData;
            ReadUserData = ReadDatabase("Select * from Uyeler WHERE UserName='" + saticiadi + "'");
            if (ReadUserData.Read())
            {
                double x = Convert.ToDouble(ReadUserData["hesapBakiye"].ToString());
                x += fiyat;
                int urunmiktari = Convert.ToInt32(ReadUrunData["UrunMiktari"].ToString());
                urunmiktari -= satismiktari;
                AddOrUpdateDatabase("update Uyeler set hesapBakiye='" + x + "' where UserName='" + saticiadi + "'");
                AddOrUpdateDatabase("update Uruns set UrunMiktari='" + urunmiktari + "' where urunBarkodNo='" + ReadUrunData["urunBarkodNo"].ToString() + "'");
                AddOrUpdateDatabase("insert into Satislar(UrunAdi,SatisFiyati,SatisMiktari,UrunBirimi,SatisYapan,SatinAlan,SatisTarihi) values('" + ReadUrunData["UrunName"].ToString() + "','" + ReadUrunData["UrunFiyati"].ToString() + "','" + satismiktari.ToString() + "','" + ReadUrunData["UrunBirimi"].ToString() + "','" + saticiadi + "','" + Singleton.Instance.currentUser.UserName + "','" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString() + "')");
            }
        }
        //satın aldıktan sonra gönderiyi kargola
        public void kargo_islemleri(string userName, Label gonderiLabel, MetroComboBox comboBox1, MetroSetTextBox textBox1, MetroComboBox comboBox3, BunifuTextBox richTextBox1)
        {
            Random rdm = new Random();
            int takipno = rdm.Next(100001, 999999);
            string mailkayit = Singleton.Instance.currentUser.Eposta;
            bool varMi = false;

            OpenConnection();

            OleDbDataReader ReadUserData = ReadDatabase("Select * from gonderi_takip WHERE UserName='" + userName + "'");
            while (ReadUserData.Read())
            {
                varMi = true;
                break;
            }

            string sql = "insert into gonderi_takip (UserName, takip_no,teslim_tipi,gonderilen_tarih,odeme_tipi,alici_adres,gonderen_mail) values ('" + userName + "','" + takipno.ToString() + "','" + comboBox1.Text + "','" + textBox1.Text + "','" + comboBox3.Text + "','" + richTextBox1.Text + "','" + mailkayit + "')";
            AddOrUpdateDatabase(sql);

            MessageBox.Show("Gönderiniz Kaydedildi Kargonuz Ekiplerimizce Teslim Edilecektir");
            gonderiLabel.Text = "Son Gönderi Takip No: " + takipno.ToString();
            CloseConnection();
        }
        public void SatinAl_Tab_Sepet(string userName, MetroSetLabel urunName, MetroSetLabel urunFiyati, MetroSetLabel urunSatici, MetroSetLabel urunBirimi)
        {
            OpenConnection();
            OleDbDataReader ReadMinFiyatData = ReadDatabase("SELECT * FROM Uruns WHERE UrunName='" + urunName.Text + "' AND UrunMiktari > 0");

            if (ReadMinFiyatData.Read())
            {
                OleDbDataReader ReadUserData = ReadDatabase("SELECT * FROM Sepet WHERE UserName='" + userName + "' AND urunBarkodNo='" + ReadMinFiyatData["urunBarkodNo"] + "'");
                if (ReadUserData.Read())
                {
                    AddOrUpdateDatabase("UPDATE Sepet SET UrunFiyati='" + urunFiyati.Text + "', UrunMiktari='" + ReadMinFiyatData["UrunMiktari"] + "', UrunSatici='" + urunSatici.Text + "', UrunBirimi='" + urunBirimi.Text + "', UrunResimm='" + ReadMinFiyatData["UrunResimm"] + "' WHERE UserName='" + userName + "' AND urunBarkodNo='" + ReadMinFiyatData["urunBarkodNo"] + "'");
                }
                else
                {
                    AddOrUpdateDatabase("INSERT INTO Sepet(UserName, urunBarkodNo, UrunName, UrunFiyati, UrunMiktari, UrunSatici, UrunBirimi, UrunResimm) VALUES('" + userName + "','" + ReadMinFiyatData["urunBarkodNo"] + "','" + urunName.Text + "','" + urunFiyati.Text + "','" + ReadMinFiyatData["UrunMiktari"] + "','" + urunSatici.Text + "','" + urunBirimi.Text + "','" + ReadMinFiyatData["UrunResimm"] + "')");
                }
            }
            CloseConnection();
        }
        public void Talep_Tab_Sepet(string userName, string urunBarkodNo, string urunName, double urunFiyati, int urunMiktari, string urunSatici, string urunBirimi, string urunResimm, int urunAdet)
        {
            OpenConnection();
            AddOrUpdateDatabase("insert into Sepet(UserName,urunBarkodNo,UrunName,UrunFiyati,UrunMiktari,UrunSatici,UrunBirimi,UrunResimm, urun_adet) values('" + userName + "','" + urunBarkodNo + "','" + urunName + "','" + urunFiyati + "','" + urunMiktari + "','" + urunSatici + "','" + urunBirimi + "','" + urunResimm + "','" + urunAdet + "')");
            CloseConnection();
        }
        public void veri_sil(BunifuTextBox userName, int barkod)
        {
            OleDbDataReader ReadUserData;
            OpenConnection();
            ReadUserData = ReadDatabase("Select * from Sepet WHERE UserName='" + userName.Text + "'");
            if (ReadUserData.Read())
            {
                DeleteRow(barkod);
            }
            else
            {
                MessageBox.Show("Sepetinizde Ürün Bulunmamaktadır");
            }
            CloseConnection();
        }
        public void ListBoxDoldur(MetroSetListBox list)
        {
            list.Items.Clear();
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uruns Where UrunOnay='" + "Onaylandı" + "'AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "'");
            while (ReadData.Read())
                list.Items.Add(ReadData["UrunTuru"].ToString());
            CloseConnection();
        }
        public void Kategori_Listele(MetroSetComboBox list)
        {
            list.Items.Clear();
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uruns Where UrunMiktari>0");
            while (ReadData.Read())
                list.Items.Add(ReadData["UrunTuru"].ToString());
            CloseConnection();
        }
        public void Current_user_update(OleDbDataReader ReadUser)
        {
            Singleton.Instance.currentUser.UserID = Convert.ToInt32(ReadUser["UserID"].ToString());
            Singleton.Instance.currentUser.UserName = ReadUser["UserName"].ToString();
            Singleton.Instance.currentUser.UserPass = ReadUser["UserPassword"].ToString();
            Singleton.Instance.currentUser.Ad = ReadUser["ad"].ToString();
            Singleton.Instance.currentUser.SoyAd = ReadUser["soyad"].ToString();
            Singleton.Instance.currentUser.Adres = ReadUser["adres"].ToString();
            Singleton.Instance.currentUser.Eposta = ReadUser["email"].ToString();
            Singleton.Instance.currentUser.Tc = Convert.ToInt64(ReadUser["tcno"].ToString());
            Singleton.Instance.currentUser.Telefon = ReadUser["telefonno"].ToString();
            Singleton.Instance.currentUser.Bakiye = Convert.ToDouble(ReadUser["hesapBakiye"].ToString());
            Singleton.Instance.currentUser.PasifBakiye = Convert.ToDouble(ReadUser["geciciBakiye"].ToString());
            Singleton.Instance.currentUser.ParaBirimi = ReadUser["parabirimi"].ToString();
            Singleton.Instance.currentUser.ProfilFoto = ReadUser["UyeResim"].ToString();
        }

        public void Current_user_update_cikis()
        {
            Singleton.Instance.currentUser.UserID = 0;
            Singleton.Instance.currentUser.UserName = null;
            Singleton.Instance.currentUser.UserPass = null;
            Singleton.Instance.currentUser.Ad = null;
            Singleton.Instance.currentUser.SoyAd = null;
            Singleton.Instance.currentUser.Adres = null;
            Singleton.Instance.currentUser.Eposta = null;
            Singleton.Instance.currentUser.Tc = 0;
            Singleton.Instance.currentUser.Telefon = null;
            Singleton.Instance.currentUser.Bakiye = 0;
            Singleton.Instance.currentUser.PasifBakiye = 0;
            Singleton.Instance.currentUser.ParaBirimi = null;
            Singleton.Instance.currentUser.ProfilFoto = null;
            Singleton.Instance.form1.bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
            Singleton.Instance.form1.sepet_odenecektutar_label.Text = "0";
        }
        public void Refresh()
        {
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uyeler WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            if (ReadData.Read())
                Current_user_update(ReadData);
            CloseConnection();

           // Singleton.Instance.main.AnaSayfaOnLoad();
        }
        public void buton3(ComboBox metroComboBox1)
        {
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("SELECT * FROM gonderi_takip");
            while (ReadData.Read())
                metroComboBox1.Items.Add(ReadData["takip_no"]);
            CloseConnection();
        }
        public void kargo_durum_guncelle(ComboBox comboBox2, ComboBox comboBox1)
        {
            string sorgu = ("update gonderi_takip set durum='" + comboBox2.Text + "' where takip_no= '" +comboBox1.Text + "'");
            AccessUpdateIslemleri(sorgu);
            MessageBox.Show("Durum Güncellendi!");
        }
        public void admin_guncelle(TextBox textbox1, TextBox textbox2, TextBox textbox3)
        {
            string sorgu = ("update Admins set adminName='" + textbox1.Text + "' adminPassword= '" + textbox2.Text + "' where adminId= '" + textbox3.Text + "'");
            AccessUpdateIslemleri(sorgu);
            MessageBox.Show("Durum Güncellendi!");
        }

        public void NoLoadRefresh()
        {
            OleDbDataReader ReadData;
            OpenConnection();
            ReadData = ReadDatabase("Select * from Uyeler WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            if (ReadData.Read())
                Current_user_update(ReadData);
            CloseConnection();
        }
        public DataTable Showdatabases(string sorgu)
        {
            OleDbDataAdapter db;
            OpenConnection();
            db = new OleDbDataAdapter(sorgu, baglanti);
            DataTable tablo = new DataTable();
            db.Fill(tablo);
            CloseConnection();
            return tablo;
        }

        public void KullaniciGirisi(TextBox ad, TextBox parola, Form g)
        {
            OleDbDataReader ReadUserData;
            OpenConnection();
            ReadUserData = ReadDatabase("Select * from Uyeler WHERE UserName='" + ad.Text + "' AND UserPassword='" + parola.Text + "'");
            if (ReadUserData.Read())
            {
                Current_user_update(ReadUserData);
                Temizle(g);
                CloseConnection();
                Singleton.Instance.form1.Form1OnLoad();
                Singleton.Instance.ChangeScreen(g, Singleton.Instance.form1);
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                CloseConnection();
            }
            CloseConnection();
        }

        public void AdminGirisi(TextBox adminname, TextBox adminpassword, Form g)
        {
            OleDbDataReader ReadAdminData;
            OpenConnection();
            ReadAdminData = ReadDatabase("Select * from Admins WHERE adminName='" + adminname.Text + "' AND adminPassword='" + adminpassword.Text + "'");
            if (ReadAdminData.Read())
            {
                CloseConnection();
                Singleton.Instance.adminForm.AdminFormOnLoad();
                Singleton.Instance.ChangeScreen(g, Singleton.Instance.adminForm);
            }
            else
            {
                CloseConnection();
                MessageBox.Show("Giriş Başarısız");
            }

            Temizle(g);
        }

        public void YoneticiGirisi(TextBox managername, TextBox managerpassword, Form g)
        {
            OleDbDataReader ReadAdminData;
            OpenConnection();
            ReadAdminData = ReadDatabase("Select * from Managers WHERE managerName='" + managername.Text + "' AND managerPassword='" + managerpassword.Text + "'");
            if (ReadAdminData.Read())
            {
                CloseConnection();
                Singleton.Instance.yoneticiPaneli.yoneticiFormOnLoad();
                Singleton.Instance.ChangeScreen(g, Singleton.Instance.yoneticiPaneli);
            }
            else
            {
                CloseConnection();
                MessageBox.Show("Giriş Başarısız");
            }

            Temizle(g);
        }
        public void UrunEkle(BunifuTextBox urunbarkodno, MetroSetComboBox urunbirimi, BunifuTextBox urunfiyati, BunifuTextBox urunmiktari, BunifuTextBox urunname, MetroSetComboBox urunturu, string UrunSatici, BunifuCards g, BunifuTextBox urunResim)
        {
            try
            {
                OleDbDataReader ReadUrunData;
                if (urunbarkodno.Text == "" || urunbirimi.Text == "" || urunfiyati.Text == "" || urunmiktari.Text == "" || urunname.Text == "" || urunturu.Text == "" || urunResim.Text == "")
                {
                    MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                    return;
                }
                else
                {
                    OpenConnection();
                    ReadUrunData = ReadDatabase("Select * from Uruns WHERE urunBarkodNo='" + urunbarkodno.Text + "'");
                    if (ReadUrunData.Read()) MessageBox.Show("Bu Barkod Daha Önce Alınmış");
                    else
                    {
                        AddOrUpdateDatabase("insert into Uruns(UrunName,UrunMiktari,UrunFiyati,UrunTuru,UrunSatici,urunOnay,urunBirimi,urunBarkodNo,UrunResimm) values('" + urunname.Text + "','" + Convert.ToInt32(urunmiktari.Text) + "','" + Convert.ToDouble(urunfiyati.Text) + "','" + urunturu.Text + "','" + UrunSatici + "','" + "Onaylanmadı" + "','" + urunbirimi.Text + "','" + urunbarkodno.Text + "','" + urunResim.Text + "')");
                        Temizle(g);
                        MessageBox.Show("Urun listeye eklenmistir. Onay sonrasi pazarda goruntulenecektir.", "Urun Eklendi");
                    }
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Lütfen girdiğiniz bilgileri kontrol ediniz.");
            }
        }

        public void adminEkle(TextBox adminid, TextBox adminad, TextBox adminsifre, GroupBox g)
        {
            OleDbDataReader ReadUrunData;
            if (adminid.Text == "" || adminad.Text == "" || adminsifre.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                return;
            }
            else
            {
                OpenConnection();
                ReadUrunData = ReadDatabase("Select * from Admins WHERE adminId='" + adminid.Text + "'");
                if (ReadUrunData.Read()) MessageBox.Show("Bu Barkod Daha Önce Alınmış");
                else
                {
                    AddOrUpdateDatabase("insert into Admins(adminId,adminAd,adminPassword) values('" + adminid.Text + "','" + Convert.ToInt32(adminid.Text) + "','" + adminad.Text + "','" + adminsifre + "')");
                    Temizle(g);
                    MessageBox.Show("Admin listeye eklenmistir.", "Admin Eklendi");
                }
                CloseConnection();
            }
        }
        public void AccessUpdateIslemleri(string sorgu)
        {
            OpenConnection();
            AddOrUpdateDatabase(sorgu);
            CloseConnection();
        }
        public void GecicibakiyeGuncelle(double gecicibakiye)
        {
            string sorgu = ("update Uyeler set geciciBakiye='" + gecicibakiye + "',sonparayuklemetarihi='"+ DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString()+"' where UserName='" + Singleton.Instance.currentUser.UserName + "'");
            AccessUpdateIslemleri(sorgu);
            MessageBox.Show("Bakiye yükleme işlemi tamamlandı. Admin onayı bekleniyor.");
            Refresh();
        }
        public void UserUpdate(TextBox userpass, TextBox email, TextBox adres, TextBox telefonno)
        {
            string sorgu = ("update Uyeler set UserPassword='" + userpass.Text + "' ,email='" + email.Text + "',adres='" + adres.Text + "',telefonno='" + telefonno.Text + "' where UserName='" + Singleton.Instance.currentUser.UserName + "'");
            AccessUpdateIslemleri(sorgu);
            Refresh();
        }
        public void UrunUpdate(BunifuTextBox urunfiyati, BunifuTextBox urunmiktari, string urunbarkod, BunifuCards g)
        {
            string sorgu = ("update Uruns set urunMiktari='" + Convert.ToInt32(urunmiktari.Text) + "' ,urunFiyati='" + Convert.ToInt32(urunfiyati.Text) + "',urunOnay='" + "Onaylanmadı" + "' where urunBarkodNo='" + urunbarkod + "'");
            AccessUpdateIslemleri(sorgu);
            Temizle(g);
        }
        public void UrunOnay(MetroSetTextBox barkodno)
        {
            string sorgu = ("update Uruns set urunOnay='" + "Onaylandı" + "' where urunBarkodNo='" + barkodno + "'");
            AccessUpdateIslemleri(sorgu);
        }
        public void UrunSatinAl(double toplamfiyat, string mesaj, double skykomisyon)
        {
            OpenConnection();
            ParaCek(toplamfiyat + skykomisyon);
            CloseConnection();

            OpenConnection();
            OleDbDataReader ReadDenemeData = ReadDatabase("SELECT * FROM Sepet WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            while (ReadDenemeData.Read())
            {
                OleDbDataReader ReadUserData = ReadDatabase("SELECT * FROM Uyeler WHERE UserName='" + ReadDenemeData["UrunSatici"] + "'");
                if (ReadUserData.Read())
                {
                    double newBakiye = Convert.ToDouble(ReadUserData["hesapBakiye"].ToString());
                    double toplamfiyat_sepet = Convert.ToDouble(ReadDenemeData["UrunFiyati"].ToString());
                    newBakiye += toplamfiyat_sepet;
                    AddOrUpdateDatabase("UPDATE Uyeler SET hesapBakiye='" + newBakiye + "' WHERE UserName='" + ReadDenemeData["UrunSatici"] + "'");
                }
            }
            CloseConnection();

            OpenConnection();
            OleDbDataReader ReadSiparislerData = ReadDatabase("SELECT * FROM Sepet WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
            while (ReadSiparislerData.Read())
            {
                OleDbDataReader ReadUrunData = ReadDatabase("SELECT * FROM Uruns WHERE urunBarkodNo='" + ReadSiparislerData["urunBarkodNo"] + "'");

                if (ReadUrunData.Read())
                {
                    int newAdetSayisi = Convert.ToInt32(ReadUrunData["UrunMiktari"].ToString());
                    int adet = Convert.ToInt32(ReadSiparislerData["urun_adet"].ToString());
                    newAdetSayisi -= adet;

                    AddOrUpdateDatabase("UPDATE Uruns SET UrunMiktari='" + newAdetSayisi + "' WHERE urunBarkodNo='" + ReadSiparislerData["urunBarkodNo"].ToString() + "'");
                    AddOrUpdateDatabase("INSERT INTO Satislar(UrunAdi,SatisFiyati,SatisMiktari,UrunBirimi,SatisYapan,SatinAlan,SatisTarihi) VALUES('" + ReadUrunData["UrunName"].ToString() + "','" + ReadUrunData["UrunFiyati"].ToString() + "','" + adet.ToString() + "','" + ReadUrunData["UrunBirimi"].ToString() + "','" + ReadSiparislerData["UrunSatici"] + "','" + Singleton.Instance.currentUser.UserName + "','" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString() + "')");
                }
            }
            CloseConnection();

            MessageBox.Show(mesaj, "Satın Alma İşlemi Onaylandı");
            Refresh();
        }

        public void UrunSepet(string barkodno, int newAdetSayisi)
        {
            OpenConnection();
            OleDbDataReader ReadUrunData;
            ReadUrunData = ReadDatabase("Select * from Sepet WHERE urunBarkodNo='" + barkodno + "'");
            if (ReadUrunData.Read())
            {
                AddOrUpdateDatabase("update Sepet set urun_adet='" + newAdetSayisi + "' where urunBarkodNo='" + barkodno + "'");            
            }

            CloseConnection();
            Refresh();
        }

        public void urun_adet_guncelle(int newAdetSayisi, string barkodno)
        {
            string sorgu = ("update Sepet set urun_adet='" + newAdetSayisi + "' where urunBarkodNo='" + barkodno + "'");
            AccessUpdateIslemleri(sorgu);
        }
        
        public void GeciciBakiyeDegistirWithUsername(string username, double gecicibakiye)
        {
            string sorgu = ("update Uyeler set geciciBakiye='" + gecicibakiye + "',parabirimi='" + "TL" + "' where UserName='" + username + "'");
            AccessUpdateIslemleri(sorgu);
        }
        public void UrunOnay(string barkodno)
        {
            string sorgu = ("update Uruns set urunOnay='" + "Onaylandı" + "' where urunBarkodNo='" + barkodno + "'");
            AccessUpdateIslemleri(sorgu);
        }

        public void BakiyeOnay(string username, double guncelbakiye)
        {
            string sorgu = ("update Uyeler set geciciBakiye='" + 0 + "' ,hesapBakiye='" + guncelbakiye + "' where UserName='" + username + "'");
            AccessUpdateIslemleri(sorgu);
        }
        public void uye_siparisten_sepete_ekle()
        {
            OpenConnection();
            OleDbDataReader ReadSiparislerData = ReadDatabase("Select * from Siparisler Where siparisDurumu='" + "Beklemede" + "' ORDER BY siparisOlusturulmaTarihi ASC ");
            while (ReadSiparislerData.Read())
            {
                double siparisFiyati = Convert.ToDouble(ReadSiparislerData["KacParayaAlacak"].ToString());
                int adetSayisi = Convert.ToInt32(ReadSiparislerData["KacAdetAlacak"].ToString());
                double toplamFiyat = siparisFiyati * adetSayisi;
                double kasakomisyon = toplamFiyat / 100;
                double toplamCekilecekPara = toplamFiyat + kasakomisyon;
                double userHesapbakiyesi = 0;
                OleDbDataReader ReadUserBilgileri = ReadDatabase("Select * from Uyeler Where UserName='" + ReadSiparislerData["siparisVerenKisi"].ToString()+ "'");
                if (ReadUserBilgileri.Read())
                    userHesapbakiyesi = Convert.ToDouble(ReadUserBilgileri["hesapBakiye"].ToString());

                if (userHesapbakiyesi >= toplamCekilecekPara)
                {

                    OleDbDataReader ReadUrunlerData = ReadDatabase("Select * from Uruns Where UrunName='" + ReadSiparislerData["urunAdi"].ToString() + "' AND UrunMiktari>0 AND urunOnay='"+ "Onaylandı" + "' AND NOT UrunSatici='" + ReadSiparislerData["siparisVerenKisi"].ToString() + "' ORDER BY UrunFiyati ASC");
                    if (ReadUrunlerData.Read())
                    {
                        int urunSayisi = Convert.ToInt32(ReadUrunlerData["UrunMiktari"].ToString());
                        double urunFiyati = Convert.ToInt32(ReadUrunlerData["UrunFiyati"].ToString());
                        if (siparisFiyati == urunFiyati && adetSayisi <= urunSayisi)
                        {
                            MessageBox.Show("Talep ettiğiniz ürün sepetinize eklenmiştir, Keyifli alışverişler.");
                            AddOrUpdateDatabase("insert into Sepet(UserName,urunBarkodNo,UrunName,UrunFiyati,UrunMiktari,UrunSatici,UrunBirimi,UrunResimm, urun_adet) values('" + ReadSiparislerData["siparisVerenKisi"].ToString() + "','" + ReadUrunlerData["urunBarkodNo"].ToString() + "','" + ReadUrunlerData["UrunName"].ToString() + "','" + ReadUrunlerData["UrunFiyati"].ToString() + "','" + urunSayisi.ToString() + "','" + ReadUrunlerData["UrunSatici"].ToString() + "','" + ReadUrunlerData["UrunBirimi"].ToString() + "','" + ReadUrunlerData["UrunResimm"].ToString() + "','" + adetSayisi.ToString() + "')");
                            AddOrUpdateDatabase("update Siparisler set SiparisDurumu='" + "Satin alindi" + "' where urunAdi='" + ReadSiparislerData["urunAdi"].ToString() + "' ");
                        }
                    }
                }
            }
            CloseConnection();
            NoLoadRefresh();
        }
    }
}