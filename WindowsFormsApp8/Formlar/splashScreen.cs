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
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        Random random = new Random();
        int s1;
        private void splashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                s1 = random.Next(1, 10);
                materialProgressBar1.Value += s1;
                if (materialProgressBar1.Value == 100)
                {
                    timer1.Stop();
                    this.Hide();
                    new GirisBekleniyor().Show();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
