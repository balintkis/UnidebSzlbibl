using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace UniDeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            new About(this).Show();
        }

        private void BtnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string connStr = Service.getConnectionString();

            string sql = "SELECT * FROM adat";
            try
            {
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand cmdSel = new MySqlCommand(sql, connection);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                da.Fill(dt);
                DgrReadOnly.DataContext = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL kapcsolódási hiba!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItemWeb_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://web.unideb.hu/~tkis/keres/index.php");
        }

        private void BtnDisplay2_Click(object sender, RoutedEventArgs e)
        {
            string connStr = Service.getConnectionString();

            string sql = "SELECT * FROM adat";
            try
            {
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand cmdSel = new MySqlCommand(sql, connection);
                DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmdSel);
                da2.Fill(dt2);
                DgrReadWrite.DataContext = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL kapcsolódási hiba!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Btn_1_1_1Continue_Click(object sender, RoutedEventArgs e)
        {
            String mezok =
                "<strong>" + Txtbx1_1_1szerzo.Text + "</strong>" +
                " (" + Txtbx1_1_2kiadaseve.Text + "):" +
                "<em> " + Txtbx1_1_3konyvcim.Text + "." + "</em>" +
                "<em> " + Txtbx1_1_4parhuzamoscim.Text + "." + "</em>" +
                "<em> (" + Txtbx1_1_5alcim.Text + ".)" + "</em>" +
                " " + Txtbx1_1_6kotetszam.Text + "." +
                " " + Txtbx1_1_7kiadasszam.Text + "." +
                " (" + Txtbx1_1_8sorozat.Text + ")" +
                " (" + Cmbbx1_1_9mujelleg.SelectedValue.ToString() + ")." +
                " " + Txtbx1_1_10kiadashelye.Text
                ;

            if (Txtbx1_1_11kiado.Text == "")
            { mezok = mezok + "."; }
            else mezok = mezok + " : " + Txtbx1_1_11kiado.Text + ".";

            mezok = mezok +
                " (" + Txtbx1_1_12lapokszama.Text + " lap).";

            WizardPage2 wiz2 = new WizardPage2(mezok);
            wiz2.Show();
        }

        private void Btn_1_2_1Continue_Click(object sender, RoutedEventArgs e)
        {
            String mezok =
                "<strong>" + Txtbx1_2_1.Text + "</strong>" + " szerk." +
                " (" + Txtbx1_2_2.Text + "): " +
                "<em> " + Txtbx1_2_3.Text + ".</em>" +
                "<em> " + Txtbx1_2_4.Text + ".</em>" +
                "<em> (" + Txtbx1_2_5.Text + ".)</em>" +
                " " + Txtbx1_2_6.Text + "." +
                " " + Txtbx1_2_7.Text + "." +
                " (" + Txtbx1_2_8.Text + ")" +
                " (" + Cmbbx1_2_1.SelectedValue.ToString() + ")" +
                " " + Txtbx1_2_9
                ;

            if (Txtbx1_2_10.Text == "")
            { mezok = mezok + "."; }
            else mezok = mezok + " : " + Txtbx1_2_10.Text + ".";

            mezok = mezok + " (" + Txtbx1_2_11 + " lap).";

            WizardPage2 wiz2 = new WizardPage2(mezok);
            wiz2.Show();
        }

        private void Btn_1_5_1Continue_Click(object sender, RoutedEventArgs e)
        {
            WizardPage2 wiz2 = new WizardPage2("");
            wiz2.Show();
        }
    }
}
