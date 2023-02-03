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

namespace WindowsFormsApp8.Formlar
{
    public partial class UyeleriListele : Form
    {
        private string sorgu = "";
        public UyeleriListele()
        {
            InitializeComponent();
        }

        private void UyeleriListele_Load(object sender, EventArgs e)
        {
         
            UyelerOnLoad();
            
        }

        public void UyelerOnLoad()
        {
            datagrid_settings();
            UyecomboBox();
            ClearTxts();
            
        }

        public void datagrid_settings()
        {
           // Kullanicilar_datagridview.ColumnHeadersVisible = false;
            Kullanicilar_datagridview.RowHeadersVisible = false;
            Kullanicilar_datagridview.ReadOnly = true;
 
        }
        private void UyecomboBox()
        {
            sorgu = "SELECT * FROM Uyeler";
            Kullanicilar_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            Kullanicilar_datagridview.Columns[0].HeaderText = "Ad";
            Kullanicilar_datagridview.Columns[1].HeaderText = "Soyad";
            Kullanicilar_datagridview.Columns[2].HeaderText = "TC Kimlik No";
            Kullanicilar_datagridview.Columns[3].HeaderText = "Telefon No";
            Kullanicilar_datagridview.Columns[4].HeaderText = "Hesap Bakiyesi";
            Kullanicilar_datagridview.Columns[5].HeaderText = "Geçici Bakiyesi";
            Kullanicilar_datagridview.Columns[6].HeaderText = "Para Birimi";
            Kullanicilar_datagridview.Columns[7].HeaderText = "Kullanıcı Adı";
            Kullanicilar_datagridview.Columns[8].HeaderText = "Kullanıcı Şifresi";
            Kullanicilar_datagridview.Columns[9].HeaderText = "Adresi";
            Kullanicilar_datagridview.Columns[10].HeaderText = "Email Adresi";
            Kullanicilar_datagridview.Columns[11].HeaderText = "Son Para Yükleme Tarihi";
            Kullanicilar_datagridview.Columns[12].HeaderText = "ID No";
            Kullanicilar_datagridview.Columns["UyeResim"].Visible = false;

        }

        public void ClearTxts()
        {
            bakiye_txt.Text = "";
            pasifbakiye_txt.Text = "";
            username_txt.Text = "";
            doviz_txt.Text = "";
        }

        private void Kullanicilar_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Kullanicilar_datagridview.CurrentRow.Selected = true;
            try
            {
                username_txt.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                bakiye_txt.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["hesapBakiye"].FormattedValue.ToString();
                pasifbakiye_txt.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["geciciBakiye"].FormattedValue.ToString();
                doviz_txt.Text = Kullanicilar_datagridview.Rows[e.RowIndex].Cells["parabirimi"].FormattedValue.ToString();
            }
            catch (Exception)
            {

               
            }
            
        }
    }
}
