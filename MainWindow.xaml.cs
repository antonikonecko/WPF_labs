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
        public int cena = 0;
        public MainWindow()
        {
            InitializeComponent();
            lbl1.Content = this.cena;

        }

        private void btn_marka_Click(object sender, RoutedEventArgs e)
        {
            MarkaWindow markaWindow = new();
            markaWindow.Show();
        }

        private void btn_silnik_Click(object sender, RoutedEventArgs e)
        {
            SilnikWindow silnikWindow = new();
            silnikWindow.Show();
        }
    }
}
