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

namespace lab12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
               

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            
            int level = cb_Level.SelectedIndex + 3;            
            string animal = cb_Animal.Text;                   
                        
            Grid DynamicGrid = new Grid();            

            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Stretch;
            DynamicGrid.ShowGridLines = false;                   

            List<Button> btn_list = new();

            for (int c = 0; c < level; c++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                DynamicGrid.ColumnDefinitions.Add(gridCol);

                for (int r = 0; r < level; r++)
                {
                    RowDefinition gridRow = new RowDefinition();
                    DynamicGrid.RowDefinitions.Add(gridRow);

                    Button btn = new Button();
                    btn.Name = "Button" + r + c;
                    btn.Content = "" + r + "." + c;
                    btn.Background = new SolidColorBrush(Colors.LightGray);
                    Grid.SetRow(btn, r);
                    Grid.SetColumn(btn, c);
                    DynamicGrid.Children.Add(btn);
                }
            }           

            var win2 = new Window();                
            win2.Content = DynamicGrid;
            win2.ShowDialog();
            this.Close();
        }
    }
}
