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

namespace lab7
{
    /// <summary>
    /// Logika interakcji dla klasy AddReader.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        public AddReaderWindow()
        {
            InitializeComponent();
        }
        

        private bool TextNotEmpty()
        {
            if (TextBoxImie.Text != "" && TextBoxNazwisko.Text != "" )
            {
                return true;
            }
            else return false;
        }

        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {

            if (TextNotEmpty())
            {

                ((MainWindow)this.Owner).czytelnikCollection.Add(new Czytelnik()
                {
                    Imie = TextBoxImie.Text,
                    Nazwisko = TextBoxNazwisko.Text,
                    CzytelnikID = ((MainWindow)this.Owner).GuidEncodeBase64(),
                    

                });
                TextBoxImie.Text = "";
                TextBoxNazwisko.Text = "";              
                

            }

            
        }
        
        
    }
}
