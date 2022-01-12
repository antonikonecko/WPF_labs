using System.Windows;
using System.Windows.Threading;

namespace lab12
{
    
    public partial class MainWindow : Window
    {        
        
        public MainWindow()
        {
            InitializeComponent();
        }            
        
        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {            
            int level = cb_Level.SelectedIndex;            
            string animal = cb_Animal.Text;
            if (animal != string.Empty && level != -1)
            {
                GameWindow gameWindow = new(level + 3, animal);
                gameWindow.Show();
            }
            else
            {
                MessageBox.Show("Select animal and level!", "Error!");
            }

        }        
    }
}
