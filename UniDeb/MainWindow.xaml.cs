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
    /// 
    public partial class MainWindow : Window
    {
        private Service service;
        private DataTable dt2 = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            service = Service.getInstance();
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
            string connStr = this.service.ConnectionString;

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
            string connStr = this.service.ConnectionString;

            string sql = "SELECT * FROM adat";
            try
            {
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand cmdSel = new MySqlCommand(sql, connection);

                MySqlDataAdapter da2 = new MySqlDataAdapter(cmdSel);
                da2.Fill(this.dt2);
                DgrReadWrite.DataContext = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL kapcsolódási hiba!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Btn_1_1_1Continue_Click(object sender, RoutedEventArgs e)
        {
            String mezok = @"<span class=""kiemelt"">";

            if (Txtbx1_1_1szerzo.Text != "")
                mezok = mezok + "<strong>" + Txtbx1_1_1szerzo.Text + "</strong>";

            if (Txtbx1_1_2kiadaseve.Text != "")
                mezok = mezok + " (" + Txtbx1_1_2kiadaseve.Text + "):";

            if (Txtbx1_1_3konyvcim.Text != "")
                mezok = mezok + "<em> " + Txtbx1_1_3konyvcim.Text + "." + "</em>";

            if (Txtbx1_1_4parhuzamoscim.Text != "")
                mezok = mezok + "<em> " + Txtbx1_1_4parhuzamoscim.Text + "." + "</em>";

            if (Txtbx1_1_5alcim.Text != "")
                mezok = mezok + "<em> (" + Txtbx1_1_5alcim.Text + ".)" + "</em>";

            if (Txtbx1_1_6kotetszam.Text != "")
                mezok = mezok + " " + Txtbx1_1_6kotetszam.Text + ".";

            if (Txtbx1_1_7kiadasszam.Text != "")
                mezok = mezok + " " + Txtbx1_1_7kiadasszam.Text + ".";

            if (Txtbx1_1_8sorozat.Text != "")
                mezok = mezok + " (" + Txtbx1_1_8sorozat.Text + ")";

            if (Cmbbx1_1_9mujelleg.SelectedItem != null)
                mezok = mezok +
                    " (" + Cmbbx1_1_9mujelleg.SelectedValue.ToString() + ").";

            if (Txtbx1_1_10kiadashelye.Text != "")
                mezok = mezok + " " + Txtbx1_1_10kiadashelye.Text;

            if (Txtbx1_1_11kiado.Text == "")
            { mezok = mezok + "."; }
            else mezok = mezok + " : " + Txtbx1_1_11kiado.Text + ".";

            if (Txtbx1_1_12lapokszama.Text != "")
                mezok = mezok +
                    " (" + Txtbx1_1_12lapokszama.Text + " lap).";

            mezok += "</span>";

            WizardPage2 wiz2 = new WizardPage2(mezok);
            wiz2.Show();
        }

        private void Btn_1_2_1Continue_Click(object sender, RoutedEventArgs e)
        {
            String mezok = @"<span class=""kiemelt"">";

            if (Txtbx1_2_1.Text != "")
                mezok = mezok + "<strong>" + Txtbx1_2_1.Text + "</strong>" + " szerk.";

            if (Txtbx1_2_2.Text != "")
                mezok = mezok + " (" + Txtbx1_2_2.Text + "): ";

            if (Txtbx1_2_3.Text != "")
                mezok = mezok + "<em> " + Txtbx1_2_3.Text + ".</em>";

            if (Txtbx1_2_4.Text != "")
                mezok = mezok + "<em> " + Txtbx1_2_4.Text + ".</em>";

            if (Txtbx1_2_5.Text != "")
                mezok = mezok + "<em> (" + Txtbx1_2_5.Text + ".)</em>";

            if (Txtbx1_2_6.Text != "")
                mezok = mezok + " " + Txtbx1_2_6.Text + ".";

            if (Txtbx1_2_7.Text != "")
                mezok = mezok + " " + Txtbx1_2_7.Text + ".";

            if (Txtbx1_2_8.Text != "")
                mezok = mezok + " (" + Txtbx1_2_8.Text + ")";

            if (Cmbbx1_2_1.SelectedItem != null)
                mezok = mezok +
                     " (" + Cmbbx1_2_1.SelectedValue.ToString() + ")";

            if (Txtbx1_2_9.Text != "")
                mezok = mezok + " " + Txtbx1_2_9.Text;

            if (Txtbx1_2_10.Text == "")
            { mezok = mezok + "."; }
            else mezok = mezok + " : " + Txtbx1_2_10.Text + ".";

            mezok = mezok + " (" + Txtbx1_2_11.Text + " lap).";

            mezok += "</span>";

            WizardPage2 wiz2 = new WizardPage2(mezok);
            wiz2.Show();
        }



        private void Btn_1_3_1Continue_Click(object sender, RoutedEventArgs e)
        {
            String mezok = @"<span class=""kiemelt"">";
            if (Txtbx1_3_1.Text != "")
                mezok = mezok + "<strong>" + Txtbx1_3_1.Text + "</strong>";

            if (Txtbx1_3_2.Text != "")
                mezok = mezok + " (" + Txtbx1_3_2.Text + "):";

            if (Txtbx1_3_3.Text != "")
                mezok = mezok + " " + Txtbx1_3_3.Text + ". ";

            if (Txtbx1_3_4.Text != "")
                mezok = mezok + "<em> " + Txtbx1_3_4.Text + "." + "</em>";

            if (Txtbx1_3_5.Text != "")
                mezok = mezok + "<em> (" + Txtbx1_3_5.Text + ".)</em>";

            if (Txtbx1_3_6.Text != "")
                mezok = mezok + " In: <strong>" + Txtbx1_3_6.Text + "</strong> szerk.:";

            if (Txtbx1_3_7.Text != "")
                mezok = mezok + "<em> " + Txtbx1_3_7.Text + ".</em>";

            if (Txtbx1_3_8.Text != "")
                mezok = mezok + "<em> " + Txtbx1_3_8.Text + ".</em>";

            if (Txtbx1_3_9.Text != "")
                mezok = mezok + "<em> (" + Txtbx1_3_9.Text + ".)</em>";

            if (Txtbx1_3_10.Text != "")
                mezok = mezok + " " + Txtbx1_3_10.Text + ".";

            if (Txtbx1_3_11.Text != "")
                mezok = mezok + " " + Txtbx1_3_11.Text + ".";

            if (Txtbx1_3_12.Text != "")
                mezok = mezok + " (" + Txtbx1_3_12.Text + ")";

            if (Cmbbx1_3_1.SelectedItem != null)
                mezok = mezok +
                    " (" + Cmbbx1_3_1.SelectedValue.ToString() + ").";

            if (Txtbx1_3_13.Text != "")
                mezok = mezok + " " + Txtbx1_3_13.Text;

            if (Txtbx1_3_14.Text == "")
                mezok = mezok + ".";
            else mezok = mezok +
                " : " + Txtbx1_3_14.Text + ".";

            if (Txtbx1_3_15.Text != "")
                mezok = mezok + " " + Txtbx1_3_15.Text + ".";

            mezok += "</span>";

            WizardPage2 wiz2 = new WizardPage2(mezok);
            wiz2.Show();
        }

        private void Btn_1_4_1Continue_Click(object sender, RoutedEventArgs e)
        {
            String mezok = @"<span class=""kiemelt"">";

            if (Txtbx1_4_1.Text != "")
                mezok = mezok + "<strong>" + Txtbx1_4_1.Text + "</strong>";

            if (Txtbx1_4_2.Text != "")
                mezok = mezok + " (" + Txtbx1_4_2.Text + "):";

            if (Txtbx1_4_3.Text != "")
                mezok = mezok + " " + Txtbx1_4_3.Text + ". ";

            if (Txtbx1_4_4.Text != "")
                mezok = mezok + " " + Txtbx1_4_4.Text + ".";

            if (Txtbx1_4_5.Text != "")
                mezok = mezok + " (" + Txtbx1_4_5.Text + ".)";

            if (Txtbx1_4_6.Text != "")
                mezok = mezok + "<em> " + Txtbx1_4_6.Text + "</em>";

            if (Txtbx1_4_7.Text != "")
                mezok = mezok + "<em> " + Txtbx1_4_7.Text + "</em>";

            if (Txtbx1_4_8.Text != "")
                mezok = mezok + "<em> /" + Txtbx1_4_8.Text + "</em>";

            if (Txtbx1_4_9.Text == "")
                mezok = mezok + ".";
            else mezok = mezok + ": " + Txtbx1_4_9.Text + ".";

            mezok += "</span>";

            WizardPage2 wiz2 = new WizardPage2(mezok);
            wiz2.Show();

        }

        private void Btn_1_5_1Continue_Click(object sender, RoutedEventArgs e)
        {
            String mezok = @"<span class=""kiemelt"">";
            if (Txtbx1_5_1.Text != "")
                mezok = "<strong>" + Txtbx1_5_1.Text + "</strong>";

            if (Txtbx1_5_2.Text != "")
                mezok = mezok + " (" + Txtbx1_5_2.Text + "):";

            if (Txtbx1_5_3.Text != "")
                mezok = mezok + " " + Txtbx1_5_3.Text + ".";

            if (Txtbx1_5_4.Text != "")
                mezok = mezok + " " + Txtbx1_5_4.Text + ".";

            if (Txtbx1_5_5.Text != "")
                mezok = mezok + " (" + Txtbx1_5_5.Text + ".)";

            if (Txtbx1_5_6.Text != "")
                mezok = mezok + "<em> " + Txtbx1_5_6.Text + "</em>";

            if (Txtbx1_5_7.Text != "")
                mezok = mezok + "<em> " + Txtbx1_5_7.Text + "</em>";

            if (Txtbx1_5_8.Text != "")
                mezok = mezok + "<em>/" + Txtbx1_5_8.Text + "</em>";

            if (Txtbx1_5_9.Text != "")
                mezok = mezok + " (" + Txtbx1_5_9.Text + ")";

            if (Txtbx1_5_10.Text != "")
                mezok = mezok + ": " + Txtbx1_5_10.Text + ".";
            else mezok = mezok + ".";

            mezok += "</span>";

            WizardPage2 wiz2 = new WizardPage2(mezok);
            wiz2.Show();
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < this.dt2.Rows.Count; i++)
            {
//DgrReadWrite.SelectedCells.
                // looping through DgrReadWrite.SelectedItems.Cast<SomethingReadable??>
                if ("" == this.dt2.Rows[i][0].ToString())
                {   
                    dt2.Rows[i].Delete();
                    DgrReadWrite.Items.Refresh();
                }
            }

        }

        private void MenuItemMySql_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }


    }



}

