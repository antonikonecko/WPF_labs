using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


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
        public IEnumerable<Lotnisko> Lotniska { get; set; }
        List<Lotnisko> lista_lotnisk = new ();       
        List <CheckBox> checked_checkbox_list = new List<CheckBox>();

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
            listbox.ItemsSource = lista_lotnisk;           
        }


        private void btn_szczegoly_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedIndex == -1 )
                MessageBox.Show("Nie wybrano lotniska!");
            else if (listbox.SelectedIndex > -1)
            {
                List<string> checkedCheckboxes = new();
                foreach (CheckBox checkbox in this.grid.Children.OfType<CheckBox>())
                {
                    if (checkbox.IsChecked == false)
                    {
                        if (checkedCheckboxes.Any())
                        {
                            foreach (string item in checkedCheckboxes)
                            {
                                if (item.Contains(checkbox.Name))
                                    checkedCheckboxes.Remove(item);
                            }
                        }
                    }
                    else if (checkbox.IsChecked == true) 
                    {
                        checkedCheckboxes.Add(checkbox.Name);                        
                    }
                    
                }               
                Details details = new(checkedCheckboxes, (Lotnisko)listbox.SelectedItem);
                details.ShowDialog();
                checkedCheckboxes.Clear();
            }                      

        }
    }
}
