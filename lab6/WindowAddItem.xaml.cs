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

namespace lab6
{

    public partial class WindowAddItem : Window
    {
        public bool ChkTextChanged;
        public WindowAddItem()
        {
            InitializeComponent();
        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChkTextChanged = true;
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (ChkTextChanged)
            {
                if (TextBoxName.Text != "")
                {

                    ((ListViewGridViewSample)this.Owner).ProductsList.Add(new Product()
                    {
                        Name = TextBoxName.Text,
                        ID = Guid.NewGuid().ToString(),
                        Count = ((ListViewGridViewSample)this.Owner).ProductsList.Count + 1
                    });
                    TextBoxName.Text = "";
                }
            }
            ((ListViewGridViewSample)this.Owner).lvProducts.Items.Refresh();
        }
    }
}
