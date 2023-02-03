﻿using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Application = System.Windows.Forms.Application;

namespace WindowsFormsApp8.Formlar
{
    public partial class GecmisSiparisler : MaterialForm
    {
        public GecmisSiparisler()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue700, Primary.BlueGrey500, Accent.Blue700, TextShade.WHITE);
        }
        private void GecmisSiparisler_Load(object sender, EventArgs e)
        {    
            SiparislerimOnLoad();
            ShowSiparisler_datagrid.RowHeadersVisible = false;
        }
        public void SiparislerimOnLoad()
        {
            ShowSiparisler_datagrid.DataSource = null;
        }

        private void Listele(string sorgu)
        {
            DataTable dataTable = new DataTable();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sorgu, Singleton.Instance.islem.baglanti);
            dataAdapter.SelectCommand.Parameters.Add("@p1", OleDbType.Date).Value = tarih1_datetime.Value;
            dataAdapter.SelectCommand.Parameters.Add("@p2", OleDbType.Date).Value = tarih2_datetime.Value;
            dataAdapter.Fill(dataTable);
            ShowSiparisler_datagrid.DataSource = dataTable;
        }

        private void GecmisSiparisler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.form1);
        }
        
        private void Yaptigim_satislar_btn_Click_1(object sender, EventArgs e)
        {      
            string sorgu = "SELECT * FROM ShowSatislarTable WHERE SatisTarihi between @p1 and @p2  and SatisYapan='" + Singleton.Instance.currentUser.UserName + "'";
            Listele(sorgu);

            string[] siparisler = { "Satış Tarihi", "Ürün Adı", "Satış Fiyatı", "Satış Miktarı", "Ürün Birimi", "Satışı Yapan", "Satın Alan" };
            for (int i = 0; i < siparisler.Length; i++)
            {
                ShowSiparisler_datagrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void OncekiSiparislerim_listele_btn_Click_1(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM ShowSatislarTable WHERE SatisTarihi between @p1 and @p2  and SatinAlan='" + Singleton.Instance.currentUser.UserName + "'";
            Listele(sorgu);

            string[] siparisler = { "Satış Tarihi", "Ürün Adı", "Satış Fiyatı", "Satış Miktarı", "Ürün Birimi", "Satışı Yapan", "Satın Alan" };
            for (int i = 0; i < siparisler.Length; i++)
            {
                ShowSiparisler_datagrid.Columns[i].HeaderText = siparisler[i];
            }
        }

        private void herikiside_btn_Click_1(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM ShowSatislarTable WHERE SatisTarihi between @p1 and @p2 And SatinAlan='" + Singleton.Instance.currentUser.UserName + "' or SatisYapan='" + Singleton.Instance.currentUser.UserName + "'";
            Listele(sorgu);
            
            string[] siparisler = { "Satış Tarihi", "Ürün Adı", "Satış Fiyatı", "Satış Miktarı", "Ürün Birimi", "Satışı Yapan", "Satın Alan" };
            for (int i = 0; i < siparisler.Length; i++)
            {
                ShowSiparisler_datagrid.Columns[i].HeaderText = siparisler[i];
            }
        }

        private void metroSetButton1_Click_1(object sender, EventArgs e)
        {
            excel.Application app = new excel.Application
            {
                Visible = true
            };
            Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sayfa = (Worksheet)kitap.Sheets[1];
            for (int i = 0; i < ShowSiparisler_datagrid.Columns.Count; i++)//basliklar aktariliyor
            {
                Range alan = (Range)sayfa.Cells[1, 1];
                alan.Cells[1, i + 1] = ShowSiparisler_datagrid.Columns[i].HeaderText;
            }
            for (int i = 0; i < ShowSiparisler_datagrid.Columns.Count; i++)
            {
                for (int j = 0; j < ShowSiparisler_datagrid.Rows.Count; j++)
                {
                    Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                    alan2.Cells[2, 1] = ShowSiparisler_datagrid[i, j].Value;
                }
            }
        }
    }
}
