using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace lab10
{
 
    public class MusicFile
    {
        public string Title { get; set; }
        public string Path { get; set; }

    }

    public partial class MainWindow : Window
    {
        public MediaPlayer mediaPlayer;
        public ObservableCollection<MusicFile> Musiclist;
        public bool paused = false;
        public MainWindow()
        {
            InitializeComponent();
            mediaPlayer = new();
            Musiclist = new ObservableCollection<MusicFile>();
            lv_Music_list.ItemsSource = Musiclist;
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            if (paused == false)
            {
                if (Musiclist != null)
                {
                    if (lv_Music_list.SelectedIndex == -1)
                    {
                        lv_Music_list.SelectedIndex = 0;
                    }
                    var current_song = lv_Music_list.SelectedItem as MusicFile;

                    mediaPlayer.Open(new Uri(current_song.Path));
                    mediaPlayer.Play();


                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += timer_Tick;
                    timer.Start();
                }
            }
            else if(paused == true)
            {
                mediaPlayer.Play();
                paused = false;
            }
                        
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "No file selected...";
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            paused = true;
        }
        

        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            paused = false;
        }

        private void btn_AddFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Audio files (*.wav, *.mp3, *.wma, *.ogg, *.flac) | *.wav; *.mp3; *.wma; *.ogg; *.flac";
            var result = dialog.ShowDialog();
            if (result == true)
            {                
                Musiclist.Add(new MusicFile { Path = dialog.FileName, Title = dialog.SafeFileName });
            }
        }

        private void btn_AddFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {                 
                    var files = Directory.EnumerateFiles(dialog.SelectedPath, "*.*", SearchOption.AllDirectories)
                                  .Where(f => f.EndsWith(".wav") || f.EndsWith(".mp3") || f.EndsWith(".wma") || f.EndsWith(".ogg") || f.EndsWith(".flac"));

                    foreach (string file in files)
                    {
                        Musiclist.Add(new MusicFile { Path = file, Title = System.IO.Path.GetFileName(file) });                        
                    }                    
                }
            }
        }
    }
}
