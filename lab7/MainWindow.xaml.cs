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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public ObservableCollection<Ksiazka> ksiazkaCollection;
        public ObservableCollection<Czytelnik> czytelnikCollection;
        public MainWindow()
        {
            InitializeComponent();

            ksiazkaCollection = new();
            czytelnikCollection = new();
            
            CollectionViewSource ksiazkaCollectionViewSource;
            ksiazkaCollectionViewSource = (CollectionViewSource)(FindResource("KsiazkaCollectionViewSource"));
            ksiazkaCollectionViewSource.Source = ksiazkaCollection ;

            CollectionViewSource czytelnikCollectionViewSource;
            czytelnikCollectionViewSource = (CollectionViewSource)(FindResource("CzytelnikCollectionViewSource"));
            czytelnikCollectionViewSource.Source = czytelnikCollection;
        }
         
        private void SampleCzytelnikBtn_Click(object sender, RoutedEventArgs e)
        {            
            InitializeComponent();
            czytelnikCollection.Add(new Czytelnik() { Imie = "Imie 1", Nazwisko = "Nazwisko 1", CzytelnikID = "ID 1" });
            czytelnikCollection.Add(new Czytelnik() { Imie = "Imie 2", Nazwisko = "Nazwisko 2", CzytelnikID = "ID 2" });
            czytelnikCollection.Add(new Czytelnik() { Imie = "Imie 3", Nazwisko = "Nazwisko 3", CzytelnikID = "ID 3" });
        }
        private void SampleKsiazkaBtn_Click(object sender, RoutedEventArgs e)
        {            
            InitializeComponent();
            ksiazkaCollection.Add(new Ksiazka() { Tytul = "Tytuł Ksiazki 1", Autor = "Imie Nazwisko 1", KsiazkaID = "ID 1", Wypozyczona = false });
            ksiazkaCollection.Add(new Ksiazka() { Tytul = "Tytuł Ksiazki 2", Autor = "Imie Nazwisko 2", KsiazkaID = "ID 2", Wypozyczona = false });
            ksiazkaCollection.Add(new Ksiazka() { Tytul = "Tytuł Ksiazki 3", Autor = "Imie Nazwisko 3", KsiazkaID = "ID 3", Wypozyczona = false });
        }

        private void WypozyczBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OddajBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodajCzytelnikBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReaderWindow addReaderWindow = new();
            addReaderWindow.Owner = this;
            addReaderWindow.ShowDialog();
        }

        private void DodajKsiazkaBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new();
            addBookWindow.Owner = this;
            addBookWindow.ShowDialog();
        }


    }




    public class Czytelnik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string CzytelnikID { get; set; }

        public Czytelnik() { }
        public Czytelnik(string Imie, string Nazwisko, string CzytelnikID)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.CzytelnikID = CzytelnikID;
        }
    }


    public class Ksiazka
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string KsiazkaID { get; set; }
        public bool Wypozyczona { get; set; }

        public Ksiazka() { }
        public Ksiazka(string Tytul, string Autor, string KsiazkaID)
        {
            this.Tytul = Tytul;
            this.Autor = Autor;
            this.KsiazkaID = KsiazkaID;
            
        }
    }


}
