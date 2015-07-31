using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UniDeb
{
    
    public class Service
    {
        private static Service service;
        public String ConnectionString { get; set; }
        public TextBox CurrentTextbox { get; set; } 

        private Service() {
            // empty constructor
        }

        public static Service getInstance()
        {
            if (service == null)
                service = new Service();
            return service;
        }

        public void Login(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        public void About(object sender, RoutedEventArgs e)
        {
            new About().Show();
        }

        public void Web(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://web.unideb.hu/~tkis/keres/index.php");
        }

        public void Hotkeys(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ctrl + I: Kiválasztott szöveg dőlté" + Environment.NewLine +
                                "Alt + I : Dőlt címkék beszúrása" + Environment.NewLine +
                                Environment.NewLine +
                                "Ctrl + B: Kiválasztott szöveg félkövérré" + Environment.NewLine +
                                "Alt + B : Félkövér címkék beszúrása" + Environment.NewLine +
                                Environment.NewLine +
                                "Ctrl + U: Kiválasztott szöveg aláhúzottá" + Environment.NewLine +
                                "Alt + U : Aláhúzott címkék beszúrása" + Environment.NewLine +
                                Environment.NewLine +
                                "Ctrl + P: Kiválasztott szöveg felsőindexűvé" + Environment.NewLine +
                                "Alt + P : Felsőindex címkék beszúrása" + Environment.NewLine +
                                Environment.NewLine +
                                "Ctrl + L: Kiválasztott szöveg alsóindexűvé" + Environment.NewLine +
                                "Alt + L : Alsóindex címkék beszúrása" + Environment.NewLine +
                                Environment.NewLine +
                                "Ctrl + Alt + '-' : —" + Environment.NewLine +
                                "Ctrl + '-'          : –" + Environment.NewLine +
                                Environment.NewLine +
                                "F1                        :      Gyorsbillentyűk" + Environment.NewLine +
                                "F2                        :      MySQL beállítások" + Environment.NewLine +
                                "F3                        :      Névjegy" + Environment.NewLine +
                                "F5                        :      Weboldal", "Gyorsbillentyűk");
        }
    }
}
