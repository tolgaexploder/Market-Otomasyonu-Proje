using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Properties;
using MetroFramework.Controls;
using MetroSet_UI.Controls;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Application = System.Windows.Forms.Application;

namespace WindowsFormsApp8.Formlar
{
    public partial class Form1 : MaterialForm
    {
        private string sorgu = "";
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue700, Primary.BlueGrey500, Accent.Blue700, TextShade.WHITE);

            this.Size = new Size(1093, 472);

            var tab_kontrol = materialTabControl1.SelectedTab.Controls.Cast<Control>();
            if (tab_kontrol.Any())
            {
                //formun scale sorunları var ancak manuel olarak bu şekilde çözüyorum
                this.Height = tab_kontrol.Max(x => x.Bottom) + 90;
                //this.Width = controls.Max(x => x.Left) + 240;
                this.Width = tab_kontrol.Max(x => x.Right) + 75;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1OnLoad();
        }
        public void Form1OnLoad()
        {

            this.MaximizeBox = false;
            Singleton.Instance.islem.uye_siparisten_sepete_ekle();

            metroTextBox1.Text = DateTime.Today.ToShortDateString();

            KendiSatislarim_CheckBox.Checked = true;
            KendiSatislarim_CheckBox.Checked = false;

            guncel_profil();
            sepet_sorgu_refresh();

            bunifuDataGridView3.Columns[2].Width = 140;

            materialTabControl1.SizeMode = TabSizeMode.Normal;
            materialTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            materialTabControl1.SelectedTab = materialTabControl1.TabPages[0];

            data_grid_ayarlari();

            if (string.IsNullOrEmpty(pusername_label.Text))
            {
                if (materialTabControl1.TabPages.Contains(tabPage3) || materialTabControl1.TabPages.Contains(tabPage5) || materialTabControl1.TabPages.Contains(tabPage6) || materialTabControl1.TabPages.Contains(tabPage7))
                {
                    materialTabControl1.TabPages.Remove(tabPage3);
                    materialTabControl1.TabPages.Remove(tabPage5);
                    materialTabControl1.TabPages.Remove(tabPage6);
                    materialTabControl1.TabPages.Remove(tabPage7);
                }
                else
                {
                    materialTabControl1.TabPages.Insert(2, tabPage3);
                    materialTabControl1.TabPages.Insert(4, tabPage5);
                    materialTabControl1.TabPages.Insert(6, tabPage7);
                }
            }
        }

        static bool SayiMi(string deger)
        {
            try
            {
                int.Parse(deger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void listele_comboBox_Kontrol()
        {
            //satisbaslik_lbl.Text = listeleCombo.Text;
            sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.UserName + "'";
            if (listeleCombo.Text == "Tüm Satışlarım")
                sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.UserName + "'";
            if (listeleCombo.Text == "Onaylanmış Satışlarım")
                sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND urunonay='" + "Onaylandı" + "'";
            if (listeleCombo.Text == "Onaylanmamış Satışlarım")
                sorgu = "SELECT * FROM showUruns WHERE UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND urunonay='" + "Onaylanmadı" + "'";
            urun_grid.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            int[] sutunIndeksleri = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            string[] baslikIsimleri = { "ID", "Ürün İsmi", "Ürün Miktarı", "Birim", "Fiyat(TL)", "Ürün Türü", "Satıcı", "Barkod", "Onay Durumu" };

            for (int i = 0; i < sutunIndeksleri.Length; i++)
            {
                urun_grid.Columns[sutunIndeksleri[i]].HeaderText = baslikIsimleri[i];
                if (i == 2)
                {
                    urun_grid.Columns[sutunIndeksleri[i]].Width = 10;
                }
            }
            urun_grid.Columns["UrunResimm"].Visible = false;
        }

        private void sepet_sorgu_refresh()
        {
            sorgu = "SELECT * FROM Sepet WHERE UserName='" + pusername_label.Text + "'";
            bunifuDataGridView3.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }

        public void guncel_profil()
        {
            profilad_label.Text = Singleton.Instance.currentUser.Ad;
            psoyad_label.Text = Singleton.Instance.currentUser.SoyAd;
            pusername_label.Text = Singleton.Instance.currentUser.UserName;
            puserpass_txt.Text = Singleton.Instance.currentUser.UserPass;
            //ptcno.Text = Singleton.Instance.currentUser.Tc.ToString();
            if (string.IsNullOrEmpty(profilad_label.Text))
            {
                ptelefonno_txt = null;
            }
            else
            {
                ptelefonno_txt.Text = Singleton.Instance.currentUser.Telefon.ToString();
            }
            padres_txt.Text = Singleton.Instance.currentUser.Adres;
            p_emailtxt.Text = Singleton.Instance.currentUser.Eposta;
            bakiye_label.Text = Singleton.Instance.currentUser.Bakiye.ToString();
            geciciBakiye_label.Text = Singleton.Instance.currentUser.PasifBakiye.ToString();
            bunifuPictureBox2.ImageLocation = Singleton.Instance.currentUser.ProfilFoto;
            kacadetalmak_txt.Text = "";
        }
        private const int COLUMN_WIDTH = 250;
        private readonly Color TRANSPARENT = Color.Transparent;
        private void data_grid_ayarlari()
        {
            bunifuDataGridView2.ColumnHeadersVisible = false;
            bunifuDataGridView2.RowHeadersVisible = false;

            dataGridView1.RowHeadersVisible = false;

            pictureBox1.BackColor = TRANSPARENT;
            pictureBox5.BackColor = TRANSPARENT;
            pictureBox6.BackColor = TRANSPARENT;

            string[] hiddenColumns = { "UrunID", "urunOnay", "UrunResimm", "UrunMiktari", "urunBarkodNo", "UrunMiktari", "urunBarkodNo" };
            foreach (var column in bunifuDataGridView2.Columns.Cast<DataGridViewColumn>().Where(c => hiddenColumns.Contains(c.Name)))
            {
                column.Visible = false;
            }

            bunifuDataGridView2.Columns[1].Width = COLUMN_WIDTH;

            string[] sutunIsimleri = { "UserName", "UrunName", "UrunFiyati", "UrunSatici", "UrunBirimi", "urun_adet" };
            string[] baslikIsimleri = { "Kullanıcı Adı", "Ürün İsmi", "Ürün Fiyatı", "Tedarikçi", "Birim", "Adet" };

            for (int i = 0; i < sutunIsimleri.Length; i++)
            {
                bunifuDataGridView3.Columns[sutunIsimleri[i]].HeaderText = baslikIsimleri[i];
            }

            string[] hiddenColumns2 = { "UrunName", "UrunSatici", "UrunFiyati", "UrunBirimi", "UrunMiktari", "UrunResimm", "urunBarkodNo" };
            foreach (var column in bunifuDataGridView3.Columns.Cast<DataGridViewColumn>().Where(c => hiddenColumns2.Contains(c.Name)))
            {
                column.Visible = false;
            }

            double iTotal = 0;
            for (int index = 0; index <= bunifuDataGridView3.RowCount - 1; index++)
            {
                iTotal += Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[3].Value) * Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[8].Value);
            }
            if (bunifuDataGridView3.Rows.Count == 0 || string.IsNullOrEmpty(bunifuDataGridView3.Rows[0].Cells[0].Value.ToString()))
            {
                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
            }
            else if (iTotal <= 40)
            {
                bunifuTextBox1.Text = "Kargo Ücreti: 10 TL";
                iTotal += 10;
            }
            else
            {
                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
            }

            sepet_odenecektutar_label.Text = iTotal.ToString();


            if (string.IsNullOrEmpty(profilad_label.Text))
            {
                bunifuDataGridView3.Columns.Clear();
                bunifuDataGridView3.Refresh();
                urun_grid.Columns.Clear();
                urun_grid.Refresh();
            }
        }

        private void sepet_guncel_tutare()
        {
            double sepet_guncel_tutar = 0;
            for (int index = 0; index <= bunifuDataGridView3.RowCount - 1; index++)
            {
                sepet_guncel_tutar += Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[3].Value) * Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[8].Value);
            }

            if (bunifuDataGridView3.Rows.Count == 0)
            {
                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
            }
            else if (sepet_guncel_tutar <= 40)
            {
                sepet_guncel_tutar += 10;
                bunifuTextBox1.Text = "Kargo Ücreti: 10 TL";
            }
            else
            {
                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
            }

            sepet_odenecektutar_label.Text = sepet_guncel_tutar.ToString();
        }
        private void CheckBoxcontrol()
        {
            if (KendiSatislarim_CheckBox.Checked == true)
            {
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylandı" + "' AND UrunMiktari>0 ";
                bunifuDataGridView2.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
                // Singleton.Instance.sepet.sepet_datagrid.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            }

            if (KendiSatislarim_CheckBox.Checked == false)
            {
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylandı" + "' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "'";
                bunifuDataGridView2.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
                //Singleton.Instance.sepet.sepet_datagrid.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            }
        }
        private void satinal_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pusername_label.Text))
            {
                MessageBox.Show("Lütfen sepete ekleme yapmaya devam etmeden önce giriş yapınız.");
                return;
            }

            if (urunsaticilabel.Text == Singleton.Instance.currentUser.UserName)
            {
                MessageBox.Show("Kendi Ürününüzü Sepete Ekleyemezsiniz.", "Hatalı ürün seçimi");
            }
            else
            {
                DialogResult onay = MessageBox.Show("Seçili ürünü sepete eklemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var barkodno_label = bunifuDataGridView2.CurrentRow.Cells["urunBarkodNo"].Value.ToString();
                    int result = Singleton.Instance.islem.VarMi(barkodno_label);
                    if (result > 0)
                    {
                        MessageBox.Show("Bu ürün daha önceden sepete eklenmiş.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ürün sepete eklendi.");
                        Singleton.Instance.islem.SatinAl_Tab_Sepet(Singleton.Instance.currentUser.UserName, urunadilabel, fiyat_label, urunsaticilabel, urunbirimilabel);
                        sepet_sorgu_refresh();
                    }

                    sepet_guncel_tutare();
                }
                else
                {
                    MessageBox.Show("İşlem iptal edildi");
                }
            }
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int istenenadet = Convert.ToInt32(sepet_alinanadet_txt.Text);
            //    int stokadet = Convert.ToInt32(sepet_stok_lbl.Text);
            //    if (SayiMi(sepet_alinanadet_txt.Text))
            //    {
            //        if (istenenadet <= stokadet)
            //        {
            //            satinal_btn.Visible = true;

            //            double toplam = 0;
            //            foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
            //            {
            //                string id = row.Cells[3].Value.ToString();
            //                double x = Convert.ToDouble(id);
            //                toplam += x;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Stokta bu kadar yok. Alim adetini dusurebilirsin.");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lütfen adet kismina miktar giriniz");
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Lütfen adet giriniz.");
            //}
        }

        public void sepet_refresh()
        {
            //sepet_barkodno_label.Text = "-";
            sepet_urunadilabel.Text = "-";
            //sepet_stok_lbl.Text = "-";
            //sepet_urunbirimilabel.Text = "-";
            sepet_odenecektutar_label.Text = "-";
            sepet_alinanadet_txt.Text = "Adet Giriniz";
            sepet_alinanadet_txt.Text = "";
        }
        private void KendiSatislarim_CheckBox_CheckedChanged(object sender, EventArgs e) => CheckBoxcontrol();

        private void sepet_satinaldiktan_sonra_sil()
        {
            //foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
            //{
            //    int numara = Convert.ToInt32(bunifuDataGridView3.Cells[3].Value);

            //    string id = row.Cells[1].Value.ToString();
            //    int x = Convert.ToInt32(id);
            //    Singleton.Instance.islem.veri_sil(pusername_label, x);
            //    sepet_sorgu_refresh();
            //}

            Singleton.Instance.islem.DeleteRow2(bunifuDataGridView3);
            sepet_sorgu_refresh();
            sepet_refresh();
        }
        private void sepet_satinaldiktan_sonra_sil2()
        {
            foreach (DataGridViewRow row in bunifuDataGridView3.Rows)
            {
                string id = row.Cells[1].Value.ToString();
                int x = Convert.ToInt32(id);
                Singleton.Instance.islem.veri_sil(pusername_label, x);
                sepet_sorgu_refresh();
            }

            //Singleton.Instance.islem.DeleteRow(bunifuDataGridView3);
            //sepet_sorgu_refresh();
            sepet_refresh();
        }
        private void metroTile3_Click(object sender, EventArgs e)
        {
            sepet_satinaldiktan_sonra_sil();

            double sepet_guncel_tutar = 0;
            for (int index = 0; index <= bunifuDataGridView3.RowCount - 1; index++)
            {
                sepet_guncel_tutar += Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[3].Value) * Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[8].Value);
            }

            if (bunifuDataGridView3.Rows.Count == 0)
            {
                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
            }
            else if (sepet_guncel_tutar <= 40)
            {
                sepet_guncel_tutar += 10;
                bunifuTextBox1.Text = "Kargo Ücreti: 10 TL";
            }
            else
            {
                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
            }

            sepet_odenecektutar_label.Text = sepet_guncel_tutar.ToString();

            if (bunifuDataGridView3.Rows.Count == 0)
                pictureBox5.Image = Properties.Resources.cart;
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(profilad_label.Text))
            {
                MessageBox.Show("Lütfen satın almaya devam etmeden önce giriş yapınız.");
                return;
            }

            if (string.IsNullOrEmpty(sepet_alinanadet_txt.Text))
            {
                MessageBox.Show("Lütfen ürün seçiniz.");
                return;
            }

            if (rch_adres_txt.TextLength <= 30)
            {
                MessageBox.Show("Lütfen adresinizi 30 karakterden fazla giriniz.");
                return;
            }

            double toplam = Convert.ToDouble(sepet_odenecektutar_label.Text);
            double skykomisyon = 0;

            if (toplam > 50) skykomisyon = toplam * 0.02;
            else skykomisyon = toplam * 0.03;
            //50 TL arası olanlardan %3, daha fazlası için %2 komisyon alınır.

            double geneltoplam = toplam + skykomisyon;

            string x;

            DialogResult onay = MessageBox.Show("Satın almaya devam etmek istediginize emin misiniz? Toplam Fiyat(komisyon ile):" + geneltoplam.ToString() + " ₺", "Emin misin ?", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                if (geneltoplam > Singleton.Instance.currentUser.Bakiye)
                {
                    double eksikbakiye = geneltoplam - Convert.ToInt32(Singleton.Instance.currentUser.Bakiye);
                    DialogResult dialogResult = MessageBox.Show("Bu ürünü almak için bakiyeniz yetersiz bu ürün için eksik bakiyeniz :" + eksikbakiye.ToString() + "₺ dir. Eksik Bakiyeyi Yüklemek istermisiniz", "Bakiye Yetersizliği !!!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Singleton.Instance.islem.GecicibakiyeGuncelle(eksikbakiye);
                    }
                }
                else if (geneltoplam > 0)
                {
                    x = "Satin alma islemleri tamamlandi.";

                    if (string.IsNullOrEmpty(profilad_label.Text))
                    {
                        MessageBox.Show("Lütfen giriş yapınız.");
                        return;
                    }

                    else if (string.IsNullOrEmpty(metroTextBox1.Text) || string.IsNullOrEmpty(rch_adres_txt.Text) || string.IsNullOrEmpty(metroComboBox4.Text) || string.IsNullOrEmpty(metroComboBox5.Text))
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                        return;
                    }

                    Singleton.Instance.islem.UrunSatinAl(Convert.ToDouble(sepet_odenecektutar_label.Text), x, skykomisyon);
                    //satın alma içinde log eklediğim için ekstra bir fonksiyona gerek yok                  
                    //Singleton.Instance.islem.satis_yapildi(sepet_urunadilabel, sepet_barkodno_label.Text, sepet_urunsaticilabel.Text, Convert.ToInt32(sepet_alinanadet_txt.Text), sepet_odenecektutar_label, x);
                    Singleton.Instance.islem.kargo_islemleri(Singleton.Instance.currentUser.UserName, metroLabel2, metroComboBox4, metroTextBox1, metroComboBox5, rch_adres_txt);
                    bakiye_label.Text = Singleton.Instance.currentUser.Bakiye.ToString();
                    pictureBox5.Image = Properties.Resources.cart;
                    metroComboBox4.Text = null;
                    metroComboBox5.Text = null;
                    rch_adres_txt.Text = null;
                    sepet_satinaldiktan_sonra_sil2();
                    metroLabel2.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("İşlem iptal edildi");
            }
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            try
            {
                sorgu = "SELECT * FROM gonderi_takip WHERE takip_no ='" + textBox2.Text + "'";

                dataGridView1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

                metroSetLabel44.Text = "Sorgu Yapılan Takip Numarası: " + dataGridView1.Rows[0].Cells["takip_no"].Value.ToString();
                // Singleton.Instance.islem.check_if_exist(metroSetLabel44);

                string[] duzenlenecekSutunlar = { "id", "gonderilen_tarih", "teslim_suresi", "UserName", "takip_no", "alici_adres", "teslim_tarihi" };
                Dictionary<string, int> sutunGenisligi = new Dictionary<string, int>()
                {
                { "gonderilen_tarih", 80 }
                };
                Dictionary<string, string> sutunBasliklari = new Dictionary<string, string>()
                {
                { "durum", "Kargo Durumu" },
                { "teslim_tipi", "Teslim Tipi" },
                { "odeme_tipi", "Ödeme Tipi" },
                { "gonderen_mail", "Alıcı Mail" },
                { "gonderilen_tarih", "Gönderim Tarihi" }
                };

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (duzenlenecekSutunlar.Contains(column.Name))
                    {
                        column.Visible = false;
                    }
                    if (sutunGenisligi.ContainsKey(column.Name))
                    {
                        column.Width = sutunGenisligi[column.Name];
                    }
                    if (sutunBasliklari.ContainsKey(column.Name))
                    {
                        column.HeaderText = sutunBasliklari[column.Name];
                    }
                }
            }
            catch (Exception)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                MessageBox.Show("Hatalı Takip Numarası.");

                return;
            }
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            sorgu = "insert into destek (konu,mesaj,gonderen_mail) values ('" + metroSetTextBox7.Text + "','" + metroSetRichTextBox1.Text + "','" + Singleton.Instance.currentUser.Eposta + "')";
            if (string.IsNullOrEmpty(metroSetTextBox7.Text) || string.IsNullOrEmpty(metroSetRichTextBox1.Text))
            {
                MessageBox.Show("Lütfen Alanları Doldurunuz.");

            }
            else
            {
                MessageBox.Show("Destek talebiniz Gönderildi ! 24 Saat içerisinde mailinize Cevap gelicektir.");
            }
            dataGridView1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            //groupBox3.Visible = false;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = ("update Uyeler set UserPassword='" + puserpass_txt.Text + "', telefonno='" + ptelefonno_txt.Text + "', adres='" + padres_txt.Text + "', email='" + p_emailtxt.Text + "' WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
                Singleton.Instance.islem.AccessUpdateIslemleri(sorgu);
                MessageBox.Show("Değişiklikler Kaydedildi.");
                Singleton.Instance.islem.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Değişiklikler Kaydedilemedi.");
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = ("update Uyeler set UyeResim='" + txtResim.Text + "' WHERE UserName='" + Singleton.Instance.currentUser.UserName + "'");
                Singleton.Instance.islem.AccessUpdateIslemleri(sorgu);
                MessageBox.Show("Değişiklikler Kaydedildi.");
                Singleton.Instance.islem.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Değişiklikler Kaydedilemedi.");
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            bunifuPictureBox2.ImageLocation = openFileDialog1.FileName;
            txtResim.Text = String.Format("Pfps/{0}", Path.GetFileName(openFileDialog1.FileName));
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> queryDict = new Dictionary<string, string>()
            {
                {"Tümü", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "'"},
                {"Gıda", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Gıda'"},
                {"Sebze", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Sebze'"},
                {"Meyve", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Meyve'"},
                {"Kişisel Bakım", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Kişisel Bakım'"},
                {"Su ve İçecek", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Su ve İçecek'"},
                {"Atıştırmalık", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Atıştırmalık'"},
                {"Kahvaltılıklar", "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Kahvaltılıklar'"},
            };

            string sorgu;
            if (queryDict.TryGetValue(metroComboBox1.Text, out sorgu))
            {
                bunifuDataGridView2.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            }
        }

        private void textBox1_TextChange(object sender, EventArgs e)
        {
            sorgu = "select * from showUruns where UrunName like '" + textBox1.Text + "%'";
            bunifuDataGridView2.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }

        private void nmsattiklarim_btn_Click_1(object sender, EventArgs e) => listele_comboBox_Kontrol();

        private void add_urun_btn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pusername_label.Text))
                {
                    MessageBox.Show("Lütfen Ürün Eklemek İçin Giriş Yapınız.");
                    return;
                }

                Singleton.Instance.islem.UrunEkle(add_barkodno, urunbirimibox, add_urunfiyati, add_urunmiktari, add_urunname, add_urunturu, Singleton.Instance.currentUser.UserName, guncelle_gb, urunResimtxt);
                listele_comboBox_Kontrol();

                Random rnd = new Random();
                int sayi = rnd.Next(1000, 10000);
                add_barkodno.Text = sayi.ToString();
                urunResimtxt.Text = "";
                add_urunname.Text = "";
                add_urunmiktari.Text = "";
                add_urunfiyati.Text = "";
                add_urunturu.Text = "";
            }
            catch (Exception)
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            girisYapildimi();
        }

        void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cikis_form_kontrol()
        {
            //her ürün için veriyi flush yapabilirdim ancak her item null olmamalı.
            urunadilabel.Text = "-";
            urunbirimilabel.Text = "-";
            fiyat_label.Text = "-";
            urunsaticilabel.Text = "-";
            rch_adres_txt.Text = null;
            sepet_alinanadet_txt.Text = null;
            sepet_urunadilabel.Text = null;
            metroLabel2.Visible = false;
            metroComboBox4.Text = null;
            metroComboBox5.Text = null;
            add_barkodno.Text = null;
            add_urunname.Text = null;
            add_urunmiktari.Text = null;
            add_urunfiyati.Text = null;
            add_urunturu.Text = null;
            urunResimtxt.Text = null;
            metroComboBox1.Text = null;
            metroComboBox2.Text = null;
            textBox1.Text = null;
            urunbirimibox.Text = null;
            urun_adi_txt.Text = null;
            kactl_txt.Text = null;
            kacadet_txt.Text = null;
            g_urunbarkod.Text = null;
            g_urunid.Text = null;
            g_urunname.Text = null;
            g_urunfiyati.Text = null;
            g_urunmiktari.Text = null;
            g_urunturu.Text = null;
            g_urunbirimi.Text = null;
            listeleCombo.Text = null;
            textBox2.Text = null;
            metroSetTextBox7.Text = null;
            metroSetRichTextBox1.Text = null;

            urunler_listbox.Clear();

            bunifuDataGridView4.DataSource = null;
            bunifuDataGridView4.Refresh();
            urun_grid.DataSource = null;
            urun_grid.Refresh();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            pictureBox1.Image = Properties.Resources.shopping_cart;
            pictureBox5.Image = Properties.Resources.cart;
            pictureBox17.Image = Properties.Resources.shopping_bag;
        }
        public void girisYapildimi()
        {
            GirisBekleniyor giris = new GirisBekleniyor();
            DialogResult onay = new DialogResult();
            if (string.IsNullOrEmpty(pusername_label.Text))
            {
                Singleton.Instance.ChangeScreen(this, giris);
            }
            else
            {
                onay = MessageBox.Show("Hesabınızdan çıkış yapmak istiyor musunuz?", "Emin misiniz?", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    //dummy
                    GirisBekleniyor mainForm = new GirisBekleniyor();

                    mainForm.FormClosed += new FormClosedEventHandler(mainForm_FormClosed);
                    //giris form
                    mainForm.Show();

                    this.Hide();

                    Singleton.Instance.islem.Current_user_update_cikis();
                    this.Refresh();
                    cikis_form_kontrol();
                }
                else
                {
                }
            }
        }
        private void metroSetButton4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            urunResimtxt.Text = openFileDialog1.FileName;
            urunResimtxt.Text = String.Format("UrunResimleri/{0}", Path.GetFileName(openFileDialog1.FileName));
        }

        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuDataGridView2.CurrentRow.Selected = true;
            urunadilabel.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells["UrunName"].FormattedValue.ToString();
            fiyat_label.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells["UrunFiyati"].FormattedValue.ToString();
            urunsaticilabel.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells["UrunSatici"].FormattedValue.ToString();
            urunbirimilabel.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells["UrunBirimi"].FormattedValue.ToString();
            pictureBox1.ImageLocation = bunifuDataGridView2.Rows[e.RowIndex].Cells["UrunResimm"].FormattedValue.ToString();
            metroSetLabel43.Text = bunifuDataGridView2.CurrentRow.Cells[9].Value.ToString();
        }

        private void bunifuDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridView3.Rows.Count == 0)
                return;
            try
            {
                bunifuDataGridView3.CurrentRow.Selected = true;
                //sepet_barkodno_label.Text = bunifuDataGridView3.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();
                sepet_urunadilabel.Text = bunifuDataGridView3.Rows[e.RowIndex].Cells["UrunName"].FormattedValue.ToString();
                //sepet_stok_lbl.Text = bunifuDataGridView3.Rows[e.RowIndex].Cells["UrunMiktari"].FormattedValue.ToString();
                //sepet_urunbirimilabel.Text = bunifuDataGridView3.Rows[e.RowIndex].Cells["UrunBirimi"].FormattedValue.ToString();
                pictureBox5.ImageLocation = bunifuDataGridView3.Rows[e.RowIndex].Cells["UrunResimm"].FormattedValue.ToString();

                foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
                {
                    sepet_alinanadet_txt.Text = row.Cells[8].Value.ToString();
                }

                sepet_urunadilabel.Text = bunifuDataGridView3.Rows[e.RowIndex].Cells["UrunName"].FormattedValue.ToString();

                string toplame = "";
                foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
                {
                    string id = row.Cells[2].Value.ToString();

                    int count = bunifuDataGridView3.SelectedRows.Count;
                    if (count > 1)
                    {
                        toplame += id + ", ";
                        metroSetLabel5.Text = "Seçili ürünler:";

                    }
                    else
                    {
                        toplame += id;
                        metroSetLabel5.Text = "Seçili ürün adi:";
                    }
                }


                sepet_urunadilabel.Text = toplame;
            }
            catch (Exception)
            {

            }

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<Tuple<string, string>, string> kategoriListe = new Dictionary<Tuple<string, string>, string>
            {
                { Tuple.Create("Tümü", "Azalan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati DESC" },
                { Tuple.Create("Tümü", "Artan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' ORDER BY UrunFiyati ASC" },
                { Tuple.Create("Gıda", "Azalan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Gıda' ORDER BY UrunFiyati DESC" },
                { Tuple.Create("Gıda", "Artan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Gıda' ORDER BY UrunFiyati ASC" },
                { Tuple.Create("Temizlik", "Azalan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Temizlik' ORDER BY UrunFiyati DESC" },
                { Tuple.Create("Temizlik", "Artan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Temizlik' ORDER BY UrunFiyati ASC" },
                { Tuple.Create("Su ve İçecek", "Azalan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Su ve İçecek' ORDER BY UrunFiyati DESC" },
                { Tuple.Create("Su ve İçecek", "Artan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Su ve İçecek' ORDER BY UrunFiyati ASC" },
                { Tuple.Create("Atıştırmalık", "Azalan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Atıştırmalık' ORDER BY UrunFiyati DESC" },
                { Tuple.Create("Atıştırmalık", "Artan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Atıştırmalık' ORDER BY UrunFiyati ASC" },
                { Tuple.Create("Kahvaltılıklar", "Azalan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Kahvaltılıklar' ORDER BY UrunFiyati DESC" },
                { Tuple.Create("Kahvaltılıklar", "Artan"), "SELECT * FROM showUruns WHERE urunOnay='Onaylandı' AND UrunMiktari>0 AND NOT UrunSatici='" + Singleton.Instance.currentUser.UserName + "' AND UrunTuru='Kahvaltılıklar' ORDER BY UrunFiyati ASC" },
            };

            Tuple<string, string> key = Tuple.Create(metroComboBox1.Text, metroComboBox2.Text);

            if (kategoriListe.ContainsKey(key))
            {
                sorgu = kategoriListe[key];
                bunifuDataGridView2.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            try
            {
                double toplamtutar = Convert.ToDouble(kacadet_txt.Text) * Convert.ToDouble(kactl_txt.Text);
                double skykomisyon = toplamtutar / 100;
                double gereklibakiye = toplamtutar + skykomisyon;
                if (gereklibakiye <= Singleton.Instance.currentUser.Bakiye)
                {
                    Singleton.Instance.islem.siparis_kontrol(urun_adi_txt.Text, kacadet_txt.Text, kactl_txt.Text, Convert.ToInt32(kacadet_txt.Text));
                    sepet_sorgu_refresh();
                    sepet_guncel_tutare();
                }
                else
                    MessageBox.Show("Maalesef İşlem için Bakineyiz yetersizdir..");
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen doğru formatta giriş yapınız.");
            }
            urun_adi_txt.Text = "";
            kactl_txt.Text = "";
            kacadet_txt.Text = "";
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Singleton.Instance.listeleSiparisler.SiparislerimListeleOnLoad();
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.listeleSiparisler);
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            Singleton.Instance.gecmisSiparisler.SiparislerimOnLoad();
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.gecmisSiparisler);
        }

        private void OtosatinalPageLoad()
        {
            ListBoxDoldur();
            ListBoxControlEt();
        }

        public void ListBoxDoldur() => Singleton.Instance.islem.ListBoxDoldur(urunler_listbox);
        public void ListBoxControlEt()
        {
            var itemSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            for (int i = urunler_listbox.Items.Count - 1; i >= 0; i--)
            {
                var item = urunler_listbox.Items[i].ToString();
                if (itemSet.Contains(item))
                {
                    urunler_listbox.Items.RemoveAt(i);
                }
                else
                {
                    itemSet.Add(item);
                }
            }
        }

        private void metroSetButton2_Click(object sender, EventArgs e) => OtosatinalPageLoad();

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(profilad_label.Text))
            {
                MessageBox.Show("Lütfen satın almaya devam etmeden önce giriş yapınız.");
                return;
            }

            if (SayiMi(kacadetalmak_txt.Text))
            {
                //if (metroSetLabel32.Text == "deneme")
                //{
                //    MessageBox.Show("Lütfen ürünü seçiniz");
                //    return;
                //}

                double toplampara = Singleton.Instance.islem.GetToplamPara(metroSetLabel32.Text, Convert.ToInt32(kacadetalmak_txt.Text));
                double skykomisyon = toplampara / 100;
                double gereklibakiye = toplampara + skykomisyon;
                double toplamadet = Singleton.Instance.islem.GetUrunToplamAdet(metroSetLabel9.Text);
                if (Convert.ToInt32(kacadetalmak_txt.Text) > toplamadet)
                {
                    MessageBox.Show("Stok yetersiz, alabileceginiz maksimum miktar: " + toplamadet + " idir.");
                }
                else if (Singleton.Instance.currentUser.Bakiye < gereklibakiye)
                {
                    MessageBox.Show("Bu üründen " + kacadetalmak_txt.Text + " tane almak için maalesef bakiyeniz yetersiz.", "Bakiye Hatasi");
                }
                else if (Singleton.Instance.currentUser.Bakiye >= gereklibakiye)
                {
                    var barkodno_label = bunifuDataGridView4.CurrentRow.Cells["urunBarkodNo"].Value.ToString();
                    int result = Singleton.Instance.islem.VarMi(barkodno_label);

                    if (result > 0)
                    {
                        MessageBox.Show("Ürün zaten sepette ekli.");
                        return;
                    }
                    else
                    {
                        Singleton.Instance.islem.Buybox_Sepete_Ekle(metroSetLabel32.Text, Convert.ToInt32(kacadetalmak_txt.Text));
                        sepet_sorgu_refresh();
                        sepet_guncel_tutare();
                    }
                }
            }
            else if (kacadetalmak_txt.Text == "")
                MessageBox.Show("Lütfen kaç adet almak istediğinizi giriniz.", "Tüm alanları doldurun");
            else
            {
                MessageBox.Show("Yanlış değer girdiniz.", "Hata!");
            }
        }

        private void urunler_listbox_SelectedIndexChanged(object sender)
        {
            kacadetalmak_txt.Text = "";
            sorgu = "SELECT * FROM Uruns WHERE UrunTuru='" + urunler_listbox.SelectedItem.ToString() + "'  AND UrunMiktari>0";
            bunifuDataGridView4.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            string[] columnsToHide = { "UrunResimm", "urunOnay", "UrunID", "UrunMiktari", "urunBarkodNo" };
            string[] columnsToRename = { "UrunName", "UrunFiyati", "UrunTuru", "UrunSatici", "urunBirimi" };
            string[] renamedValues = { "Ürün İsmi", "Ürün Fiyatı(TL)", "Kategori", "Satıcı", "Birim" };

            int i = 0;
            foreach (string column in columnsToHide)
            {
                bunifuDataGridView4.Columns[column].Visible = false;
            }

            foreach (string column in columnsToRename)
            {
                bunifuDataGridView4.Columns[column].HeaderText = renamedValues[i];
                i++;
            }

            bunifuDataGridView4.Columns["UrunName"].Width = 150;
        }

        private string GetHeaderText(string columnName)
        {
            switch (columnName)
            {
                case "UrunName":
                    return "Ürün İsmi";
                case "UrunFiyati":
                    return "Ürün Fiyatı(TL)";
                case "UrunTuru":
                    return "Kategori";
                case "UrunSatici":
                    return "Satıcı";
                case "urunBirimi":
                    return "Birim";
                default:
                    return columnName;
            }
        }
        private void bunifuDataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewColumn col in bunifuDataGridView4.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = bunifuDataGridView4.Rows[e.RowIndex];
                    metroSetLabel32.Text = selectedRow.Cells["UrunName"].Value.ToString();
                    pictureBox17.ImageLocation = selectedRow.Cells["UrunResimm"].FormattedValue.ToString();
                    barkodKontrol_2.Text = selectedRow.Cells[8].Value.ToString();
                    metroSetLabel9.Text = selectedRow.Cells[1].Value.ToString();
                    metroSetLabel43.Text = selectedRow.Cells[9].Value.ToString();

                    selectedRow.Selected = true;
                }
            }
            catch (Exception)
            {
            }
        }


        private void bunifuDataGridView4_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
        }

        private void bunifuDataGridView4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex == 0)
            {
                e.Handled = true;
            }
        }

        private void bunifuCheckBox1_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
        }

        private void metroSetNumeric1_Click(object sender, EventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
            {
                row.Cells["urun_adet"].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells["urun_adet"].Value));
                sepet_alinanadet_txt.Text = row.Cells[8].Value.ToString();
            }

            if (bunifuDataGridView3.SelectedRows.Count > 0)
            {
                var sepet_stok_lbl = bunifuDataGridView3.CurrentRow.Cells["UrunMiktari"].Value.ToString();
                int istenenadet = Convert.ToInt32(sepet_alinanadet_txt.Text);
                int stokadet = Convert.ToInt32(sepet_stok_lbl);
                if (SayiMi(sepet_alinanadet_txt.Text))
                {
                    if (istenenadet <= stokadet)
                    {
                        satinal_btn.Visible = true;

                        double iTotal = 0;
                        for (int index = 0; index <= bunifuDataGridView3.RowCount - 1; index++)
                        {
                            iTotal += Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[3].Value) * Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[8].Value);
                        }
                        sepet_odenecektutar_label.Text = iTotal.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Stokta bu kadar yok. Alım adetini düşürebilirsiniz.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen adet kısmına miktar giriniz");
                }
            }
        }

        private void metroButton1_MouseClick(object sender, MouseEventArgs e)
        {
            var barkod_No = bunifuDataGridView3.CurrentRow.Cells["urunBarkodNo"].Value.ToString();
            Singleton.Instance.islem.urun_adet_guncelle(Convert.ToInt32(sepet_alinanadet_txt.Text), barkod_No);
            bunifuDataGridView3.Update();
            bunifuDataGridView3.Refresh();
            this.bunifuDataGridView3.RefreshEdit();
        }

        private void bunifuThinButton28_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
                {
                    row.Cells["urun_adet"].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells["urun_adet"].Value));
                    sepet_alinanadet_txt.Text = row.Cells[8].Value.ToString();
                }

                var barkod_No = bunifuDataGridView3.CurrentRow.Cells["urunBarkodNo"].Value.ToString();
                Singleton.Instance.islem.urun_adet_guncelle(Convert.ToInt32(sepet_alinanadet_txt.Text), barkod_No);

                if (bunifuDataGridView3.SelectedRows.Count > 0)
                {
                    var sepet_stok_lbl = bunifuDataGridView3.CurrentRow.Cells["UrunMiktari"].Value.ToString();
                    int istenenadet = Convert.ToInt32(sepet_alinanadet_txt.Text);
                    int stokadet = Convert.ToInt32(sepet_stok_lbl);
                    if (SayiMi(sepet_alinanadet_txt.Text))
                    {
                        if (istenenadet <= stokadet)
                        {
                            satinal_btn.Visible = true;

                            double sepet_artan_tutar = 0;
                            for (int index = 0; index <= bunifuDataGridView3.RowCount - 1; index++)
                            {
                                sepet_artan_tutar += Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[3].Value) * Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[8].Value);
                            }

                            if (bunifuDataGridView3.Rows.Count == 0)
                            {
                                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
                            }
                            else if (sepet_artan_tutar <= 40)
                            {
                                bunifuTextBox1.Text = "Kargo Ücreti: 10 TL";
                                sepet_artan_tutar += 10;
                            }
                            else
                            {
                                bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
                            }

                            sepet_odenecektutar_label.Text = sepet_artan_tutar.ToString();
                        }
                        else
                        {
                            foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
                            {
                                row.Cells["urun_adet"].Value = Convert.ToString(Convert.ToInt32(row.Cells["urun_adet"].Value) - 1);
                                sepet_alinanadet_txt.Text = row.Cells[8].Value.ToString();
                            }
                            MessageBox.Show("Stokta bu kadar yok. Alim adetini dusurebilirsin.");

                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Luftfen adet kismina miktar giriniz");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lütfen ürün seçiniz.");
            }
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in bunifuDataGridView3.SelectedRows)
                {
                    row.Cells["urun_adet"].Value = Convert.ToString(Convert.ToInt32(row.Cells["urun_adet"].Value) - 1);

                    sepet_alinanadet_txt.Text = row.Cells[8].Value.ToString();

                    if (Convert.ToInt32(sepet_alinanadet_txt.Text) <= 0)
                    {
                        sepet_satinaldiktan_sonra_sil();
                        pictureBox5.Image = Properties.Resources.cart;
                        bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
                        return;
                    }
                }

                double sepet_eksi_tutar = 0;
                for (int index = 0; index <= bunifuDataGridView3.RowCount - 1; index++)
                {
                    sepet_eksi_tutar += Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[3].Value) * Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[8].Value);
                }

                var barkod_No = bunifuDataGridView3.CurrentRow.Cells["urunBarkodNo"].Value.ToString();
                Singleton.Instance.islem.urun_adet_guncelle(Convert.ToInt32(sepet_alinanadet_txt.Text), barkod_No);

                if (bunifuDataGridView3.Rows.Count == 0 || string.IsNullOrEmpty(bunifuDataGridView3.Rows[0].Cells[0].Value.ToString()))
                {
                    bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
                }
                else if (sepet_eksi_tutar <= 40)
                {
                    bunifuTextBox1.Text = "Kargo Ücreti: 10 TL";
                    sepet_eksi_tutar += 10;
                }
                else
                {
                    bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
                }
                sepet_odenecektutar_label.Text = sepet_eksi_tutar.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen ürün seçiniz.");
            }

        }
        private void kategori_kontrol(MetroSetComboBox kategori)
        {
            List<string> items = kategori.Items.Cast<string>().ToList();
            items = items.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            kategori.Items.Clear();
            foreach (var item in items)
            {
                kategori.Items.Add(item);
            }
        }
        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (materialTabControl1.SelectedIndex == 4)
                {
                    Random rnd = new Random();
                    int sayi = rnd.Next(1000, 10000);
                    add_barkodno.Text = sayi.ToString();
                    Singleton.Instance.islem.Kategori_Listele(add_urunturu);
                    kategori_kontrol(add_urunturu);

                }
                if (materialTabControl1.SelectedIndex == 2)
                {
                    bunifuDataGridView3.Rows[0].Cells[0].Selected = true;
                    if (bunifuDataGridView3.Rows[0].Cells[0].Value == null)
                    {
                        sepet_odenecektutar_label.Text = "0";
                        bunifuTextBox1.Text = "0";
                    }

                    if (Convert.ToDouble(sepet_odenecektutar_label.Text) == 0)
                    {
                        double total = 0;
                        for (int index = 0; index <= bunifuDataGridView3.RowCount - 1; index++)
                        {
                            total += Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[3].Value) * Convert.ToDouble(bunifuDataGridView3.Rows[index].Cells[8].Value);
                        }

                        if (total <= 40)
                        {
                            bunifuTextBox1.Text = "Kargo Ücreti: 10 TL";
                            total += 10;
                        }
                        else
                        {
                            bunifuTextBox1.Text = "Kargo Ücreti: 0 TL";
                        }

                        sepet_odenecektutar_label.Text = total.ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            this.Hide();
            odeme.Show();
        }
        private void urun_guncelle_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_urunbarkod.Text) || string.IsNullOrEmpty(g_urunid.Text) || string.IsNullOrEmpty(g_urunname.Text) || string.IsNullOrEmpty(g_urunmiktari.Text) || string.IsNullOrEmpty(g_urunbirimi.Text) || string.IsNullOrEmpty(g_urunfiyati.Text) || string.IsNullOrEmpty(g_urunturu.Text))
            {
                MessageBox.Show("Lütfen Ürün seçiniz");

            }
            else
            {
                if (SayiMi(g_urunfiyati.Text) && SayiMi(g_urunmiktari.Text))
                {

                    if (Convert.ToInt32(g_urunfiyati.Text) <= 0 || Convert.ToInt32(g_urunmiktari.Text) <= 0)
                    {
                        MessageBox.Show("Lütfen 0 dan farklı pozitif sayılar giriniz.", "Hatalı urun güncellemesi");
                    }
                    else
                    {

                        Singleton.Instance.islem.UrunUpdate(g_urunfiyati, g_urunmiktari, g_urunbarkod.Text, guncelle_gb);
                        MessageBox.Show("Urun guncellendi admin onayı bekleniyor", "Urun güncelleme Başarılı");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Geçerli Bir deger girin");
                }
                listele_comboBox_Kontrol();
            }
        }

        private void urun_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (urun_grid.Rows.Count == 0)
                return;
            try
            {
                urun_grid.CurrentRow.Selected = true;
                g_urunid.Text = urun_grid.Rows[e.RowIndex].Cells["UrunID"].FormattedValue.ToString();
                g_urunname.Text = urun_grid.Rows[e.RowIndex].Cells["UrunName"].FormattedValue.ToString();
                g_urunmiktari.Text = urun_grid.Rows[e.RowIndex].Cells["UrunMiktari"].FormattedValue.ToString();
                g_urunbirimi.Text = urun_grid.Rows[e.RowIndex].Cells["urunBirimi"].FormattedValue.ToString();
                g_urunfiyati.Text = urun_grid.Rows[e.RowIndex].Cells["UrunFiyati"].FormattedValue.ToString();
                g_urunturu.Text = urun_grid.Rows[e.RowIndex].Cells["UrunTuru"].FormattedValue.ToString();
                g_urunbarkod.Text = urun_grid.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();

            }
            catch (Exception)
            {
            }
        }
    }
}
