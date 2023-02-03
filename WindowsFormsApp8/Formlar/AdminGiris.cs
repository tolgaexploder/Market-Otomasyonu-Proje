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
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisBekleniyor girisBekleniyor = new GirisBekleniyor();
            this.Hide();
            girisBekleniyor.Show();
        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            Singleton.Instance.islem.AdminGirisi(username_admin, password_admin, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YoneticiGirisi yoneticiGirisi = new YoneticiGirisi();
            this.Hide();
            yoneticiGirisi.Show();
        }
    }
}
