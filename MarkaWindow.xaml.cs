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
    /// Logika interakcji dla klasy markaWindow.xaml
    /// </summary>
    public partial class MarkaWindow : Window
    {
<<<<<<< HEAD
        public int cena;
        public int polisa;
        public MarkaWindow(int cena)
        {
            InitializeComponent();
            this.cena = cena;
            lbl_cena.Content = cena + polisa;
        }

        private void AstonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 700000;
            lbl_cena.Content = cena + polisa;
        }

        private void AlfaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 400000;
            lbl_cena.Content = cena + polisa;
        }

        private void BMWRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cena += 300000;
            lbl_cena.Content = cena + polisa;
        }

        private void AstonRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 700000;
            lbl_cena.Content = cena + polisa;
        }

        private void AlfaRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 400000;
            lbl_cena.Content = cena + polisa;
        }

        private void BMWRadioButto_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 300000;
            lbl_cena.Content = cena + polisa;
        }

        private void Hamulce_Checked(object sender, RoutedEventArgs e)
        {
            cena += 20000;
            lbl_cena.Content = cena + polisa;
        }

        private void Zawieszenie_Checked(object sender, RoutedEventArgs e)
        {
            cena += 10000;
            lbl_cena.Content = cena + polisa;
        }

        private void Wydech_Checked(object sender, RoutedEventArgs e)
        {
            cena += 8000;
            lbl_cena.Content = cena + polisa;
        }

        private void Fotele_Checked(object sender, RoutedEventArgs e)
        {
            cena += 15000;
            lbl_cena.Content = cena + polisa;
        }
       
        private void Hamulce_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 20000;
            lbl_cena.Content = cena + polisa;
        }

        private void Zawieszenie_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 10000;
            lbl_cena.Content = cena + polisa;
        }

        private void Wydech_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 8000;
            lbl_cena.Content = cena + polisa;
        }

        private void Fotele_Unchecked(object sender, RoutedEventArgs e)
        {
            cena -= 15000;
            lbl_cena.Content = cena + polisa;
        }

        private void tbox_polisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(tbox_polisa.Text, out polisa))
            {
                polisa = 0;                
            }
            lbl_cena.Content = cena + polisa;
=======
        public int cena = 0;
        
       
        public MarkaWindow()
        {
            InitializeComponent();
>>>>>>> 9fc8a22c95e790cf0dbf627b1ca910818cff28e1
        }
    }
}
