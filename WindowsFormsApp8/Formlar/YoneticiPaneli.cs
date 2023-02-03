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
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }
        bool mouseDown;
        private Point offset;
        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            yoneticiFormOnLoad();
        }

        public void yoneticiFormOnLoad()
        {
            Kullanicikontrol_tarih_label.Text = "Tarih : " + DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString();// tarih anasayfa
            Tarihurunkontrol_label.Text = "Tarih : " + DateTime.Parse(DateTime.Now.ToShortDateString()).ToShortDateString();// tarih profilim
            double kasabutce = 0;
            Singleton.Instance.islem.SkyKomisyon(kasabutce);
            kasagelir_lbl.Text = "Sky Komisyon Geliri: " + Singleton.Instance.currentUser.kasabutce.ToString() + " TL";
        }

        public void UyelerKontrolEkran()
        {
            panel2.Controls.Clear();
            UyeleriListele uyelerkontrol = new UyeleriListele();
            uyelerkontrol.TopLevel = false;
            panel2.Controls.Add(uyelerkontrol);
            uyelerkontrol.Show();
            uyelerkontrol.Dock = DockStyle.Fill;
            uyelerkontrol.BringToFront();

        }

        public void AdminlerKontrolEkran()
        {
            panel2.Controls.Clear();
            AdminleriListele adminlerkontrol = new AdminleriListele();
            adminlerkontrol.TopLevel = false;
            panel2.Controls.Add(adminlerkontrol);
            adminlerkontrol.Show();
            adminlerkontrol.Dock = DockStyle.Fill;
            adminlerkontrol.BringToFront();

        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            panel5.Height = button1.Height;
            panel5.Top = button1.Top;
            AdminlerKontrolEkran();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Height = button2.Height;
            panel5.Top = button2.Top;
            UyelerKontrolEkran();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Singleton.Instance.islem.Current_user_update_cikis();
            Singleton.Instance.girisBekleniyor.Show();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
