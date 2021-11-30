using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
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
using System.Xml.Serialization;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public ObservableCollection<Ksiazka> ksiazkaCollection;
        public ObservableCollection<Czytelnik> czytelnikCollection;
        
        public ObservableCollection<Ksiazka> dostepne_ksiazki;
        public ObservableCollection<Ksiazka> wypozyczone_ksiazki;
        public MainWindow()
        {
            InitializeComponent();

            ksiazkaCollection = new();
            czytelnikCollection = new();
            wypozyczone_ksiazki = new();
            dostepne_ksiazki = new();
            CollectionViewSource ksiazkaCollectionViewSource;
            ksiazkaCollectionViewSource = (CollectionViewSource)(FindResource("KsiazkaCollectionViewSource"));
            ksiazkaCollectionViewSource.Source = ksiazkaCollection ;

            CollectionViewSource czytelnikCollectionViewSource;
            czytelnikCollectionViewSource = (CollectionViewSource)(FindResource("CzytelnikCollectionViewSource"));
            czytelnikCollectionViewSource.Source = czytelnikCollection;

            string default_K_File;
            string default_C_File;
            default_K_File = ConfigurationManager.AppSettings.Get("recent_K_data");
            default_C_File = ConfigurationManager.AppSettings.Get("recent_C_data");
            if (default_C_File != "" && default_K_File != "")
            {
                MessageBox.Show("import poprzednich plikow");
                importXmlK(default_K_File);
                importXmlC(default_C_File);
            }
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
            ksiazkaCollection.Add(new Ksiazka() { Tytul = "Tytuł Ksiazki 1", Autor = "Imie Nazwisko 1", KsiazkaID = "ID 1", Wypozyczona = "" });
            ksiazkaCollection.Add(new Ksiazka() { Tytul = "Tytuł Ksiazki 2", Autor = "Imie Nazwisko 2", KsiazkaID = "ID 2", Wypozyczona = "" });
            ksiazkaCollection.Add(new Ksiazka() { Tytul = "Tytuł Ksiazki 3", Autor = "Imie Nazwisko 3", KsiazkaID = "ID 3", Wypozyczona = "" });
        }

        private void WypozyczBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(Ksiazka k in ksiazkaCollection)
            {
                if (k.Wypozyczona == ""){ dostepne_ksiazki.Add(k); }
            }
            
            WypozyczWindow wypozyczWindow = new(czytelnikCollection, dostepne_ksiazki);
            wypozyczWindow.Owner = this;
            wypozyczWindow.ShowDialog();
            dostepne_ksiazki.Clear();
            dgKsiazki.Items.Refresh();
        }
                


        private void OddajBtn_Click(object sender, RoutedEventArgs e)
        {

            OddajWindow oddajWindow = new(wypozyczone_ksiazki);
            oddajWindow.Owner = this;
            oddajWindow.ShowDialog();            
            dgKsiazki.Items.Refresh();
        }


        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        
        private void importXmlK(string inputfile)
        {
            using (var reader = new StreamReader(inputfile))
            {
                XmlSerializer deserializerK = new XmlSerializer(ksiazkaCollection.GetType());
                ksiazkaCollection = (ObservableCollection<Ksiazka>)deserializerK.Deserialize(reader);

            }
            AddUpdateAppSettings("recent_K_data", inputfile);
        }
        private void importXmlC(string inputfile)
        {
            using (var reader = new StreamReader(inputfile))
            {
                XmlSerializer deserializerC = new XmlSerializer(czytelnikCollection.GetType());
                czytelnikCollection = (ObservableCollection<Czytelnik>)deserializerC.Deserialize(reader);

            }
            AddUpdateAppSettings("recent_C_data", inputfile);
        }

        public void SaveXml(ObservableCollection<Ksiazka> ksiazki, ObservableCollection<Czytelnik> czytelnicy)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (savefile.ShowDialog() ?? true)
            {
                XmlSerializer serializerK = new XmlSerializer(ksiazki.GetType());
                XmlSerializer serializerC = new XmlSerializer(czytelnicy.GetType());

                string K_filename = savefile.FileName + "K" ;
                string C_filename = savefile.FileName + "C" ;
                MessageBox.Show(C_filename);
                using (Stream s = File.Create(C_filename))
                {
                    serializerC.Serialize(s, czytelnicy);
                }
                using (Stream s = File.Create(K_filename))
                {
                    serializerK.Serialize(s, ksiazki);                    
                }
                AddUpdateAppSettings("recent_K_data", K_filename);
                AddUpdateAppSettings("recent_C_data", C_filename);
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Zapisać dane?", "Zamykanie programu", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {  
                SaveXml(ksiazkaCollection, czytelnikCollection);                
                MessageBox.Show("Koniec");
            }
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
        public string Wypozyczona { get; set; }

        public Ksiazka() { }
        public Ksiazka(string Tytul, string Autor, string KsiazkaID)
        {
            this.Tytul = Tytul;
            this.Autor = Autor;
            this.KsiazkaID = KsiazkaID;
            
        }
    }


}
