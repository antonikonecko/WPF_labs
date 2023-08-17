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
using System.Windows.Threading;

namespace lab1
{
    public partial class Timer : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public Timer()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void bstoper_Click_1(object sender, RoutedEventArgs e)
        {
            Stoper window = new Stoper();
            window.Show();
        }
    }
}