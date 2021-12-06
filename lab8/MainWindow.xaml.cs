using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Lotnisko 
    {
        [Index(0)]
        public string miasto { get; set; }
        [Index(1)]
        public string wojewodztwo { get; set; }
        [Index(2)]
        public string icao { get; set; }
        [Index(3)]
        public string iata { get; set; }
        [Index(4)]
        public string nazwa { get; set; }
        [Index(5)]
        public string liczba_p { get; set; }
        [Index(6)]
        public string zmiana { get; set; }
        
    }

    
    public partial class MainWindow : Window
    {
        public IEnumerable<Lotnisko> Lotniska;
        List<Lotnisko> lista_lotnisk = new ();
        public MainWindow()
        {
            InitializeComponent();          

            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\data\\Test_Data.csv"));            
            using (var reader = new StreamReader(path, Encoding.UTF8))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Lotniska = csv.GetRecords<Lotnisko>();
                lista_lotnisk = Lotniska.ToList();
            }
            foreach (var l in lista_lotnisk)
            {
                listbox.Items.Add(l.nazwa);
            }                     
                        
        }             


        private void btn_szczegoly_Click(object sender, RoutedEventArgs e)
        {
            Details details = new();
            details.ShowDialog();
        }

        private void cb_miasto_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_wojewodztwo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_pasazerowie_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_IATA_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_ICAO_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
