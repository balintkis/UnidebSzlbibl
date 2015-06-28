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
    /// Interaction logic for HTMLPreviewWindow.xaml
    /// </summary>
    public partial class HTMLPreviewWindow : Window
    {
        private String webPage;
        public HTMLPreviewWindow(String webPage)
        {
            InitializeComponent();
            this.webPage = webPage;
            WbBrwsrPreview.NavigateToString(this.webPage);
        }
    }
}
