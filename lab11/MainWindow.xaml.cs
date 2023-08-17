using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        string b64_encrypted_data;        
        byte[] aes_iv;
        int myIterations = 1000000;
        byte[] salt2;       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (tb_text.Text != String.Empty && ValidatePassword(pb_password.Password))
            {
                string password = pb_password.Password;
                string data_to_encrypt = tb_text.Text;

                byte[] salt = new byte[128 / 8];
                using var rng = RandomNumberGenerator.Create();
                {
                    // Fill the array with a random value.
                    rng.GetBytes(salt);
                }
                salt2 = salt;
                Rfc2898DeriveBytes PBKDF2_key = new(password, salt, myIterations);                
                            
                
                // Encrypt the data.
                Aes encAlg = Aes.Create();
                encAlg.Key = PBKDF2_key.GetBytes(32);                
                MemoryStream encryptionStream = new MemoryStream();
                CryptoStream encrypt = new CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] bytes = new UTF8Encoding(false).GetBytes(data_to_encrypt);                
                encrypt.Write(bytes, 0, bytes.Length);
                encrypt.FlushFinalBlock();
                encrypt.Close();               
                byte[] encrypted_data = encryptionStream.ToArray();

                b64_encrypted_data = Convert.ToBase64String(encrypted_data);
                tb_encrypted.Text = b64_encrypted_data;
               
                //string hex_key = BitConverter.ToString(encAlg.Key);
                //string hex_iv = BitConverter.ToString(encAlg.IV);
                //tb_key.Text = hex_key;
                //tb_iv.Text = hex_iv;
                
                aes_iv = encAlg.IV;
                PBKDF2_key.Reset();
                pb_password.Clear();
            }
            else
            {
                pb_password.Clear();
                b64_encrypted_data = String.Empty;                
                tb_encrypted.Text = b64_encrypted_data;
                MessageBox.Show("Podaj hasło i/lub tekst!");
            }                           
        }
        private void btn_decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pb_password.Password))
            {
                pb_password.Clear();
                MessageBox.Show("Wpisz hasło");
            }
            else
            {
                Rfc2898DeriveBytes PBKDF2_key2 = new(pb_password.Password, salt2, myIterations);
               
                pb_password.Clear();
                Aes decAlg = Aes.Create();
                decAlg.IV = aes_iv;
                decAlg.Key = PBKDF2_key2.GetBytes(32);

                byte[] encrypted_data = Convert.FromBase64String(b64_encrypted_data);
                MemoryStream decryptionStreamBacking = new MemoryStream();
                CryptoStream decrypt = new CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write);
                decrypt.Write(encrypted_data, 0, encrypted_data.Length);
                decrypt.Flush();
                decrypt.Close();
                string decrypted_data = new UTF8Encoding(false).GetString(decryptionStreamBacking.ToArray());
                tb_decrypted.Text = decrypted_data;
                PBKDF2_key2.Reset();
                
            }         
        }

        private bool ValidatePassword(string password)
        {

            var input = password;            

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain at least one lower case letter.");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain at least one upper case letter.");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Password should not be lesser than 8 characters.");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                MessageBox.Show("Password should contain at least one numeric value.");
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                MessageBox.Show("Password should contain at least one special case character.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if(b64_encrypted_data != String.Empty)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "Text Files | *.txt";
                savefile.DefaultExt = "txt";
                if (savefile.ShowDialog() ?? true)
                    using (StreamWriter writer = new StreamWriter(savefile.FileName))
                    {
                        writer.WriteLine(b64_encrypted_data);
                    }
                MessageBox.Show("Zapisano");
            }
            else 
                MessageBox.Show("Najpierw zaszyfruj tekst!");
        }        
    }
}



