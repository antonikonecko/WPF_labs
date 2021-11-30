using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lab7
{
    /// <summary>
    /// Logika interakcji dla klasy OddajWindow.xaml
    /// </summary>
    public partial class OddajWindow : Window
    {
        ObservableCollection<Ksiazka> wyp_ksiazki;
        public OddajWindow(ObservableCollection<Ksiazka> wyp_ksiazki)
        {
            InitializeComponent();
            this.DataContext = this;
            this.wyp_ksiazki = wyp_ksiazki;
            foreach (Ksiazka ks in wyp_ksiazki)
            {
                cbox_wypozyczone.Items.Add(ks.KsiazkaID);
            }
        }


        private void OddajBtn_Click(object sender, RoutedEventArgs e)
        {

            foreach (Ksiazka ks in ((MainWindow)this.Owner).ksiazkaCollection)
            {
                if (ks.Wypozyczona != "" && ks.KsiazkaID == (string)cbox_wypozyczone.SelectedValue)
                {
                    ks.Wypozyczona = "";                    
                }
            }
            this.Close();
        }

        private void cbox_wypozyczone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Ksiazka ks in ((MainWindow)this.Owner).ksiazkaCollection)
            {
                if (ks.Wypozyczona != "" && ks.KsiazkaID == (string)cbox_wypozyczone.SelectedValue)
                {
                    ((MainWindow)this.Owner).dgKsiazki.SelectedItem = ks;
                }
            }
        }
    }
}
