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

namespace lab2
{
    /// <summary>
    /// Logika interakcji dla klasy SilnikWindow.xaml
    /// </summary>
    public partial class SilnikWindow : Window
    {

        public int cena = 0;
        public int moc = 0;
        public SilnikWindow(int cena)
        {
            InitializeComponent();
            this.cena = cena;
            lbl_Silnik.Content = cena + moc;
        }

        private void BenzynaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 10000;
            lbl_Silnik.Content = cena + moc;
        }

        private void GazRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 10000;
            lbl_Silnik.Content = cena + moc;
        }

        private void DieselRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 12000;
            lbl_Silnik.Content = cena + moc;
        }

        private void HybrydaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 70000;
            lbl_Silnik.Content = cena + moc;
        }
        private void ElektrykRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 100000;
            lbl_Silnik.Content = cena + moc;
        }
        private void BenzynaRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 10000;
            lbl_Silnik.Content = cena + moc;
        }

        private void GazRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 10000;
            lbl_Silnik.Content = cena + moc;
        }

        private void DieselRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 12000;
            lbl_Silnik.Content = cena + moc;
        }

        private void HybrydaRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 70000;
            lbl_Silnik.Content = cena + moc;
        }
        private void ElektrykRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 100000;
            lbl_Silnik.Content = cena + moc;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbx_moc.SelectedIndex != 0)
            {
                moc = 20000 * cbx_moc.SelectedIndex;
                lbl_Silnik.Content = cena + moc;
            }

        }
    }
}

