using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApp8.Formlar
{
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void bunifuCheckBox3_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            label2.Text = "Mevcut Bakiyeniz: " + Singleton.Instance.currentUser.Bakiye.ToString();
            //label3.Text = Singleton.Instance.main.bakiye_label.Text;

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            int u = bunifuTextBox2.TextLength;
            if (u > 2)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
                bunifuTextBox2.Text = "";
            }
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {
            int u = bunifuTextBox3.TextLength;
            if (u > 4)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
                bunifuTextBox3.Text = "";
            }
        }
        
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Singleton.Instance.form1.Form1OnLoad();
            Singleton.Instance.ChangeScreen(this, Singleton.Instance.form1);

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {
            int u = bunifuTextBox4.TextLength;
            if (u > 1)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
                bunifuTextBox4.Text = "";
            }
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            int u = bunifuTextBox5.TextLength;
            if (u > 1)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
                bunifuTextBox5.Text = "";
            }
        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {
            int u = bunifuTextBox6.TextLength;
            if (u > 1)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
                bunifuTextBox6.Text = "";
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            odemeKontrol();
        }

        public void odemeKontrol()
        {
            Form1 form = new Form1();

            if (TextboxBosMu())
            {
                MessageBox.Show("Lütfen işlemi tamamlamak için alanları doldurunuz.");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Ad ve soyad kısmı boş bırakılamaz");
            }
            else if (bunifuTextBox7.Text == "")
            {
                MessageBox.Show("Para birimi ve türü seçmediniz.");
            }
            else
            {
                if (Singleton.Instance.currentUser.PasifBakiye == 0)
                {
                    Singleton.Instance.islem.GecicibakiyeGuncelle(Convert.ToInt32(bunifuTextBox7.Text));
                    bunifuTextBox7.Text = "";
                    this.Close();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Eklediğiniz tutar, önceki eklemenizin üzerine eklenmistir.", "Extra Bakiye Yükleme");
                    Singleton.Instance.currentUser.PasifBakiye = Singleton.Instance.currentUser.PasifBakiye + Convert.ToInt32(bunifuTextBox7.Text);
                    Singleton.Instance.islem.GecicibakiyeGuncelle(Singleton.Instance.currentUser.PasifBakiye);
                    bunifuTextBox7.Text = "";
                    this.Close();
                    form.Show();
                }
            }
        }

        private bool TextboxBosMu()
        {
            return string.IsNullOrEmpty(textBox2.Text) ||
                   string.IsNullOrEmpty(bunifuTextBox1.Text) ||
                   string.IsNullOrEmpty(bunifuTextBox2.Text) ||
                   string.IsNullOrEmpty(bunifuTextBox3.Text) ||
                   string.IsNullOrEmpty(bunifuTextBox4.Text) ||
                   string.IsNullOrEmpty(bunifuTextBox5.Text) ||
                   string.IsNullOrEmpty(bunifuTextBox6.Text);
        }
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            int u = bunifuTextBox1.TextLength;
            if (u > 16)
            {
                MessageBox.Show("Maksimum sınıra ulaştınız!");
                bunifuTextBox1.Text = "";
            }
        }

        private void bunifuTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void bunifuTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void bunifuTextBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void bunifuTextBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void bunifuTextBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void bunifuTextBox6_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
