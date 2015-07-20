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
    /// Interaction logic for WizardPage2.xaml
    /// </summary>
    public partial class WizardPage2 : Window
    {

        private String initString;

        public WizardPage2(String initString)
        {
            InitializeComponent();
            this.initString = initString;
        }

        private void Btn_1_5_1Continue_Click(object sender, RoutedEventArgs e)
        {

            String str = this.initString + "<br />";
            if (Txtbx2_1_1.Text != "")
                str = str + Txtbx2_1_1.Text + "<br />";

            if (Txtbx2_1_2.Text != "")
                str = str + "<em>Kül.: </em>" + Txtbx2_1_2.Text + "<br />";

            if (Txtbx2_1_3.Text != "")
                str = str + "<em>Megtalálható: </em>" + Txtbx2_1_3.Text + "<br />";

            if (Txtbx2_1_4.Text != "")
                str = str + "<em>Rezümé: </em>" + Txtbx2_1_4.Text + "<br />";

            if (Txtbx2_1_5.Text != "")
                str = str + @"<em>URL: </em><a href=""" + Txtbx2_1_5.Text + @""">" + Txtbx2_1_5.Text + "</a>";

            if (Txtbx2_1_6.Text != "")
                str = str + "<em>Közzéteszi: </em>" + Txtbx2_1_6.Text + "<br />";

            if (Txtbx2_1_7.Text != "")
                str = str + "<em>Különlenyomat: </em>" + Txtbx2_1_7.Text + "<br />";

            if (Txtbx2_1_8.Text != "")
                str = str + "<em>Eredeti közlése: </em>" + Txtbx2_1_8.Text + "<br />";           

            if (Txtbx2_1_9.Text != "")
                str = str + "<em>Változatlan kiadása: </em>" + Txtbx2_1_9.Text + "<br />";

            if (Txtbx2_1_10.Text != "")
                str = str + "<em>Újraközlése: </em>" + Txtbx2_1_10.Text + "<br />";

            if (Txtbx2_1_11.Text != "")
                str = str + "<em>Első kiadása: </em>" + Txtbx2_1_11.Text + "<br />";

            if (Txtbx2_1_12.Text != "")
                str = str + "<em>Újabb kiadása: </em>" + Txtbx2_1_12.Text + "<br />";

            if (Txtbx2_1_13.Text != "")
                str = str + "<em>Idézi: </em>" + Txtbx2_1_13.Text + "<br />";

            if (Txtbx2_1_14.Text != "")
                str = str + "<em>Hivatkozik rá: </em>" + Txtbx2_1_14.Text + "<br />";

            if (Txtbx2_1_15.Text != "")
                str = str + "<em>Ismerteti: </em>" + Txtbx2_1_15.Text + "<br />";

            if (Txtbx2_1_16.Text != "")
                str = str + "<em>Ajánlja: </em>" + Txtbx2_1_16.Text + "<br />";
            
            if (Txtbx2_1_17.Text != "")
                str = str + "<em>Előzménye: </em>" + Txtbx2_1_17.Text + "<br />";

            if (Txtbx2_1_18.Text != "")
                str = str + "<em>Válaszol rá: </em>" + Txtbx2_1_18.Text + "<br />";
            

            WizardPage3 wiz3 = new WizardPage3(str);
            wiz3.Show();

            this.Close();
        }
    }
}
