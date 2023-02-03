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
    public partial class GirisBekleniyor : MetroFramework.Forms.MetroForm
    {
        public GirisBekleniyor()
        {
            InitializeComponent();
        }

        private void GirisBekleniyor_Load(object sender, EventArgs e)
        {
            
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Form1 kontrol = new Form1();
            this.Hide();
            kontrol.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            UyeOl uye = new UyeOl();
            this.Hide();
            uye.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
