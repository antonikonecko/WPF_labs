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
            int level = cb_Level.SelectedIndex + 3;            
            string animal = cb_Animal.Text;
            GameWindow gameWindow = new(level, animal);
            gameWindow.Show();     
        }        
    }
}
