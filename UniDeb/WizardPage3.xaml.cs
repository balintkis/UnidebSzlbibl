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
        private WizardPage2 wiz2;

        public WizardPage3(String initString, WizardPage2 wiz2)
        {
            this.service = Service.getInstance();
            InitializeComponent();
            mezok[0] = initString;
            this.initString = initString;
            this.wiz2 = wiz2;
            AddHotKeys();
        }

        private void BtnPreview_Click(object sender, RoutedEventArgs e)
        {
            Strngesites();
            TxtbxPreview.Text = this.egybenString;

        }

        private void StrngesitesFromPreview()
        {
            String temp = TxtbxPreview.Text;
            this.mezok = temp.Split('$');
        }

        private void Strngesites()
        {
            mezok[0] = "" + this.initString;
            this.egybenString = this.initString + "$";

            mezok[1] = "" + Txtbx3_1_2.Text;
            this.egybenString += Txtbx3_1_2.Text + "$";

            if (Cmbbx3_1_3helye.SelectedValue != null)
            {
                this.egybenString += Cmbbx3_1_3helye.SelectedValue.ToString() + "$";
                mezok[2] = Cmbbx3_1_3helye.SelectedValue.ToString();
            }
            else
            {
                mezok[2] = "";
                this.egybenString += "$";
            }

            this.egybenString += Txtbx3_1_4.Text + "$";
            mezok[3] = "" + Txtbx3_1_4.Text;

            if (Cmbbx3_1_5szlengtipus.SelectedValue != null)
            {
                this.egybenString += Cmbbx3_1_5szlengtipus.SelectedValue.ToString() + "$";
                mezok[4] = Cmbbx3_1_5szlengtipus.SelectedValue.ToString();
            }
            else
            {
                mezok[4] = "";
                this.egybenString += "$";
            }


            if (Cmbbx3_1_6nyelv.SelectedValue != null)
            {
                this.egybenString += Cmbbx3_1_6nyelv.SelectedValue.ToString() + "$";
                mezok[5] = Cmbbx3_1_6nyelv.SelectedValue.ToString();
            }
            else
            {
                mezok[5] = "";
                this.egybenString += "$";
            }

            if (Cmbbx3_1_7publikacio_fajt.SelectedValue != null)
            {
                this.egybenString += Cmbbx3_1_7publikacio_fajt.SelectedValue.ToString() + "$";
                mezok[6] = Cmbbx3_1_7publikacio_fajt.SelectedValue.ToString();
            }
            else
            {
                mezok[6] = "";
                this.egybenString += "$";
            }

            if (Cmbbx3_1_8adatkozl_forma.SelectedValue != null)
            {
                this.egybenString += Cmbbx3_1_8adatkozl_forma.SelectedValue.ToString() + "$";
                mezok[7] = Cmbbx3_1_8adatkozl_forma.SelectedValue.ToString();
            }
            else
            {
                mezok[7] = "";
                this.egybenString += "$";
            }

            if (Cmbbx3_1_9publikacio_tema.SelectedValue != null)
            {
                this.egybenString += Cmbbx3_1_9publikacio_tema.SelectedValue.ToString() + "$";
                mezok[8] = Cmbbx3_1_9publikacio_tema.SelectedValue.ToString();
            }
            else
            {
                mezok[8] = "";
                this.egybenString += "$";
            }

            if (Cmbbx3_1_10publikacio_celja.SelectedValue != null)
            {
                this.egybenString += Cmbbx3_1_10publikacio_celja.SelectedValue.ToString() + "$";
                mezok[9] = Cmbbx3_1_10publikacio_celja.SelectedValue.ToString();
            }
            else
            {
                mezok[9] = "";
                this.egybenString += "$";
            }
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
                MessageBox.Show("Rekord sikeresen hozzáadva!", "Feltöltve!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.wiz2.Close();
                this.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Hiba a gyorsbillentyű beállításánál: " + err.Message.ToString());
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

        private void BtnUploadFromPreview_Click(object sender, RoutedEventArgs e)
        {
            StrngesitesFromPreview();

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
                MessageBox.Show("Rekord sikeresen hozzáadva!", "Feltöltve!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.wiz2.Close();
                this.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                foreach (var item in Cmbbx3_1_10publikacio_celja.Items)
                {
                    String connStr = this.service.ConnectionString;
                    MySqlConnection connection = new MySqlConnection(connStr);
                    MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO publikaciocelja VALUES(NULL, @jelleg)";
                    cmd.Prepare();
                    String temp = item.ToString().Substring("System.Windows.Controls.ComboBoxItem: ".Length);
                    cmd.Parameters.AddWithValue("@jelleg", temp);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Rekordok sikeresen hozzáadva!", "Feltöltve!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
