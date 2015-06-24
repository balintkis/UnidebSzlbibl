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

        private void Btn_1_5_1Continue_Click(object sender, RoutedEventArgs e)
        {
            WizardPage2 wiz2 = new WizardPage2("");
            wiz2.Show();
        }
    }
}
