using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace lab12
{   
    public partial class GameWindow : Window
    {
        public string animal;
        public int level;
        public List<Button> btn_list;
        public bool lucky_btn_clicked = false;
        public int luckyButton;
        public DispatcherTimer timer;
        public GameWindow(int level, string animal)
        {
            InitializeComponent();
            this.animal = animal;
            this.level = level;
            this.Height = level * 100 + 30;
            this.Width = level * 100 + 10;

            CreateGrid();

            luckyButton = GetLuckyButton(btn_list.Count);            
            btn_list[luckyButton].Click += new RoutedEventHandler(Lucky_button_Click);

            ////// SHOW LUCKY BUTTON
            //btn_list[luckyButton].Background = new SolidColorBrush(Colors.SteelBlue); 

            StartTimer();
        }

        public void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void CreateGrid()
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.ShowGridLines = false;
            btn_list = new();

            for (int c = 0; c < level; c++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Width = new GridLength(100);
                DynamicGrid.ColumnDefinitions.Add(gridCol);

                for (int r = 0; r < level; r++)
                {
                    RowDefinition gridRow = new RowDefinition();
                    gridRow.Height = new GridLength(100);
                    //gridRow.Height = new GridLength(1, GridUnitType.Star);
                    DynamicGrid.RowDefinitions.Add(gridRow);

                    Button btn = new Button();
                    btn.Name = "Button" + r + c;
                    //btn.Content = "" + r + "." + c;
                    //btn.Background = new SolidColorBrush(Colors.LightGray);
                    Grid.SetRow(btn, r);
                    Grid.SetColumn(btn, c);
                    DynamicGrid.Children.Add(btn);
                    btn_list.Add(btn);
                }
            }
            this.Content = DynamicGrid;
        }

        int GetLuckyButton(int size)
        {
            Random rnd = new Random();
            int random_button = rnd.Next(0, (size - 1));
            return random_button;
        }

        public static bool CrocoBool()
        {
            Random random = new Random();
            var n = random.Next(0, 2);
            return n == 0;            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (lucky_btn_clicked == true && CrocoBool() && animal == "Croco")
            {
                timer.Stop();
                ResultWindow resultWindow = new ResultWindow();
                resultWindow.Owner = this;
                resultWindow.label.Content = "You caught Croco! But it killed You!";
                resultWindow.btn_return.Margin = new Thickness(0, 25, 0, 0);
                resultWindow.btn_again.Visibility = Visibility.Collapsed;
                resultWindow.ShowDialog();                
            }               

            else if (lucky_btn_clicked == true)
            {
                timer.Stop();
                ResultWindow resultWindow = new ResultWindow();
                resultWindow.Owner = this;
                resultWindow.label.Content = $"You caught {animal}!";
                resultWindow.btn_return.Margin = new Thickness(0, 25, 0, 0);
                resultWindow.btn_again.Visibility = Visibility.Collapsed;
                resultWindow.ShowDialog();                
            }

            else
            {
                timer.Stop();
                ResultWindow resultWindow = new ResultWindow();
                resultWindow.Owner = this;
                resultWindow.label.Content = $"Wasted! {animal} is safe.";            
                resultWindow.ShowDialog();  
            }               
        }

        private void Lucky_button_Click(object sender, EventArgs e)
        {
            btn_list[luckyButton].Visibility = Visibility.Collapsed;
            lucky_btn_clicked = true;
        }
    }
}
