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
        private Service service;
        public WizardPage2(String initString)
        {
            InitializeComponent();
            this.initString = initString;
            this.service = Service.getInstance();
            AddHotKeys();
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
                str = str + @"<em>URL: </em><a href=""" + Txtbx2_1_5.Text + @""">" + Txtbx2_1_5.Text + "</a>" + "<br />";

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
    }
}
