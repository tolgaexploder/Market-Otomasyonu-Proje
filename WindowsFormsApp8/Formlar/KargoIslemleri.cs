using Bunifu.Framework.UI;
using MetroFramework.Controls;
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
    public partial class KargoIslemleri : Form
    {
        public KargoIslemleri()
        {
            InitializeComponent();
        }
        private string sorgu = "";
        private void KargoIslemleri_Load(object sender, EventArgs e)
        {
            data_grid_ayarlari();
            visibleGroupbox();         
        }

        public void UyelerOnLoad()
        {
            UyecomboBox();
            visibleGroupbox();
        }
        private void UyecomboBox()
        {
            sorgu = "SELECT * FROM Uyeler";
            datagridview1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            string[] uyecolumn = { "Ad", "Soyad", "TC Kimlik No", "Telefon No", "Hesap Bakiyesi", "Geçici Bakiyesi", "Para Birimi", "Kullanıcı Adı", "Kullanıcı Şifresi", "Adresi", "Email Adresi", "Son Para Yükleme Tarihi", "ID No" };
            for (int i = 0; i < uyecolumn.Length; i++)
            {
                datagridview1.Columns[i].HeaderText = uyecolumn[i];
            }

        }
        public void visibleGroupbox()
        {
            bunifuCards1.Enabled = false;
            bunifuCards2.Enabled = false;
        }

        int i = 0;
        private void metroTile1_Click(object sender, EventArgs e)
        {
            bunifuCards1.Enabled = true;
            bunifuCards2.Enabled = false;
            
            sorgu = "SELECT * FROM destek";
            datagridview1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            datagridview1.Columns[0].Visible = false;
            try
            {
                metroTextBox1.Text = datagridview1.Rows[i].Cells[1].Value.ToString();
                metroSetRichTextBox1.Text = datagridview1.Rows[i].Cells[2].Value.ToString();
            }
            catch (Exception)
            {            
            }
           
            datagridview1.Columns[2].Width = 100;
            string[] sutuns = { "Talep Numarası", "Konu", "Mesaj", "Gönderenin Email Adresi" };
            for (int i = 0; i < sutuns.Length; i++)
            {
                datagridview1.Columns[i].HeaderText = sutuns[i];
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
            metroSetRichTextBox1.Clear();
            metroComboBox1.Items.Clear();
            bunifuCards1.Enabled = false;
            bunifuCards2.Enabled = true;

            sorgu = "SELECT takip_no,durum FROM gonderi_takip";
            datagridview1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            Singleton.Instance.islem.buton3(metroComboBox1);
            
            string[] sutuns2 = { "Takip Numarası", "Kargo Durumu" };
            for (int i = 0; i < sutuns2.Length; i++)
            {
                datagridview1.Columns[i].HeaderText = sutuns2[i];
            }
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
            metroSetRichTextBox1.Clear();
            bunifuCards1.Enabled = false;
            bunifuCards2.Enabled = false;

            //OleDbConnection baglanti = GetBaglanti();
            //baglanti.Open();
            //DataTable dt = new DataTable();
            sorgu = ("SELECT takip_no FROM gonderi_takip");
            datagridview1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            datagridview1.Columns[0].HeaderText = "Takip Numarası";      
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroComboBox1.Text) || string.IsNullOrEmpty(metroComboBox2.Text))
            {
                MessageBox.Show("Lütfen seçimleri doğru şekilde yapınız");
            }
            else
            {
                Singleton.Instance.islem.kargo_durum_guncelle(metroComboBox2, metroComboBox1);
                Singleton.Instance.islem.buton3(metroComboBox1);

                sorgu = "SELECT takip_no,durum FROM gonderi_takip";
                datagridview1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);
            }
        }   
        private void data_grid_ayarlari()
        {
            datagridview1.RowHeadersVisible = false;
            //datagridview1.ColumnHeadersVisible = false;
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
            metroSetRichTextBox1.Clear();
            UyelerOnLoad();
            bunifuCards1.Enabled = false;
            bunifuCards2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (i < datagridview1.RowCount - 1)
            {
                metroTextBox1.Text = datagridview1.Rows[i + 1].Cells[1].Value.ToString();
                metroSetRichTextBox1.Text = datagridview1.Rows[i + 1].Cells[2].Value.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                if (i == 0)
                {
                    metroTextBox1.Text = datagridview1.Rows[i].Cells[1].Value.ToString();
                    metroSetRichTextBox1.Text = datagridview1.Rows[i].Cells[2].Value.ToString();
                }
                else
                {
                    metroTextBox1.Text = datagridview1.Rows[i - 1].Cells[1].Value.ToString();
                    metroSetRichTextBox1.Text = datagridview1.Rows[i - 1].Cells[2].Value.ToString();
                }
            }
        }

        private void datagridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                datagridview1.CurrentRow.Selected = true;
                metroTextBox1.Text = datagridview1.Rows[e.RowIndex].Cells["konu"].FormattedValue.ToString();
                metroSetRichTextBox1.Text = datagridview1.Rows[e.RowIndex].Cells["mesaj"].FormattedValue.ToString();
            }
            catch (Exception)
            {
                
            }                  
        }
    }
}
