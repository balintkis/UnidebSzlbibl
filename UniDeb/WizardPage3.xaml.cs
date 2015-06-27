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

        public WizardPage3(String initString)
        {
            InitializeComponent();
            this.initString = initString;
        }
    }
}
