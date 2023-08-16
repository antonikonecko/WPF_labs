using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int start = 0;
        int indexOfSearchText = 0;
        static readonly int kmer_length = 4;
        private Sequence seq;
        public Dictionary<string, int> SequenceDict = new Dictionary<string, int>();

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
                string inputseq = System.IO.File.ReadAllText(filePath);
                seq = new Sequence(inputseq);
                rich.Document.Blocks.Add(new Paragraph(new Run(seq.Get_sequence())));
            }
        }

        private void find_pattern_btn_Click(object sender, RoutedEventArgs e)
        {

            Dictionary<string, int> SequenceDict = seq.PatternFind(kmer_length);
            foreach (KeyValuePair<string, int> kvp in SequenceDict)
            {
                subseq_count_txtbox.Text += kvp.Key + ": " + kvp.Value + "\n";
                cbox.Items.Add(kvp.Key);
            }

        }

        private void cbox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rich.Document.ContentStart, rich.Document.ContentEnd);

            //clear up highlighted text before starting a new search
            textRange.ClearAllProperties();
            

            //get the richtextbox text
            string textBoxText = textRange.Text;

            //get search text
            //string searchText = "AAC"; //searchTextBox.Text;
            string searchText = (string)cbox.SelectedValue;          
                       

            //using regex to get the search count
            //this will include search word even it is part of another word
            //say we are searching "hi" in "hi, how are you Mahi?" --> match count will be 2 (hi in 'Mahi' also)

            Regex regex = new Regex(searchText);
            int count_MatchFound = Regex.Matches(textBoxText, regex.ToString()).Count;

            for (TextPointer startPointer = rich.Document.ContentStart;
                        startPointer.CompareTo(rich.Document.ContentEnd) <= 0;
                            startPointer = startPointer.GetNextContextPosition(LogicalDirection.Forward))
            {
                //check if end of text
                if (startPointer.CompareTo(rich.Document.ContentEnd) == 0)
                {
                    break;
                }

                //get the adjacent string
                string parsedString = startPointer.GetTextInRun(LogicalDirection.Forward);

                //check if the search string present here
                int indexOfParseString = parsedString.IndexOf(searchText);

                if (indexOfParseString >= 0) //present
                {
                    //setting up the pointer here at this matched index
                    startPointer = startPointer.GetPositionAtOffset(indexOfParseString);

                    if (startPointer != null)
                    {
                        //next pointer will be the length of the search string
                        TextPointer nextPointer = startPointer.GetPositionAtOffset(searchText.Length);

                        //create the text range
                        TextRange searchedTextRange = new TextRange(startPointer, nextPointer);

                        //color up 
                        searchedTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Green));

                        //add other setting property

                    }
                }
            }              
            
        }
    }  
}
