using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp8.Formlar;

namespace WindowsFormsApp8
{
    public sealed class Singleton
    {
        private Singleton()
        {
        }
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public void ExitTheApplication() => Application.Exit();
        public void ChangeScreen(Form hide, Form show)
        {
            hide.Hide();
            show.Show();
        }
        
        public CurrentUser currentUser = new CurrentUser();
        public veriler islem = new veriler(); 
        public AdminForm adminForm = new AdminForm();
        public Form1 form1 = new Form1();
        public GirisBekleniyor girisBekleniyor = new GirisBekleniyor();
        public GecmisSiparisler gecmisSiparisler = new GecmisSiparisler();
        public SiparislerimiListele listeleSiparisler = new SiparislerimiListele();
        public YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();    
    }
}
