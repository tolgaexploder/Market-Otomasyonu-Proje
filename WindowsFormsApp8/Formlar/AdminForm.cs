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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MetroFramework.Controls;
using static MetroFramework.Drawing.MetroPaint.BorderColor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Point = System.Drawing.Point;
using Application = System.Windows.Forms.Application;

namespace WindowsFormsApp8.Formlar
{
    public partial class AdminForm : Form
    {
        private string sorgu = "";
        public AdminForm()
        {
            InitializeComponent();          
        }

        bool mouseDown;
        private Point offset;

        private void AdminForm_Load(object sender, EventArgs e)
        {
            AdminFormOnLoad();
        }

        public void AdminFormOnLoad()
        {
            Kullanicikontrol_tarih_label.Text = "Tarih : " + DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString();// tarih anasayfa
            Tarihurunkontrol_label.Text = "Tarih : " + DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString();// tarih profilim
            double kasabutce = 0;
            Singleton.Instance.islem.SkyKomisyon(kasabutce);
            kasagelir_lbl.Text = "Sky Komisyon Geliri: " + Singleton.Instance.currentUser.kasabutce.ToString() + " TL";
        }

        public void KullaniciKontrolEkran()
        {
            panel4.Controls.Clear();
            KullaniciKontrol kulkontrol = new KullaniciKontrol();
            kulkontrol.TopLevel = false;
            panel4.Controls.Add(kulkontrol);
            kulkontrol.Show();
            kulkontrol.Dock = DockStyle.Fill;
            kulkontrol.BringToFront();

        }
        public void UrunKontrolEkran()
        {
            panel4.Controls.Clear();
            UrunKontrol urunkontrol = new UrunKontrol();
            urunkontrol.TopLevel = false;
            panel4.Controls.Add(urunkontrol);
            urunkontrol.Show();
            urunkontrol.Dock = DockStyle.Fill;
            urunkontrol.BringToFront();
        }
        public void KargoKontrolEkran()
        {
            panel4.Controls.Clear();
            KargoIslemleri kargokontrol = new KargoIslemleri();
            kargokontrol.TopLevel = false;
            panel4.Controls.Add(kargokontrol);
            kargokontrol.Show();
            kargokontrol.Dock = DockStyle.Fill;
            kargokontrol.BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            KullaniciKontrolEkran();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Height = button2.Height;
            panel3.Top = button2.Top;
            UrunKontrolEkran();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Height = button3.Height;
            panel3.Top = button3.Top;
            KargoKontrolEkran();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Singleton.Instance.islem.Current_user_update_cikis();
            Singleton.Instance.girisBekleniyor.Show();

        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
