using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///     
     
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int flip = 1;        
        int angleValue;
        string filePath = string.Empty;
        
        /// <summary>
        /// Takes a bitmap and converts it to an image that can be handled by WPF ImageBrush
        /// </summary>
        /// <param name="src">A bitmap image</param>
        /// <returns>The image as a BitmapImage for WPF</returns>
        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }       


        private void Btn_choose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.InitialDirectory = "c:\\";
            openfiledialog.Filter = "bmp files (*.bmp)|*.bmp|all files (*.*)|*.*";
            //openfiledialog.ShowDialog();           
            openfiledialog.RestoreDirectory = true;

            bool? userClickedOK = openfiledialog.ShowDialog();
            
            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                filePath = openfiledialog.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(filePath));
                img.Source = imageSource;
            }           
           
        }

        private void Btn_A_Click(object sender, RoutedEventArgs e)
        {            
            flip *= -1;
            img.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            img.RenderTransform = new ScaleTransform() { ScaleX = flip };
        }

        private void Btn_B_Click(object sender, RoutedEventArgs e)
        {
            angleValue += 90;

            img.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            img.RenderTransform = new RotateTransform() { Angle = angleValue };
        }

        private void Btn_C_Click(object sender, EventArgs e)
        {
            if (filePath != null)
            {
                try
                {                   
                    Bitmap imageC = new Bitmap(filePath);

                    for (int i = 0; i < imageC.Width; i++)
                        for (int j = 0; j < imageC.Height; j++)
                        {                            
                            System.Drawing.Color C1 = imageC.GetPixel(i, j);
                            int r2 = 0;
                            int g2 = C1.G;
                            int b2 = 0;
                            imageC.SetPixel(i, j, System.Drawing.Color.FromArgb(r2, g2, b2));

                           
                        }
                    BitmapImage green_image = Convert(imageC);
                    img.Source = green_image;
                }
                catch (Exception )
                {                    
                    throw;
                }
            }
                       
        }

        private void Btn_D_Click(object sender, RoutedEventArgs e)
        {
            if (filePath != null)
            {
                try
                {
                    // Retrieve the image.
                    var imageD = new Bitmap(filePath, true);

                    int x, y;

                    // Loop through the images pixels to reset color.
                    for (x = 0; x < imageD.Width; x++)
                    {
                        for (y = 0; y < imageD.Height; y++)
                        {
                            System.Drawing.Color pixelColor = imageD.GetPixel(x, y);
                            System.Drawing.Color newColor = System.Drawing.Color.FromArgb(0xff - pixelColor.R
                            , 0xff - pixelColor.G, 0xff - pixelColor.B);
                            imageD.SetPixel(x, y, newColor);
                        }

                    }
                    BitmapImage negative_image = Convert(imageD);
                    img.Source = negative_image;
                }
                catch (Exception)
                {
                    throw;
                }

            }
                     
        }        

    }
}
