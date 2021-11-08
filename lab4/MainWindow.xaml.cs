using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab4
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

        private bool myBool;

        private void Btn_choose_Click(object sender, RoutedEventArgs e)
        {
           
            var filePath = string.Empty;

            //OpenFileDialog openFileDialog = new OpenFileDialog();            
            //openFileDialog.InitialDirectory = "c:\\";
            //openFileDialog.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            //openFileDialog.ShowDialog();
            //openFileDialog.FilterIndex = 2;
            //openFileDialog.RestoreDirectory = true;                             
            //filePath = openFileDialog.FileName;
            filePath = "C:/Users/Antek/Documents/duck.bmp";
            ImageSource imageSource = new BitmapImage(new Uri(filePath));
            img.Source = imageSource;
        }

        private void Btn_A_Click(object sender, RoutedEventArgs e)
        {
            myBool = !myBool;
            int flip;
            if (myBool)
            {
                flip = -1;
            }
            else
            {
                flip = 1;
            }
            img.RenderTransformOrigin = new Point(0.5, 0.5);
            img.RenderTransform = new ScaleTransform() { ScaleX = flip };
        }

        private void Btn_B_Click(object sender, RoutedEventArgs e)
        {
            RotateTransform rotateTransform = new RotateTransform(90);
            img.RenderTransformOrigin = new Point(0.5, 0.5);
            img.RenderTransform = rotateTransform;
        }

        private void Btn_C_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_D_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
