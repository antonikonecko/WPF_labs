using lab9;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace lab9
{
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

    public class Student
    {
        public static string St
        {
            get
            {
                return "Student";
            }           
        }
        public string Student_Name { get; set; }
        public string Id { get; set; }
        public DateTime  Date { get; set; }
        public string Date_Signature { get; set; }
        public string Signature { get; set; }
        

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
        public Studies studies { get; set; }
        public Thesis thesis { get; set; }
        public List<Student> Students_list { get; set; }       
        
        public MainWindow()
        {
            InitializeComponent();            
            this.DataContext = this;
            studies = new();            
            thesis = new();            
            Students_list = new();   
            //Students_list.Add(new Student() { Student_Name = "Fernando Alonso", Id = "14", Date = DateTime.Today });
            //Students_list.Add(new Student() { Student_Name = "Max Verstappen",  Id = "33", Date = DateTime.Today });
            //Students_list.Add(new Student() { Student_Name = "Lewis Hamilton",  Id = "44", Date = DateTime.Today });            
            DG_Students_Data.ItemsSource=Students_list;
            DG_Students_Data.Items.Refresh();       
            
        }  
    }
}
