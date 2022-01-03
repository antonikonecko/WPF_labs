using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        string b64_encrypted_data;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (tb_text.Text != String.Empty && pb_password.Password != String.Empty)
            {
                string password = pb_password.Password;
                string data_to_encrypt = tb_text.Text;

                byte[] salt = new byte[128 / 8];
                using var rng = RandomNumberGenerator.Create();
                {
                    // Fill the array with a random value.
                    rng.GetBytes(salt);
                }
                int myIterations = 1000;

                Rfc2898DeriveBytes key = new(password, salt, myIterations);

                // Encrypt the data.
                Aes encAlg = Aes.Create();
                encAlg.Key = key.GetBytes(16);

                MemoryStream encryptionStream = new MemoryStream();
                CryptoStream encrypt = new CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] bytes = new UTF8Encoding(false).GetBytes(data_to_encrypt);

                encrypt.Write(bytes, 0, bytes.Length);
                encrypt.FlushFinalBlock();
                encrypt.Close();

                byte[] encrypted_data = encryptionStream.ToArray();
                b64_encrypted_data = Convert.ToBase64String(encrypted_data);
                tb_encrypted.Text = b64_encrypted_data;
                key.Reset();
            }
            else
            {                
                b64_encrypted_data = String.Empty;
                tb_encrypted.Text = b64_encrypted_data;
                MessageBox.Show("Podaj hasło i/lub tekst!");
            }               
            
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if(b64_encrypted_data != String.Empty)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                if (savefile.ShowDialog() ?? true)
                    using (StreamWriter writer = new StreamWriter(savefile.FileName))
                    {
                        writer.WriteLine(b64_encrypted_data);
                    }
            }
            else 
                MessageBox.Show("Najpierw zaszyfruj tekst!");
        }
    }
}



