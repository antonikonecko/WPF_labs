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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int  cena = 0;
        public bool boolmarka = false;
        public bool boolsilnik = false;
        public MainWindow()
        {
            InitializeComponent();
            lbl1.Content = this.cena;

        }
        private void check_Bool()
        {
            if (boolmarka && boolsilnik) { lbl1.Foreground = Brushes.Green;}
            else if (boolmarka || boolsilnik) { lbl1.Foreground = Brushes.Yellow;}            
            else {lbl1.Foreground = Brushes.Red;}
        }

        private void btn_marka_Click(object sender, RoutedEventArgs e)
        {
            MarkaWindow markaWindow = new(cena);
            markaWindow.ShowDialog();
            cena = markaWindow.cena + markaWindow.polisa;
            lbl1.Content = cena;
            if (cena != 0) { boolmarka = true; }
            check_Bool();
            
        }

        private void btn_silnik_Click(object sender, RoutedEventArgs e)
        {
            SilnikWindow silnikWindow = new(cena);
            silnikWindow.ShowDialog();
            cena = silnikWindow.cena + silnikWindow.moc;
            lbl1.Content = cena;
            if (cena != 0) { boolsilnik = true; }
            check_Bool();
        }

    }
}
