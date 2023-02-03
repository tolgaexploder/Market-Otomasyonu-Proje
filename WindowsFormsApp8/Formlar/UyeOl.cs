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
    public partial class UyeOl : Form
    {
        public UyeOl()
        {
            InitializeComponent();
        }

        static bool SayiMi(string deger)
        {
            try
            {
                long.Parse(deger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void cikis_btn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Singleton.Instance.girisBekleniyor.Show();
        }

        private void kullanici_ekle_btn_Click(object sender, EventArgs e)
        {
            if (username_txt.Text == "" || password_txt.Text == "" || adres_txt.Text == "" || ad_txt.Text == "" || soyad_txt.Text == "" || tc_txt.Text == "" || telefon_txt.Text == "" || adres_txt.Text == "" || email_txt.Text == "")
                MessageBox.Show("Lütfen tüm alanları doldurunuz");
            else if (SayiMi(tc_txt.Text) == false)
                MessageBox.Show("Girdiğiniz TC geçersiz.");
            else if (SayiMi(telefon_txt.Text) == false)
                MessageBox.Show("Girdiğiniz telefon numarası geçersiz.");
            else if (password_txt.Text == passagain_txt.Text)
            {
                Singleton.Instance.islem.KullaniciEkle(username_txt, password_txt, ad_txt, soyad_txt, tc_txt, telefon_txt, adres_txt, email_txt, this);
            }
            else
                MessageBox.Show("Şifreler aynı değil.", "Hata 2");
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.girisBekleniyor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefon_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tc_txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void soyad_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ad_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void passagain_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tc_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
