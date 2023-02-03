using Bunifu.UI.WinForms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp8.Formlar
{
    public partial class KullaniciKontrol : Form
    {
        private string sorgu = "";
        public KullaniciKontrol()
        {
            InitializeComponent();
        }

        private void KullaniciKontrol_Load(object sender, EventArgs e)
        {
            kulkontrolLoad();          
            Kullanicilar_datagridview.RowHeadersVisible = false;
            Kullanicilar_datagridview.Columns["UyeResim"].Visible = false;
        }

        private void UyecomboBox()
        {
            secenekler_combobox.Items.Clear();
            secenekler_combobox.Text = "Tüm Uyeler";
            secenekler_combobox.Items.Add("Tüm Uyeler");
            secenekler_combobox.Items.Add("Islem Bekleyenler");

            sorgu = "SELECT * FROM Uyeler";
            Kullanicilar_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            string[] kullanicilar = { "Ad", "Soyad", "TC Kimlik No", "Telefon No", "Hesap Bakiyesi", "Geçici Bakiyesi", "Para Birimi", "Kullanıcı Adı", "Kullanıcı Şifresi", "Adresi", "Email Adresi", "Son Para Yükleme Tarihi", "ID No" };
            for (int i = 0; i < kullanicilar.Length; i++)
            {
                Kullanicilar_datagridview.Columns[i].HeaderText = kullanicilar[i];
            }
        }

        public void kulkontrolLoad()
        {
            UyecomboBox();
            ClearTxts();
        }
        private void onayla_btn_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(pasifbakiye.Text) > 0 && doviz.Text == "TL")
            {
                DialogResult dialogResult = MessageBox.Show("Bakiyeyi Onaylamak istediğinize eminmisiniz ?", "Bakiye Onaylansın mı ?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    double bakiye = Convert.ToDouble(this.bakiye.Text);
                    double artismiktari = Convert.ToDouble(pasifbakiye.Text);
                    bakiye += artismiktari;
                    Singleton.Instance.islem.BakiyeOnay(username.Text, bakiye);
                    MessageBox.Show("Bakiye onaylama işlemi tamamlandı.", "Bakiye Onay");
                    secenekler_combobox.Text = "Tüm Üyeler";
                    Listele();
                }
            }
            else if (doviz.Text != "TL")
            {
                MessageBox.Show("Onay oncesi dovizi TL birimine cevirmelisiniz.", "Hata Kodu: 1");
            }
        }

        private void donustur_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (doviz.Text != "TL")
                {
                    string link = "https://www.tcmb.gov.tr/kurlar/today.xml";
                    var xml = new XmlDocument();
                    xml.Load(link);
                    DateTime tarih = Convert.ToDateTime(xml.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
                    string conversionRate = xml.SelectSingleNode("Tarih_Date/Currency [@Kod='" + doviz.Text + "']/BanknoteSelling").InnerXml;

                    double onayBekleyenHesapBakiyesi = Convert.ToDouble(pasifbakiye.Text);
                    double virgullubakiye = onayBekleyenHesapBakiyesi * Convert.ToDouble(conversionRate.Replace(".", ","));
                    double newBekleyenBakiye = Math.Round(virgullubakiye, 1);

                    Singleton.Instance.islem.GeciciBakiyeDegistirWithUsername(username.Text, newBekleyenBakiye);
                    MessageBox.Show(tarih.ToShortDateString() + " Tarihindeki kur bilgilerine göre paranız  donusturuldu .\n\n" + onayBekleyenHesapBakiyesi.ToString() + " " + doviz.Text + " --> " + newBekleyenBakiye.ToString() + " TL .");
                    kulkontrolLoad();
                }
                else
                {
                    MessageBox.Show("Para Biriminiz Zaten TL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata kod: " + ex.ToString());
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            ClearTxts();

            baslik_label.Text = secenekler_combobox.Text;
            if (secenekler_combobox.Text == "Islem Bekleyenler")
                sorgu = "SELECT * FROM PasifBakiyeler";
            if (secenekler_combobox.Text == "Tüm Uyeler" || secenekler_combobox.Text == "")
                sorgu = "SELECT * FROM Uyeler";
            Kullanicilar_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
        }

        public void ClearTxts()
        {
            bakiye.Text = "";
            pasifbakiye.Text = "";
            username.Text = "";
            doviz.Text = "";
            ParaBirimiVisibleControl(false);
        }

        private void ParaBirimiVisibleControl(bool deger)
        {
            if (deger)
            {
                parabirimibaslik.Visible = true;
                doviz.Visible = true;
                donustur_btn.Visible = true;
            }
            else
            {
                parabirimibaslik.Visible = false;
                doviz.Visible = false;
                donustur_btn.Visible = false;
            }
        }

        private void Kullanicilar_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                Kullanicilar_datagridview.FirstDisplayedScrollingRowIndex = Kullanicilar_datagridview.Rows[e.Value].Index;
            }
            catch (Exception)
            {
            }
        }

        private void Kullanicilar_datagridview_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = Kullanicilar_datagridview.RowCount - 1;
            }
            catch (Exception)
            {
            }
        }

        private void Kullanicilar_datagridview_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = Kullanicilar_datagridview.RowCount - 1;
            }
            catch (Exception)
            {
            }
        }

        private void Kullanicilar_datagridview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Kullanicilar_datagridview.CurrentRow.Selected = true;
            try
            {
                username.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                bakiye.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["hesapBakiye"].FormattedValue.ToString();
                pasifbakiye.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["geciciBakiye"].FormattedValue.ToString();
                doviz.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["parabirimi"].FormattedValue.ToString();
            }
            catch (Exception)
            {              
            }

            if (pasifbakiye.Text != "")
            {
                if (Convert.ToDouble(pasifbakiye.Text) > 0)
                {
                    ParaBirimiVisibleControl(true);
                    onayla_btn.Visible = true;
                }
                else
                {
                    ParaBirimiVisibleControl(false);
                    onayla_btn.Visible = false;
                }
            }
        }
    }
}
