﻿using System;
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
using System.Windows.Shapes;

namespace lab7
{
    /// <summary>
    /// Logika interakcji dla klasy AddBook.xaml
    //private void AddBookBtn_Click(object sender, RoutedEventArgs e)
    //{

    //}
    /// </summary>
    public partial class AddBookWindow : Window
    {
        
        public AddBookWindow()
        {
            InitializeComponent();
        }
        

        private bool TextNotEmpty()
        {
            if (TextBoxTytul.Text !="" && TextBoxAutor.Text !="" )
            {
                return true;
            }
            else return false;
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (TextNotEmpty())
            {
                ((MainWindow)this.Owner).ksiazkaCollection.Add(new Ksiazka()
                {
                    Tytul = TextBoxTytul.Text,
                    Autor = TextBoxAutor.Text,
                    KsiazkaID = ((MainWindow)this.Owner).GuidEncodeBase64(),
                    Wypozyczona = ""                        
                });
                TextBoxTytul.Text = "";
                TextBoxAutor.Text = "";
                
            }            
            
        }
    }
}
