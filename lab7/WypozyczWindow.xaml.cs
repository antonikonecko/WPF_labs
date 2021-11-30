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
    /// Logika interakcji dla klasy WypozyczWindow.xaml
    /// </summary>
    public partial class WypozyczWindow : Window
    {
        ObservableCollection<Ksiazka> dostepne_ksiazki;
        ObservableCollection<Czytelnik> lista_czytelnikow;
        public WypozyczWindow(ObservableCollection<Czytelnik> lista_czytelnikow, ObservableCollection<Ksiazka> dostepne_ksiazki)
        {
            
            InitializeComponent();
            this.DataContext = this;
            this.lista_czytelnikow = lista_czytelnikow;
            this.dostepne_ksiazki = dostepne_ksiazki;

            foreach(Ksiazka ks in dostepne_ksiazki)
            {
                cbox_ksiazka.Items.Add(ks.KsiazkaID);
            }

            foreach (Czytelnik cz in lista_czytelnikow) 
            {
                cbox_czytelnik.Items.Add(cz.CzytelnikID); 
            }           
            
        }

        private void WypozyczBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach( Ksiazka ks in ((MainWindow)this.Owner).ksiazkaCollection)
            {
                if(ks.Wypozyczona == "" && ks.KsiazkaID == (string)cbox_ksiazka.SelectedValue) 
                { 
                    ks.Wypozyczona = (string)cbox_czytelnik.SelectedValue;                    
                }
            }
            this.Close();
        }
    }
}
