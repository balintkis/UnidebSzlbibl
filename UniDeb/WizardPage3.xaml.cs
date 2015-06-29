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
        private String initString;
        private String egybenString;
        private String[] mezok = new String[10];

        public WizardPage3(String initString)
        {
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
                    + Txtbx3_1_1.Text + "$"
                    + Txtbx3_1_2.Text + "$"
                    + Txtbx3_1_3.Text + "$"
                    + Txtbx3_1_4.Text + "$"
                    + Txtbx3_1_5.Text + "$"
                    + Txtbx3_1_6.Text + "$"
                    + Txtbx3_1_7.Text + "$"
                    + Txtbx3_1_8.Text + "$"
                    + Txtbx3_1_9.Text + "$";

            mezok[1] = Txtbx3_1_1.Text;
            mezok[2] = Txtbx3_1_2.Text;
            mezok[3] = Txtbx3_1_3.Text;
            mezok[4] = Txtbx3_1_4.Text;
            mezok[5] = Txtbx3_1_5.Text;
            mezok[6] = Txtbx3_1_6.Text;
            mezok[7] = Txtbx3_1_7.Text;
            mezok[8] = Txtbx3_1_8.Text;
            mezok[9] = Txtbx3_1_9.Text;
        }

        private void BtnHTMLPreview_Click(object sender, RoutedEventArgs e)
        {
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

        }
    }
}
