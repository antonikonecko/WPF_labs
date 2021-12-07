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

namespace lab8
{
    /// <summary>
    /// Logika interakcji dla klasy details.xaml
    /// </summary>
    public partial class Details : Window
    {
        List<string> checkbox_list;
        Lotnisko lotnisko;
        public Details(List<string>checkbox_list, Lotnisko lotnisko)
        {
            InitializeComponent();
            this.checkbox_list = checkbox_list;
            this.lotnisko = lotnisko;

            nazwa_lotniskaTextBlock.Text = lotnisko.nazwa;

            foreach (var checkbox in checkbox_list)
            {
                if (checkbox == "cb_ICAO")
                {
                    write_details($"Kod ICAO:  {lotnisko.icao.ToString()}");
                }
                if (checkbox == "cb_IATA")
                {
                    write_details($"Kod IATA:  {lotnisko.iata.ToString()}");
                }
                if (checkbox == "cb_pasazerowie")
                {
                    write_details($"Liczba pasażerów:  {lotnisko.liczba_p.ToString()}");
                }
                if (checkbox == "cb_wojewodztwo")
                {
                    write_details($"Województwo:  {lotnisko.wojewodztwo.ToString()}");                    
                }
                if (checkbox == "cb_miasto")
                {
                    write_details($"Miasto:  {lotnisko.miasto.ToString()}");
                }               
            }

        }


        void write_details(string output)
        {
            if (!string.IsNullOrWhiteSpace(detailsTextBox.Text))
            {
               detailsTextBox.AppendText("\r\n" + output);
            }
            else
            {
                detailsTextBox.AppendText(output);
            }
        }
        private void btn_zamknij_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
