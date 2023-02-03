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

namespace WindowsFormsApp8.Formlar
{
    public partial class UrunKontrol : Form
    {
        private string sorgu = "";
        public UrunKontrol()
        {
            InitializeComponent();
        }

        private void UrunKontrol_Load(object sender, EventArgs e)
        {
            UrunlerComboBox();
            Urunler_datagridview.RowHeadersVisible = false;
            //Urunler_datagridview.ColumnHeadersVisible = false;
            Urunler_datagridview.Columns["UrunResimm"].Visible = false;

        }
        private void urunonayla_btn_Click(object sender, EventArgs e)
        {
            if (onaycontrol_label.Text == "Onaylanmadı")
            {
                DialogResult dialogResult = MessageBox.Show("Urun Onaylamak istediğinize eminmisiniz ?", "Urun Onaylansın mı ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Singleton.Instance.islem.UrunOnay(urunkodu_txt.Text);
                    UrunListele();
                    MessageBox.Show("Urun onaylama işlemi tamamlandı.", "Kullanıcı Onay");
                }
                else if (dialogResult == DialogResult.No) MessageBox.Show("Urun onaylama işlemi tamamlandı.", "Kullanıcı Onay");
            }
            else if (onaycontrol_label.Text == "Onaylandı") MessageBox.Show("Seçtiğiniz kullanıcı zaten onaylanmış.", "****");
            else MessageBox.Show("Lütfen bir ürün  seçiniz.", "****");
        }

        private void urunlerlistele_btn_Click(object sender, EventArgs e)
        {
            UrunListele();
        }

        private void UrunListele()
        {
            urunkodu_txt.Text = "";
            onaycontrol_label.Text = "";

            urunbaslik_label.Text = urunler_combobox.Text;
            if (urunler_combobox.Text == "Tüm Ürünler")
                sorgu = "SELECT * FROM showUruns";
            if (urunler_combobox.Text == "Onaylanan Ürünler")
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylandı" + "'";
            if (urunler_combobox.Text == "Onay Bekleyen Ürünler")
                sorgu = "SELECT * FROM showUruns WHERE urunOnay='" + "Onaylanmadı" + "'";
            Urunler_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

        }

        private void Urunler_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Urunler_datagridview.CurrentRow.Selected = true;
            try
            {
                onaycontrol_label.Text = Urunler_datagridview.Rows[e.RowIndex].Cells["urunOnay"].FormattedValue.ToString();
                urunkodu_txt.Text = Urunler_datagridview.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();

            }
            catch (Exception)
            {

            }
        }    

        private void UrunlerComboBox()
        {
            urunler_combobox.Items.Clear();
            urunler_combobox.Text = "Tüm Ürünler";
            urunler_combobox.Items.Add("Tüm Ürünler");
            urunler_combobox.Items.Add("Onaylanan Ürünler");
            urunler_combobox.Items.Add("Onay Bekleyen Ürünler");

            sorgu = "SELECT * FROM showUruns";
            Urunler_datagridview.DataSource = Singleton.Instance.islem.Showdatabases(sorgu);

            string[] columnHeaders = { "ID", "Ürün Adı", "Ürün Miktarı", "Ürün Birimi", "Ürün Fiyatı", "Ürün Türü", "Ürünü Satan", "Barkod No", "Ürün Onayı" };
            for (int i = 0; i< columnHeaders.Length; i++)
            {
                Urunler_datagridview.Columns[i].HeaderText = columnHeaders[i];
            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                Urunler_datagridview.FirstDisplayedScrollingRowIndex = Urunler_datagridview.Rows[e.Value].Index;
            }
            catch (Exception)
            {


            }
        }

        private void Urunler_datagridview_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = Urunler_datagridview.RowCount - 1;
            }
            catch (Exception)
            {
            }
        }

        private void Urunler_datagridview_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = Urunler_datagridview.RowCount - 1;
            }
            catch (Exception)
            {
            }
        }

        private void Urunler_datagridview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Urunler_datagridview.CurrentRow.Selected = true;
            try
            {
                onaycontrol_label.Text = Urunler_datagridview.Rows[e.RowIndex].Cells["urunOnay"].FormattedValue.ToString();
                urunkodu_txt.Text = Urunler_datagridview.Rows[e.RowIndex].Cells["urunBarkodNo"].FormattedValue.ToString();

            }
            catch (Exception)
            {             
            }
        }

    }
}