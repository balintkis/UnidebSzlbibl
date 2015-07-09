using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace UniDeb
{

    /// <summary>
    /// Interaction logic for WizardPage3.xaml
    /// </summary>
    public partial class WizardPage3 : Window
    {
        private Service service;
        private String initString;
        private String egybenString;
        private String[] mezok = new String[10];

        public WizardPage3(String initString)
        {
            this.service = Service.getInstance();
            InitializeComponent();
            mezok[0] = initString;
            this.initString = initString + "$";
            egybenString = this.initString;

        }

        private void BtnPreview_Click(object sender, RoutedEventArgs e)
        {
            Strngesites();
            TxtbxPreview.Text = this.egybenString;

        }

        private void Strngesites()
        {
            this.egybenString = this.egybenString
                    + Txtbx3_1_2.Text + "$"
                    + Cmbbx3_1_3helye.SelectedValue.ToString() + "$"
                    + Txtbx3_1_4.Text + "$"
                    + Cmbbx3_1_5szlengtipus.SelectedValue.ToString() + "$"
                    + Cmbbx3_1_6nyelv.SelectedValue.ToString() + "$"
                    + Cmbbx3_1_7publikacio_fajt.SelectedValue.ToString() + "$"
                    + Cmbbx3_1_8adatkozl_forma.SelectedValue.ToString() + "$"
                    + Cmbbx3_1_9publikacio_tema.SelectedValue.ToString() + "$"
                    + Cmbbx3_1_10publikacio_celja.SelectedValue.ToString() + "$";

            mezok[1] = Txtbx3_1_2.Text;
            mezok[2] = Cmbbx3_1_3helye.SelectedValue.ToString();
            mezok[3] = Txtbx3_1_4.Text;
            mezok[4] = Cmbbx3_1_5szlengtipus.SelectedValue.ToString();
            mezok[5] = Cmbbx3_1_6nyelv.SelectedValue.ToString();
            mezok[6] = Cmbbx3_1_7publikacio_fajt.SelectedValue.ToString();
            mezok[7] = Cmbbx3_1_8adatkozl_forma.SelectedValue.ToString();
            mezok[8] = Cmbbx3_1_9publikacio_tema.SelectedValue.ToString();
            mezok[9] = Cmbbx3_1_10publikacio_celja.SelectedValue.ToString();
        }

        private void BtnHTMLPreview_Click(object sender, RoutedEventArgs e)
        {
            Strngesites();

            String htmlWebPage = "<head><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head><body>";
            foreach (String temp in mezok)
            {
                htmlWebPage += temp;
            }
            htmlWebPage += "</body>";

            HTMLPreviewWindow htmlWindow = new HTMLPreviewWindow(htmlWebPage);
            htmlWindow.Show();
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            Strngesites();

            String connStr = this.service.ConnectionString;
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            try
            {
                connection.Open();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO adat VALUES(NULL, @teljes_szoveg, @megjelenes_eve, @hasznalat_helye, @hasznalat_eve, @szlengtipus, @nyelv, @publikacio_tipusa, @adatkozles_formaja, @publikacio_temeja, @publikacio_celja)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@teljes_szoveg", this.mezok[0]);
                cmd.Parameters.AddWithValue("@megjelenes_eve", this.mezok[1]);
                cmd.Parameters.AddWithValue("@hasznalat_helye", this.mezok[2]);
                cmd.Parameters.AddWithValue("@hasznalat_eve", this.mezok[3]);
                cmd.Parameters.AddWithValue("@szlengtipus", this.mezok[4]);
                cmd.Parameters.AddWithValue("@nyelv", this.mezok[5]);
                cmd.Parameters.AddWithValue("@publikacio_tipusa", this.mezok[6]);
                cmd.Parameters.AddWithValue("@adatkozles_formaja", this.mezok[7]);
                cmd.Parameters.AddWithValue("@publikacio_temeja", this.mezok[8]);
                cmd.Parameters.AddWithValue("@publikacio_celja", this.mezok[9]);

                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
