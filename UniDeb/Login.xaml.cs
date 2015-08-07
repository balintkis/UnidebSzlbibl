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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Service service = null;
        public Login()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            this.service = Service.getInstance();
            service.ConnectionString = "server=" +
                TxtbxUrl.Text + ";user=" +
                TxtbxUsername.Text + ";database=tkis;port=3306;password=" +
                TxtbxPassword.Text + ";Charset=utf8;"
                ;
            this.Close();
        }
    }
}
