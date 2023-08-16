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
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public List<Product> products = new List<Product>();
        public List<Product> searchProducts = new List<Product>();
        public SearchWindow(List<Product> Products)
        {
            this.products = Products;
            InitializeComponent();
            lvProducts.ItemsSource = products;
            lvProducts.Items.Refresh();
        }


        //save search result
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lvProducts.ItemsSource == products)
            {
                ((ListViewGridViewSample)this.Owner).SaveXml(products);
            }
            else if (lvProducts.ItemsSource == searchProducts)
            {
                ((ListViewGridViewSample)this.Owner).SaveXml(searchProducts);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTxt.Text != "")
            {
                searchProducts.Clear();
                int value;
                bool numeric = int.TryParse(SearchTxt.Text, out value);
                List<Product> temp_product = new List<Product>();
                lvProducts.ItemsSource = searchProducts;
                lvProducts.Items.Refresh();
                foreach (Product product in products)
                {
                    if((numeric && product.Count == value) || (!numeric && product.Name.Contains(SearchTxt.Text)))
                    {                        
                        temp_product.Add(product);
                    }
                }
                var linq = temp_product.Except(searchProducts);
                searchProducts.AddRange(linq);
                lvProducts.Items.Refresh();
            }
            else if (SearchTxt.Text == "")
            {
                searchProducts.Clear();
                lvProducts.ItemsSource = products;
                lvProducts.Items.Refresh();
            }

        }


    }


}
