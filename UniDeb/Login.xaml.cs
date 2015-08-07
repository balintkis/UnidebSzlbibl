using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Service service = null;
        private ConnectionArrayList connections;
        public Login()
        {
            InitializeComponent();
            this.connections = new ConnectionArrayList();
            RestoreFromFile();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBxConnectionSelector.SelectedItem != null)
            {
                foreach (Connection con in this.connections.Conns) {
                    con.IsDefault = false;
                }

                ((Connection)this.cmbBxConnectionSelector.SelectedItem).IsDefault = true;
                this.service = Service.getInstance();
                service.ConnectionString = "server=" +
                    ((Connection)this.cmbBxConnectionSelector.SelectedItem).Url + ";user=" +
                    ((Connection)this.cmbBxConnectionSelector.SelectedItem).Username + ";database=tkis;port=3306;password=" +
                    ((Connection)this.cmbBxConnectionSelector.SelectedItem).Password + ";Charset=utf8;"
                    ;
                SaveToFile();
                this.Close();
            }
            else
                MessageBox.Show("Először válasszon egy csatlakozási lehetőséget a legördülő menüből!", "Nincs kapcsolat kiválasztva", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RefreshCmbbx()
        {
            cmbBxConnectionSelector.Items.Clear();
            foreach (Connection conn in this.connections.Conns)
            {
                cmbBxConnectionSelector.Items.Add(conn);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Connection con = new Connection((this.connections.Conns.Count + 1) + "", false, TxtbxUrl.Text, TxtbxUsername.Text, TxtbxPassword.Text);
            connections.Conns.Add(con);
            SaveToFile();
            RefreshCmbbx();
        }

        private void SaveToFile()
        {
            Stream stream = File.Open("adatb-kapcs.adb", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this.connections);
            stream.Close();
        }

        private void RestoreFromFile()
        {

            if (File.Exists("adatb-kapcs.adb"))
            {
                //Clear mp for further usage.
                this.connections = null;

                //Open the file written above and read values from it.
                Stream stream = File.Open("adatb-kapcs.adb", FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();

                this.connections = (ConnectionArrayList)bformatter.Deserialize(stream);
                stream.Close();
                RefreshCmbbx();
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            if (cmbBxConnectionSelector.SelectedItem != null)
            {
                this.connections.Conns.Remove((Connection)cmbBxConnectionSelector.SelectedItem);
                RefreshCmbbx();
                SaveToFile();
            }
            else
                MessageBox.Show("Először válasszon egy csatlakozási lehetőséget a legördülő menüből!", "Nincs kapcsolat kiválasztva", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}

