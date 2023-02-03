using MetroFramework.Controls;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp8.Formlar
{
    public partial class AdminleriListele : Form
    {
        private String sorgu = "";
        public AdminleriListele()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\alisveris.mdb");
        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                bunifuDataGridView1.FirstDisplayedScrollingRowIndex = bunifuDataGridView1.Rows[e.Value].Index;
            }
            catch (Exception)
            {
            }
        }

        private void bunifuDataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = bunifuDataGridView1.RowCount - 1;
            }
            catch (Exception)
            {
            }
        }

        private void bunifuDataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = bunifuDataGridView1.RowCount - 1;
            }
            catch (Exception)
            {
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuDataGridView1.CurrentRow.Selected = true;
            try
            {
                id_txt.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells["adminId"].FormattedValue.ToString();
                ad_txt.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells["adminName"].FormattedValue.ToString();
                sifre_txt.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells["adminPassword"].FormattedValue.ToString();

            }
            catch (Exception)
            {
            }
        }
        private void sil_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id_txt.Text) || string.IsNullOrEmpty(ad_txt.Text) || string.IsNullOrEmpty(sifre_txt.Text))
            {
                MessageBox.Show("Lütfen kayıt seçiniz.");

            }
            else
            {
                string sorgu = "Delete from Admins Where adminId=@adminId";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@adminId",
                bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
                baglan.Open();
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Silindi.");
                listele();

            }
        }
        void listele()
        {
            baglan.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from Admins", baglan);
            DataSet ds = new DataSet();
            da.Fill(ds, "Admins");
            bunifuDataGridView1.DataSource = ds.Tables["Admins"];
            baglan.Close();
            id_txt.Text = "";
            ad_txt.Text = "";
            sifre_txt.Text = "";
        }
        private void adminsListele()
        {
            sorgu = "SELECT * FROM Admins";
            bunifuDataGridView1.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            string[] admins = { "ID No", "Admin Kullanıcı Adı", "Admin Kullanıcı Şifresi" };
            for (int i = 0; i < admins.Length; i++)
            {
                bunifuDataGridView1.Columns[i].HeaderText = admins[i];
            }
        }

        private void AdminleriListele_Load(object sender, EventArgs e)
        {
            adminsListele();
            bunifuDataGridView1.RowHeadersVisible = false;
        }

        private void ekle_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                string sorgu = "Insert into Admins (adminName,adminPassword) values" +
                 " (@adminName,@adminPassword)";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@adminName", textBox2.Text);
                komut.Parameters.AddWithValue("@adminPassword", textBox1.Text);
                baglan.Open();
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Admin Başarıyla EKlendi");
                adminsListele();

            }
        }
        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}