using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8.Formlar
{
    public partial class SiparislerimiListele : MaterialForm
    {
        public SiparislerimiListele()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue700, Primary.BlueGrey500, Accent.Blue700, TextShade.WHITE);

        }

        private void SiparislerimiListele_Load(object sender, EventArgs e)
        {
            SiparislerimListeleOnLoad();
          
        }

        public void SiparislerimListeleOnLoad()
        {
            try
            {
                Siparislistele_datagird.DataSource = null;
               // Singleton.Instance.main.DataGrid_1(Siparislistele_datagird);

                Siparislistele_datagird.RowHeadersVisible = false; //Gizlenmesini sağlar

            }
            catch
            {
            }
 
        }


        private void SiparislerimiListele_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.form1);

        }

        private void aktifsip_listele_Click_1(object sender, EventArgs e)
        {
            string sorgu = "select * from gonderi_takip Where UserName='" + Singleton.Instance.currentUser.UserName + "'";
            Siparislistele_datagird.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            string[] siparisListele = { "ID", "İsim", "Takip No", "Teslimat Durumu", "Teslimat Tipi", "Teslim Tarihi", "Alım Tarihi", "Ödeme Tipi", "Teslimat Süresi", "Alıcı Adresi", "Gönderenin Email Adresi" };
            for (int i = 0; i < siparisListele.Length; i++)
            {
                Siparislistele_datagird.Columns[i].HeaderText = siparisListele[i];
            }
        }

        private void tamamsip_listele_Click_1(object sender, EventArgs e)
        {
            string sorgu = "select * from Satislar Where SatinAlan='" + Singleton.Instance.currentUser.UserName + "'";
            Siparislistele_datagird.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            
            string[] siparisListele = { "Satış Numarası", "Satış Tarihi", "Ürün Adı", "Satış Fiyatı", "Satış Miktarı", "Ürün Birimi", "Satışı Yapan", "Satın Alan" };
            for (int i = 0; i < siparisListele.Length; i++)
            {
                Siparislistele_datagird.Columns[i].HeaderText = siparisListele[i];
            }
        }

    }
}
