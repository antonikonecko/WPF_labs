using lab9;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace lab9
{
    public class Container
    {
        public Studies Studies { get; set; }
        public ObservableCollection<Student> Students_List  { get; set; }
        public Thesis Thesis   { get; set; }
    }
    public class Studies : INotifyPropertyChanged
    {
        private string _University;
        private string _Subject;
        private string _Study_Field;
        private string _Study_Profile;
        private string _Study_Form;
        private string _Study_Level;
        public string University
        {
            get
            {
                return _University;
            }
            set
            {
                _University = "Politechnika Poznańska";                
            }
        }
        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }
        public string Study_Field
        {
            get
            {
                return _Study_Field;
            }
            set
            {
                _Study_Field = value;
                OnPropertyChanged(nameof(Study_Field));
            }
        }        
        public string Study_Profile
        {
            get
            {
                return _Study_Profile;
            }
            set
            {
                _Study_Profile = value;
                OnPropertyChanged(nameof(Study_Profile));
            }
        }        
        public string Study_Form 
        {
            get
            {
                return _Study_Form;
            }
            set
            {
                _Study_Form = value;
                OnPropertyChanged(nameof(Study_Form));
            }
        }        
        public string Study_Level
        {
            get
            {
                return _Study_Level;
            }
            set
            {
                _Study_Level = value;
                OnPropertyChanged(nameof(Study_Level));
            }
        }     

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {           
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
                MessageBox.Show("Property changed","Debug", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    public class Student : INotifyPropertyChanged
    {
        public static string St
        {
            get
            {
                return "Student";
            }           
        }
        private string _Student_Name;
        private string _Id;
        private DateTime _Date;
        private string _Signature;
        private string _Date_Signature;
        
        public string Student_Name
        {
            get
            {
                return _Student_Name;
            }
            set
            {
                _Student_Name = value;
                OnPropertyChanged(nameof(Student_Name));
            }
        }
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public string Signature
        {
            get
            {
                return _Signature;
            }
            set
            {
                _Signature = value;
                OnPropertyChanged(nameof(Signature));
            }
        }
        public string Date_Signature
        {
            get
            {
                return _Date_Signature;
            }
            set
            {
                _Date_Signature = value;
                OnPropertyChanged(nameof(Date_Signature));
            }
        }      

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
                MessageBox.Show("Property changed", "Debug", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    public class Thesis : INotifyPropertyChanged
    {
        private string _PL_Title;
        private string _EN_Title;
        private string _Input_Data;
        private string _Operating_Range; 
        private DateTime _Deadline;
        private string _Promoter;
        private string _Promoter_Unit;
        public string PL_Title
        {
            get
            {
                return _PL_Title;
            }
            set
            {
                _PL_Title = value;
                OnPropertyChanged(nameof(PL_Title));
            }
        }
        public string EN_Title
        {
            get
            {
                return _EN_Title;
            }
            set
            {
                _EN_Title = value;
                OnPropertyChanged(nameof(EN_Title));
            }
        }
        public string Input_Data
        {
            get
            {
                return _Input_Data;
            }
            set
            {
                _Input_Data = value;
                OnPropertyChanged(nameof(Input_Data));
            }
        }
        public string Operating_Range
        {
            get
            {
                return _Operating_Range;
            }
            set
            {
                _Operating_Range = value;
                OnPropertyChanged(nameof(Operating_Range));
            }
        }
        public DateTime Deadline
        {
            get
            {
                return _Deadline;
            }
            set
            {
                _Deadline= value;
                OnPropertyChanged(nameof(Deadline));
            }
        }
        public string Promoter
        {
            get
            {
                return _Promoter;
            }
            set
            {
                _Promoter  = value;
                OnPropertyChanged(nameof(Promoter));
            }
        }
        public string Promoter_Unit
        {
            get
            {
                return _Promoter_Unit;
            }
            set
            {
                _Promoter_Unit = value;
                OnPropertyChanged(nameof(Promoter_Unit));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
                MessageBox.Show("Property changed", "Debug", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }


    public partial class MainWindow : Window
    {
        public Studies The_studies { get; set; }
        public Thesis The_thesis { get; set; }
        public ObservableCollection<Student> Students_Collection { get; set; }
        public Container Container { get; set; }

        public MainWindow()
        {
            InitializeComponent();            
            this.DataContext = this;          
            
            The_studies = new();
            The_thesis = new();
            Students_Collection = new();

            MessageBoxResult result = MessageBox.Show("Wczytać zapisaną sesję?", "Witaj", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) { RestoreSession(); }
        }        

        private void RestoreSession()
        {
            string default_File;           
            default_File = ConfigurationManager.AppSettings.Get("recent_data");
            if (File.Exists(default_File) && default_File != "") 
            {
                importXml(default_File);                
            }
            else { MessageBox.Show("Pliki nie istnieją"); }
        }

        private void importXml(string inputfile)
        {
            using (var reader = new StreamReader(inputfile))
            {
                Container = new();
                XmlSerializer deserializer = new XmlSerializer(Container.GetType());                
                Container = (Container)deserializer.Deserialize(reader);                              
            }
            if(Container != null)
            {
                The_studies = Container.Studies;
                The_thesis = Container.Thesis;
                Students_Collection = Container.Students_List;
                MessageBox.Show(Container.Thesis.PL_Title);
                MessageBox.Show(Container.Studies.Subject);
                MessageBox.Show(Container.Students_List[0].Student_Name);
                AddUpdateAppSettings("recent_data", inputfile);
            }
           
        }

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
        public void SaveXml(Container data)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (savefile.ShowDialog() ?? true)
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());             
                string filename = savefile.FileName;              
                using (Stream s = File.Create(filename))
                {
                    serializer.Serialize(s, data);
                }               
                AddUpdateAppSettings("recent_data", filename);                
                MessageBox.Show(filename, "Zapisano:");
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Zapisać dane?", "Zamykanie", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) 
            {
                Container = new();
                Container.Thesis = The_thesis;
                Container.Studies = The_studies;
                Container.Students_List = Students_Collection;
                MessageBox.Show(Container.Thesis.PL_Title);
                MessageBox.Show(Container.Studies.Subject);
                MessageBox.Show(Container.Students_List[0].Student_Name);

                SaveXml(Container); 
            }
        }
    }
}
