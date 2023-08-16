using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab3
{	
	public partial class ListViewGridViewSample : Window
	{
		public bool ChkTextChanged = false;
        private void AddItemWindowBtn_Click(object sender, RoutedEventArgs e)
        {			
			WindowAddItem window2 = new(ChkTextChanged);
			window2.ShowDialog();
			ChkTextChanged = window2.ChkTextChanged;		

			//To prevent adding items without Name
			if (ChkTextChanged)
            {
				if (window2.TextBoxName.Text != "")
				{
					string Name = window2.TextBoxName.Text;
					lvProducts.Items.Add(new Product() { Name = Name, ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
					lvProducts.Items.Refresh();
				}
			}
			
			
		}
       

        private void SampleDataBtn_Click(object sender, RoutedEventArgs e)
		{
			this.DataContext = this;
			InitializeComponent();
			lvProducts.Items.Add(new Product() { Name = "Sample Name1", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name2", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name3", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name4", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name5", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name6", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name7", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name8", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name9", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
			lvProducts.Items.Add(new Product() { Name = "Sample Name10", ID = Guid.NewGuid().ToString(), Count = lvProducts.Items.Count + 1 });
		}

		private void ClearBtn_Click(object sender, RoutedEventArgs e)
		{
			lvProducts.Items.Clear();
		}

		private void ImportCsvBtn_Click(object sender, RoutedEventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			fileDialog.ShowDialog();
			string CSV_InputPath = fileDialog.FileName;
			lvProducts.Items.Clear();

			string[] lines = System.IO.File.ReadAllLines(CSV_InputPath);

			foreach (string line in lines)
            {
				string[] data = line.Split(';');
				this.lvProducts.Items.Add(new Product() { Name = data[0], ID = data[1], Count = this.lvProducts.Items.Count + 1 });
            }
		}

		private void SaveCsvBtn_Click(object sender, RoutedEventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			if (fileDialog.ShowDialog() ?? true)
			{
				using StreamWriter sw = new StreamWriter(fileDialog.FileName);
				foreach (Product item in lvProducts.Items)
				{
					sw.WriteLine("{0};{1};{2}", item.Name, item.ID, item.Count);
				}
			}
		}

    }

    public class Product
	{
		public string Name { get; set; }

		public string ID { get; set; }

		public int Count { get; set; }
	}
	

}