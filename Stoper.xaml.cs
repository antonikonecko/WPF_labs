using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;


namespace lab1
{
    public partial class Stoper : Window
    {
        
        private DispatcherTimer timer = new DispatcherTimer();
        DateTime x = new DateTime();
        public Stoper()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(stoper_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            lblStoper.Content = "00:00:00";          

        }
        
        private void stoper_Tick(object sender, EventArgs e)
        {
            x = x.AddSeconds(1);
            lblStoper.Content = x.ToString("HH:mm:ss");
        }        

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
           timer.Stop();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            x = new DateTime();
            lblStoper.Content = "00:00:00";

        }

    }
}