using Microsoft.Win32;
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

namespace lab5
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

        static readonly int kmer_length = 4;
        private Sequence seq;
        private void load_seq_btn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.InitialDirectory = "c:\\";
            openfiledialog.Filter = "fasta files (*.fasta)|*.fasta|txt files (*.txt)|*.txt|all files (*.*)|*.*";
            openfiledialog.RestoreDirectory = true;

            bool? userClickedOK = openfiledialog.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                filePath = openfiledialog.FileName;
                // {Binding} .Clear();
                string inputseq = System.IO.File.ReadAllText(filePath);
                seq = new Sequence(inputseq);
                seq_txtbox.Text = seq.Get_sequence();
                subseq_count_txtbox.Text = seq.Get_count().ToString();
            }
        }

        private void find_pattern_btn_Click(object sender, RoutedEventArgs e)
        {

            seq.PatternFind(kmer_length);
        }

        private void cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
