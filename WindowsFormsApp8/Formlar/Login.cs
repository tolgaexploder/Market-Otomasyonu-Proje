using Bunifu.Framework.UI;
using MetroSet_UI.Forms;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username_admin.Text) || string.IsNullOrEmpty(password_admin.Text))
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                Singleton.Instance.islem.KullaniciGirisi(username_admin, password_admin, this);
            }
        }
        private void metroTile4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.girisBekleniyor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminGiris admin = new AdminGiris();
            this.Hide();
            admin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
