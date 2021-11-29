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

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Czytelnik> czytelnikList;
        List<Ksiazka> ksiazkaList;

        public MainWindow()
        {
            InitializeComponent();

            czytelnikList = new List<Czytelnik>();
            ksiazkaList = new List<Ksiazka>();            
            lvCzytelnicy.ItemsSource = czytelnikList;
            lvKsiazki.ItemsSource = ksiazkaList;   
        }

        private void SampleCzytelnikBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            InitializeComponent();
            czytelnikList.Add(new Czytelnik() { Imie = "Imie 1", Nazwisko = "Nazwisko 1" });
            czytelnikList.Add(new Czytelnik() { Imie = "Imie 2", Nazwisko = "Nazwisko 2" });
            czytelnikList.Add(new Czytelnik() { Imie = "Imie 3", Nazwisko = "Nazwisko 3" });

            lvCzytelnicy.Items.Refresh();
        }
        private void SampleKsiazkaBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            InitializeComponent();
            ksiazkaList.Add(new Ksiazka() { Tytul = "Tytuł 1", Autor = "Autor 1", ID = "ID 1", Wypozyczona = "Wypozyczona 1" });
            ksiazkaList.Add(new Ksiazka() { Tytul = "Tytuł 2", Autor = "Autor 2", ID = "ID 2", Wypozyczona = "Wypozyczona 2" });
            ksiazkaList.Add(new Ksiazka() { Tytul = "Tytuł 3", Autor = "Autor 3", ID = "ID 3", Wypozyczona = "Wypozyczona 3" });

            lvKsiazki.Items.Refresh();
        }

        private void WypozyczBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OddajBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodajCzytelnikBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodajKsiazkaBtn_Click(object sender, RoutedEventArgs e)
        {

        }


    }




    class Czytelnik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string ID { get; set; }

        public Czytelnik() { }
        public Czytelnik(string Imie, string Nazwisko, string ID)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.ID = ID;
        }
    }


    class Ksiazka
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string ID { get; set; }
        public string Wypozyczona { get; set; }

        public Ksiazka() { }
        public Ksiazka(string Tytul, string Autor, string ID, string Wypozyczona) 
        {
            this.Tytul = Tytul;
            this.Autor = Autor;
            this.ID = ID;
            this.Wypozyczona = Wypozyczona;
        }
    }


}
