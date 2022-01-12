using System.Windows;

namespace lab12
{
   
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ((GameWindow)this.Owner).Close();
        }

        private void btn_again_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
            ((GameWindow)this.Owner).timer.Start();
        }
    }
}
