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
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        private bool needUpdate = false;
        public MainWindow()
        {
            InitializeComponent();
            service = Service.getInstance();
            AddHotKeys();
            DefaultConnectionFromFile();

        }


        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            this.service.About(sender, e);
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
                DgrReadOnly.Items.Refresh();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                // MessageBox.Show("MySQL kapcsolódási hiba!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItemWeb_Click(object sender, RoutedEventArgs e)
        {
            this.service.Web(sender, e);
        }

        private void BtnDisplay2_Click(object sender, RoutedEventArgs e)
        {
            LoadRefreshDgrReadWrite();
        }

        private void LoadRefreshDgrReadWrite()
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
                DgrReadWrite.Items.Refresh();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //MessageBox.Show("MySQL kapcsolódási hiba!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Btn_1_1_1Continue_Click(object sender, RoutedEventArgs e)
        {
            if (Cmbbx1_1_9mujelleg.Items.Count == 0)
                MessageBox.Show("Először létesítsen kapcsolatot az adatbázissal!", "Nem létező kapcsolat", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {

                String mezok = @"<span class=""kiemelt"">";

                if (Txtbx1_1_1szerzo.Text != "")
                    mezok = mezok + "<strong>" + Txtbx1_1_1szerzo.Text + "</strong>";

                if (Txtbx1_1_2kiadaseve.Text != "")
                    mezok = mezok + " " + Txtbx1_1_2kiadaseve.Text + ".";

                if (Txtbx1_1_3konyvcim.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_1_3konyvcim.Text + "." + "</em>";

                if (Txtbx1_1_4parhuzamoscim.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_1_4parhuzamoscim.Text + "." + "</em>";

                if (Txtbx1_1_5alcim.Text != "")
                    mezok = mezok + "<em> (" + Txtbx1_1_5alcim.Text + ")." + "</em>";

                if (Txtbx1_1_6kotetszam.Text != "")
                    mezok = mezok + " <em>" + Txtbx1_1_6kotetszam.Text + ".</em>";

                if (Txtbx1_1_7kiadasszam.Text != "")
                    mezok = mezok + " " + Txtbx1_1_7kiadasszam.Text + ".";

                if (Txtbx1_1_8sorozat.Text != "")
                    mezok = mezok + " (" + Txtbx1_1_8sorozat.Text + ").";

                if (Cmbbx1_1_9mujelleg.SelectedItem != null)
                    mezok = mezok +
                        " (" + Cmbbx1_1_9mujelleg.SelectedItem.ToString() + ").";

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
        }

        private void Btn_1_2_1Continue_Click(object sender, RoutedEventArgs e)
        {
            if (Cmbbx1_1_9mujelleg.Items.Count == 0)
                MessageBox.Show("Először létesítsen kapcsolatot az adatbázissal!", "Nem létező kapcsolat", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                String mezok = @"<span class=""kiemelt"">";

                if (Txtbx1_2_1.Text != "")
                    mezok = mezok + "<strong>" + Txtbx1_2_1.Text + "</strong>" + " szerk.";

                if (Txtbx1_2_2.Text != "")
                    mezok = mezok + " " + Txtbx1_2_2.Text + ". ";

                if (Txtbx1_2_3.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_2_3.Text + ".</em>";

                if (Txtbx1_2_4.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_2_4.Text + ".</em>";

                if (Txtbx1_2_5.Text != "")
                    mezok = mezok + "<em> (" + Txtbx1_2_5.Text + ").</em>";

                if (Txtbx1_2_6.Text != "")
                    mezok = mezok + " <em>" + Txtbx1_2_6.Text + ".</em>";

                if (Txtbx1_2_7.Text != "")
                    mezok = mezok + " " + Txtbx1_2_7.Text + ".";

                if (Txtbx1_2_8.Text != "")
                    mezok = mezok + " (" + Txtbx1_2_8.Text + ").";

                if (Cmbbx1_2_1.SelectedItem != null)
                    mezok = mezok +
                         " (" + Cmbbx1_2_1.SelectedItem.ToString() + ")";

                if (Txtbx1_2_9.Text != "")
                    mezok = mezok + " " + Txtbx1_2_9.Text;

                if (Txtbx1_2_10.Text == "")
                { mezok = mezok + "."; }
                else mezok = mezok + " : " + Txtbx1_2_10.Text + ".";

                if (Txtbx1_2_11.Text != "")
                    mezok = mezok + " (" + Txtbx1_2_11.Text + " lap).";


                mezok += "</span>";
                WizardPage2 wiz2 = new WizardPage2(mezok);
                wiz2.Show();
            }
        }



        private void Btn_1_3_1Continue_Click(object sender, RoutedEventArgs e)
        {
            if (Cmbbx1_1_9mujelleg.Items.Count == 0)
                MessageBox.Show("Először létesítsen kapcsolatot az adatbázissal!", "Nem létező kapcsolat", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                String mezok = @"<span class=""kiemelt"">";
                if (Txtbx1_3_1.Text != "")
                    mezok = mezok + "<strong>" + Txtbx1_3_1.Text + "</strong>";

                if (Txtbx1_3_2.Text != "")
                    mezok = mezok + " " + Txtbx1_3_2.Text + ".";

                if (Txtbx1_3_3.Text != "")
                    mezok = mezok + " " + Txtbx1_3_3.Text + ". ";

                if (Txtbx1_3_4.Text != "")
                    mezok = mezok + " " + Txtbx1_3_4.Text + "." + "";

                if (Txtbx1_3_5.Text != "")
                    mezok = mezok + " (" + Txtbx1_3_5.Text + ").";

                if (Txtbx1_3_6.Text != "")
                    mezok = mezok + " In: <strong>" + Txtbx1_3_6.Text + "</strong> szerk.:";

                if (Txtbx1_3_7.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_3_7.Text + ".</em>";

                if (Txtbx1_3_8.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_3_8.Text + ".</em>";

                if (Txtbx1_3_9.Text != "")
                    mezok = mezok + "<em> (" + Txtbx1_3_9.Text + ").</em>";

                if (Txtbx1_3_10.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_3_10.Text + ".</em>";

                if (Txtbx1_3_11.Text != "")
                    mezok = mezok + " " + Txtbx1_3_11.Text + ".";

                if (Txtbx1_3_12.Text != "")
                    mezok = mezok + " (" + Txtbx1_3_12.Text + ").";

                if (Cmbbx1_3_1.SelectedItem != null)
                    mezok = mezok +
                        " (" + Cmbbx1_3_1.SelectedItem.ToString() + ").";

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
        }

        private void Btn_1_4_1Continue_Click(object sender, RoutedEventArgs e)
        {
            if (Cmbbx1_1_9mujelleg.Items.Count == 0)
                MessageBox.Show("Először létesítsen kapcsolatot az adatbázissal!", "Nem létező kapcsolat", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                String mezok = @"<span class=""kiemelt"">";

                if (Txtbx1_4_1.Text != "")
                    mezok = mezok + "<strong>" + Txtbx1_4_1.Text + "</strong>";

                if (Txtbx1_4_2.Text != "")
                    mezok = mezok + " " + Txtbx1_4_2.Text + ".";

                if (Txtbx1_4_3.Text != "")
                    mezok = mezok + " " + Txtbx1_4_3.Text + ". ";

                if (Txtbx1_4_4.Text != "")
                    mezok = mezok + " " + Txtbx1_4_4.Text + ".";

                if (Txtbx1_4_5.Text != "")
                    mezok = mezok + " (" + Txtbx1_4_5.Text + ").";

                if (Txtbx1_4_6.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_4_6.Text + "</em>";

                if (Txtbx1_4_7.Text != "")
                    mezok = mezok + "<em> " + Txtbx1_4_7.Text + "</em>";

                if (Txtbx1_4_8.Text != "")
                    mezok = mezok + "<em>/" + Txtbx1_4_8.Text + "";
                else mezok += "<em>";

                if (Txtbx1_4_9.Text == "")
                    mezok = mezok + ".</em>";
                else mezok = mezok + ":</em> " + Txtbx1_4_9.Text + ".";

                mezok += "</span>";
                WizardPage2 wiz2 = new WizardPage2(mezok);
                wiz2.Show();

            }
        }

        private void Btn_1_5_1Continue_Click(object sender, RoutedEventArgs e)
        {
            if (Cmbbx1_1_9mujelleg.Items.Count == 0)
                MessageBox.Show("Először létesítsen kapcsolatot az adatbázissal!", "Nem létező kapcsolat", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                String mezok = @"<span class=""kiemelt"">";
                if (Txtbx1_5_1.Text != "")
                    mezok += "<strong>" + Txtbx1_5_1.Text + "</strong>";

                if (Txtbx1_5_2.Text != "")
                    mezok = mezok + " " + Txtbx1_5_2.Text + ".";

                if (Txtbx1_5_3.Text != "")
                    mezok = mezok + " " + Txtbx1_5_3.Text + ".";

                if (Txtbx1_5_4.Text != "")
                    mezok = mezok + " " + Txtbx1_5_4.Text + ".";

                if (Txtbx1_5_5.Text != "")
                    mezok = mezok + " (" + Txtbx1_5_5.Text + ").";

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
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan végérvényesen törölni akarja a kijelölt rekordo(ka)t? A törölt elemek vissza nem állíthatóak.", "Figyelem!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

                String ids = "";

                // create a list of rows that need to be deleted
                List<DataRow> listOfRowsToDelete = new List<DataRow>();
                foreach (DataRowView drRow in DgrReadWrite.SelectedItems)
                {
                    listOfRowsToDelete.Add(drRow.Row);
                    // put index numbers into a string for MySQL query
                    ids = ids + drRow["index"] + ",";
                }
                // remove last ',' from query string
                ids = ids.Remove(ids.Length - 1);

                // delete all the rows from the datatable
                foreach (DataRow drRow in listOfRowsToDelete)
                {
                    dt2.Rows.Remove(drRow);
                    DgrReadWrite.Items.Refresh();
                }


                // delete from MySQL
                // DELETE FROM table WHERE id IN (?,?,?,?,?,?,?,?)

                String connStr = this.service.ConnectionString;

                string sql = "DELETE FROM `tkis`.`adat` WHERE `adat`.`index` IN (" + ids + ")";
                MySqlConnection connection = new MySqlConnection(connStr);
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //MessageBox.Show("MySQL hiba!" + ex.ToString(), "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                connection.Close();
                MessageBox.Show("Ezen indexű sorok törölve: " + ids);
            }
        }

        private void MenuItemMySql_Click(object sender, RoutedEventArgs e)
        {
            this.service.Login(sender, e);
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {

            String connStr = this.service.ConnectionString;
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            DataRowView rowview = DgrReadWrite.SelectedItem as DataRowView;

            try
            {
                connection.Open();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO adat VALUES(NULL, @teljes_szoveg, @megjelenes_eve, @hasznalat_helye, @hasznalat_eve, @szlengtipus, @nyelv, @publikacio_tipusa, @adatkozles_formaja, @publikacio_temeja, @publikacio_celja)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@teljes_szoveg", rowview.Row["teljes_szoveg"].ToString());
                cmd.Parameters.AddWithValue("@megjelenes_eve", rowview.Row["megjelenes_eve"].ToString());
                cmd.Parameters.AddWithValue("@hasznalat_helye", rowview.Row["hasznalat_helye"].ToString());
                cmd.Parameters.AddWithValue("@hasznalat_eve", rowview.Row["hasznalat_eve"].ToString());
                cmd.Parameters.AddWithValue("@szlengtipus", rowview.Row["szlengtipus"].ToString());
                cmd.Parameters.AddWithValue("@nyelv", rowview.Row["nyelv"].ToString());
                cmd.Parameters.AddWithValue("@publikacio_tipusa", rowview.Row["publikacio_tipusa"].ToString());
                cmd.Parameters.AddWithValue("@adatkozles_formaja", rowview.Row["adatkozles_formaja"].ToString());
                cmd.Parameters.AddWithValue("@publikacio_temeja", rowview.Row["publikacio_temeja"].ToString());
                cmd.Parameters.AddWithValue("@publikacio_celja", rowview.Row["publikacio_celja"].ToString());

                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadRefreshDgrReadWrite();

        }

        private void Btn_1_1_2Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Txtbx1_1_1szerzo.Text = "";
            this.Txtbx1_1_2kiadaseve.Text = "";
            this.Txtbx1_1_3konyvcim.Text = "";
            this.Txtbx1_1_4parhuzamoscim.Text = "";
            this.Txtbx1_1_5alcim.Text = "";
            this.Txtbx1_1_6kotetszam.Text = "";
            this.Txtbx1_1_7kiadasszam.Text = "";
            this.Txtbx1_1_8sorozat.Text = "";
            this.Cmbbx1_1_9mujelleg.SelectedItem = null;
            this.Txtbx1_1_10kiadashelye.Text = "";
            this.Txtbx1_1_11kiado.Text = "";
            this.Txtbx1_1_12lapokszama.Text = "";
        }

        private void Btn_1_2_2Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Txtbx1_2_1.Text = "";
            this.Txtbx1_2_2.Text = "";
            this.Txtbx1_2_3.Text = "";
            this.Txtbx1_2_4.Text = "";
            this.Txtbx1_2_5.Text = "";
            this.Txtbx1_2_6.Text = "";
            this.Txtbx1_2_7.Text = "";
            this.Txtbx1_2_8.Text = "";
            this.Txtbx1_2_9.Text = "";
            this.Txtbx1_2_10.Text = "";
            this.Txtbx1_2_11.Text = "";
            this.Cmbbx1_2_1.SelectedItem = null;

        }

        private void Btn_1_3_2Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Txtbx1_3_1.Text = "";
            this.Txtbx1_3_2.Text = "";
            this.Txtbx1_3_3.Text = "";
            this.Txtbx1_3_4.Text = "";
            this.Txtbx1_3_5.Text = "";
            this.Txtbx1_3_6.Text = "";
            this.Txtbx1_3_7.Text = "";
            this.Txtbx1_3_8.Text = "";
            this.Txtbx1_3_9.Text = "";
            this.Txtbx1_3_10.Text = "";
            this.Txtbx1_3_11.Text = "";
            this.Txtbx1_3_12.Text = "";
            this.Txtbx1_3_13.Text = "";
            this.Txtbx1_3_14.Text = "";
            this.Txtbx1_3_15.Text = "";
            this.Cmbbx1_3_1.SelectedItem = null;

        }

        private void Btn_1_4_2Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Txtbx1_4_1.Text = "";
            this.Txtbx1_4_2.Text = "";
            this.Txtbx1_4_3.Text = "";
            this.Txtbx1_4_4.Text = "";
            this.Txtbx1_4_5.Text = "";
            this.Txtbx1_4_6.Text = "";
            this.Txtbx1_4_7.Text = "";
            this.Txtbx1_4_8.Text = "";
            this.Txtbx1_4_9.Text = "";
        }

        private void Btn_1_5_2Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Txtbx1_5_1.Text = "";
            this.Txtbx1_5_2.Text = "";
            this.Txtbx1_5_3.Text = "";
            this.Txtbx1_5_4.Text = "";
            this.Txtbx1_5_5.Text = "";
            this.Txtbx1_5_6.Text = "";
            this.Txtbx1_5_7.Text = "";
            this.Txtbx1_5_8.Text = "";
            this.Txtbx1_5_9.Text = "";
            this.Txtbx1_5_10.Text = "";
        }

        private void DgrReadWrite_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            this.needUpdate = true;
        }



        private void DgrReadWrite_UpdateMySQL()
        {
            String connStr = this.service.ConnectionString;
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            DataRowView rowview = DgrReadWrite.SelectedItem as DataRowView;

            try
            {
                connection.Open();
                cmd.Connection = connection;

                cmd.CommandText = "UPDATE `adat` SET `teljes_szoveg`=@teljes_szoveg,`megjelenes_eve`=@megjelenes_eve,`hasznalat_helye`=@hasznalat_helye,`hasznalat_eve`=@hasznalat_eve,`szlengtipus`=@szlengtipus,`nyelv`=@nyelv,`publikacio_tipusa`= @publikacio_tipusa,`adatkozles_formaja`=@adatkozles_formaja,`publikacio_temeja`=@publikacio_temeja,`publikacio_celja`= @publikacio_celja WHERE `index` =" + rowview.Row["index"].ToString();
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@teljes_szoveg", rowview.Row["teljes_szoveg"].ToString());
                cmd.Parameters.AddWithValue("@megjelenes_eve", rowview.Row["megjelenes_eve"].ToString());
                cmd.Parameters.AddWithValue("@hasznalat_helye", rowview.Row["hasznalat_helye"].ToString());
                cmd.Parameters.AddWithValue("@hasznalat_eve", rowview.Row["hasznalat_eve"].ToString());
                cmd.Parameters.AddWithValue("@szlengtipus", rowview.Row["szlengtipus"].ToString());
                cmd.Parameters.AddWithValue("@nyelv", rowview.Row["nyelv"].ToString());
                cmd.Parameters.AddWithValue("@publikacio_tipusa", rowview.Row["publikacio_tipusa"].ToString());
                cmd.Parameters.AddWithValue("@adatkozles_formaja", rowview.Row["adatkozles_formaja"].ToString());
                cmd.Parameters.AddWithValue("@publikacio_temeja", rowview.Row["publikacio_temeja"].ToString());
                cmd.Parameters.AddWithValue("@publikacio_celja", rowview.Row["publikacio_celja"].ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("A(z) " + rowview.Row["index"].ToString() + "-os indexű rekord frissítve!");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Hiba " + ex.Number + ": " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DgrReadWrite_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.needUpdate)
            {
                this.needUpdate = false;
                DgrReadWrite_UpdateMySQL();
            }
        }

        private void AddHotKeys()
        {
            try
            {
                RoutedCommand firstSettings = new RoutedCommand();
                firstSettings.InputGestures.Add(new KeyGesture(Key.I, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(firstSettings, PasteItalic));

                RoutedCommand secondSettings = new RoutedCommand();
                secondSettings.InputGestures.Add(new KeyGesture(Key.I, ModifierKeys.Control));
                CommandBindings.Add(new CommandBinding(secondSettings, ChangeToItalic));

                RoutedCommand thirdSettings = new RoutedCommand();
                thirdSettings.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(thirdSettings, PasteBold));

                RoutedCommand fourthSettings = new RoutedCommand();
                fourthSettings.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Control));
                CommandBindings.Add(new CommandBinding(fourthSettings, ChangeToBold));

                RoutedCommand fifthSettings = new RoutedCommand();
                fifthSettings.InputGestures.Add(new KeyGesture(Key.Subtract, ModifierKeys.Control | ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(fifthSettings, PasteLongDash));

                RoutedCommand sixthSettings = new RoutedCommand();
                sixthSettings.InputGestures.Add(new KeyGesture(Key.Subtract, ModifierKeys.Control));
                CommandBindings.Add(new CommandBinding(sixthSettings, PasteMediumDash));

                RoutedCommand seventhSettings = new RoutedCommand();
                seventhSettings.InputGestures.Add(new KeyGesture(Key.U, ModifierKeys.Control));
                CommandBindings.Add(new CommandBinding(seventhSettings, ChangeToUnderlined));

                RoutedCommand eigthSettings = new RoutedCommand();
                eigthSettings.InputGestures.Add(new KeyGesture(Key.U, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(eigthSettings, PasteUnderlined));

                RoutedCommand ninethSettings = new RoutedCommand();
                ninethSettings.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Control));
                CommandBindings.Add(new CommandBinding(ninethSettings, ChangeToSup));

                RoutedCommand tenthSettings = new RoutedCommand();
                tenthSettings.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(tenthSettings, PasteSup));

                RoutedCommand eleventhSettings = new RoutedCommand();
                eleventhSettings.InputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
                CommandBindings.Add(new CommandBinding(eleventhSettings, ChangeToSub));

                RoutedCommand twelthSettings = new RoutedCommand();
                twelthSettings.InputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(twelthSettings, PasteSub));

                RoutedCommand thirteenthSettings = new RoutedCommand();
                thirteenthSettings.InputGestures.Add(new KeyGesture(Key.F1));
                CommandBindings.Add(new CommandBinding(thirteenthSettings, this.service.Hotkeys));

                RoutedCommand fourteenthSettings = new RoutedCommand();
                fourteenthSettings.InputGestures.Add(new KeyGesture(Key.F2));
                CommandBindings.Add(new CommandBinding(fourteenthSettings, this.service.Login));

                RoutedCommand fifteenthSettings = new RoutedCommand();
                fifteenthSettings.InputGestures.Add(new KeyGesture(Key.F3));
                CommandBindings.Add(new CommandBinding(fifteenthSettings, this.service.About));

                RoutedCommand sixteenthSettings = new RoutedCommand();
                sixteenthSettings.InputGestures.Add(new KeyGesture(Key.F5));
                CommandBindings.Add(new CommandBinding(sixteenthSettings, this.service.Web));
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba a gyorsbillentyű beállításoknál: " + err.Message.ToString());
            }
        }

        private void PasteLongDash(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                int i = currentTextBox.CaretIndex;
                currentTextBox.Text = currentTextBox.Text.Insert(currentTextBox.CaretIndex, "—");
                currentTextBox.CaretIndex = i + 1;
            }
        }

        private void PasteMediumDash(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                int i = currentTextBox.CaretIndex;
                currentTextBox.Text = currentTextBox.Text.Insert(currentTextBox.CaretIndex, "–");
                currentTextBox.CaretIndex = i + 1;
            }
        }


        private void PasteItalic(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                int i = currentTextBox.CaretIndex;
                String ins1 = "<em>";
                String ins2 = "</em>";
                currentTextBox.Text = currentTextBox.Text.Insert(currentTextBox.CaretIndex, ins1 + ins2);
                currentTextBox.CaretIndex = i + ins1.Length;
            }
        }

        private void PasteBold(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                int i = currentTextBox.CaretIndex;
                String ins1 = "<strong>";
                String ins2 = "</strong>";
                currentTextBox.Text = currentTextBox.Text.Insert(currentTextBox.CaretIndex, ins1 + ins2);
                currentTextBox.CaretIndex = i + ins1.Length;
            }
        }

        private void PasteUnderlined(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                int i = currentTextBox.CaretIndex;
                String ins1 = "<u>";
                String ins2 = "</u>";
                currentTextBox.Text = currentTextBox.Text.Insert(currentTextBox.CaretIndex, ins1 + ins2);
                currentTextBox.CaretIndex = i + ins1.Length;
            }
        }

        private void PasteSub(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                int i = currentTextBox.CaretIndex;
                String ins1 = "<sub>";
                String ins2 = "</sub>";
                currentTextBox.Text = currentTextBox.Text.Insert(currentTextBox.CaretIndex, ins1 + ins2);
                currentTextBox.CaretIndex = i + ins1.Length;
            }
        }

        private void PasteSup(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                int i = currentTextBox.CaretIndex;
                String ins1 = "<sup>";
                String ins2 = "</sup>";
                currentTextBox.Text = currentTextBox.Text.Insert(currentTextBox.CaretIndex, ins1 + ins2);
                currentTextBox.CaretIndex = i + ins1.Length;
            }
        }

        private void ChangeToItalic(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                currentTextBox.SelectedText = "<em>" + currentTextBox.SelectedText + "</em>";
            }
        }

        private void ChangeToBold(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                currentTextBox.SelectedText = "<strong>" + currentTextBox.SelectedText + "</strong>";
            }
        }

        private void ChangeToUnderlined(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                currentTextBox.SelectedText = "<u>" + currentTextBox.SelectedText + "</u>";
            }
        }

        private void ChangeToSup(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                currentTextBox.SelectedText = "<sup>" + currentTextBox.SelectedText + "</sup>";
            }
        }

        private void ChangeToSub(object sender, RoutedEventArgs e)
        {
            if (this.service.CurrentTextbox != null)
            {
                TextBox currentTextBox = this.service.CurrentTextbox;
                currentTextBox.SelectedText = "<sub>" + currentTextBox.SelectedText + "</sub>";
            }
        }

        private void MenuItemHotkey_Click(object sender, RoutedEventArgs e)
        {
            this.service.Hotkeys(sender, e);
        }

        private void CmbbxFillMySQL()
        {
            string connStr = this.service.ConnectionString;
            string sql = "SELECT mujelleg FROM onmu_mujelleg";
            try
            {
                DataTable _dt = new DataTable();
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand cmdSel = new MySqlCommand(sql, connection);
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmdSel);
                da3.Fill(_dt);

                List<String> mujellegek = new List<String>();
                Cmbbx1_1_9mujelleg.Items.Clear();

                foreach (DataRow _dr in _dt.Rows)
                {
                    mujellegek.Add(_dr["mujelleg"].ToString());
                }
                mujellegek.Sort();

                foreach (String mujelleg in mujellegek)
                {
                    Cmbbx1_1_9mujelleg.Items.Add(mujelleg);
                }

                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            // 2. lap
            //
            // cmbbx


            sql = "SELECT mujelleg FROM szerkkonyv_mujelleg";
            try
            {
                DataTable _dt = new DataTable();
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand cmdSel = new MySqlCommand(sql, connection);

                MySqlDataAdapter da3 = new MySqlDataAdapter(cmdSel);
                da3.Fill(_dt);

                Cmbbx1_2_1.Items.Clear();

                List<String> mujellegek = new List<string>();
                foreach (DataRow _dr in _dt.Rows)
                {
                    mujellegek.Add(_dr["mujelleg"].ToString());
                }
                mujellegek.Sort();

                foreach (String mujelleg in mujellegek)
                {
                    Cmbbx1_2_1.Items.Add(mujelleg);
                }
                connection.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // 3. lap
            //
            // cmbbx


            sql = "SELECT mujelleg FROM cikkkonyvkonyvreszl_mujelleg";
            try
            {
                DataTable _dt = new DataTable();
                MySqlConnection connection = new MySqlConnection(connStr);
                MySqlCommand cmdSel = new MySqlCommand(sql, connection);

                MySqlDataAdapter da3 = new MySqlDataAdapter(cmdSel);
                da3.Fill(_dt);
                Cmbbx1_3_1.Items.Clear();


                List<String> mujellegek = new List<string>();
                foreach (DataRow _dr in _dt.Rows)
                {
                    mujellegek.Add(_dr["mujelleg"].ToString());
                }
                mujellegek.Sort();

                foreach (String mujelleg in mujellegek)
                {
                    Cmbbx1_3_1.Items.Add(mujelleg);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_1_1_3Connect_Click(object sender, RoutedEventArgs e)
        {
            CmbbxFillMySQL();
        }

        private void Btn_CmbbxBov3_Click(object sender, RoutedEventArgs e)
        {
            String connStr = this.service.ConnectionString;
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO cikkkonyvkonyvreszl_mujelleg VALUES (NULL, @ertek)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ertek", Txtbx_cmbbxbox3.Text);
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                CmbbxFillMySQL();
                MessageBox.Show("Menü sikeresen bővítve!", "Feltöltve!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_CmbbxBov1_Click(object sender, RoutedEventArgs e)
        {
            String connStr = this.service.ConnectionString;
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO onmu_mujelleg VALUES (NULL, @ertek)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ertek", Txtbx_cmbbxbov1.Text);
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                CmbbxFillMySQL();
                MessageBox.Show("Menü sikeresen bővítve!", "Feltöltve!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_CmbbxBov2_Click(object sender, RoutedEventArgs e)
        {
            String connStr = this.service.ConnectionString;
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO szerkkonyv_mujelleg VALUES (NULL, @ertek)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ertek", Txtbx_cmbbxbov2.Text);
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                CmbbxFillMySQL();
                MessageBox.Show("Menü sikeresen bővítve!", "Feltöltve!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void DefaultConnectionFromFile() {

            if (File.Exists("adatb-kapcs.adb"))
            {

                ConnectionArrayList conns = new ConnectionArrayList();
                //Open the file written above and read values from it.
                Stream stream = File.Open("adatb-kapcs.adb", FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();

                conns = (ConnectionArrayList)bformatter.Deserialize(stream);
                stream.Close();
                
                foreach (Connection con in conns.Conns)
                {
                    if (con.IsDefault) {
                        this.service = Service.getInstance();
                        service.ConnectionString = "server=" +
                           con.Url + ";user=" +
                           con.Username + ";database=tkis;port=3306;password=" +
                           con.Password + ";Charset=utf8;"
                           ;
                        CmbbxFillMySQL();
                    }
                }

            }

        }



    }



}

