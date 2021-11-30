using Microsoft.Win32;
using System;
using System.Collections;
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
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;

namespace lab6
{
	public partial class ListViewGridViewSample : Window
	{
		public List<Product> ProductsList;


		public ListViewGridViewSample()
		{
			InitializeComponent();

			ProductsList = new List<Product>();
			lvProducts.ItemsSource = ProductsList;
			string defaultFile;
			defaultFile = ConfigurationManager.AppSettings.Get("recent_data");
			if (defaultFile != "")
			{
				importXml(defaultFile);
			}
		}

		private void AddItemWindowBtn_Click(object sender, RoutedEventArgs e)
		{
			WindowAddItem windowAddItem = new();
			windowAddItem.Owner = this;
			windowAddItem.ShowDialog();

		}

		private void SearchWindowBtn_Click(object sender, RoutedEventArgs e)
		{
			SearchWindow searchWindow = new(ProductsList);
			searchWindow.Owner = this;
			searchWindow.ShowDialog();
		}

		private void SampleDataBtn_Click(object sender, RoutedEventArgs e)
		{
			this.DataContext = this;
			InitializeComponent();
			ProductsList.Add(new Product() { Name = "Sample Name1", ID = Guid.NewGuid().ToString(), Count = ProductsList.Count + 1 });
			ProductsList.Add(new Product() { Name = "Sample Name2", ID = Guid.NewGuid().ToString(), Count = ProductsList.Count + 1 });
			ProductsList.Add(new Product() { Name = "Sample Name3", ID = Guid.NewGuid().ToString(), Count = ProductsList.Count + 1 });

			lvProducts.Items.Refresh();
		}

		private void ClearBtn_Click(object sender, RoutedEventArgs e)
		{
			ProductsList.Clear();
			lvProducts.Items.Refresh();
		}

		private void ImportBtn_Click(object sender, RoutedEventArgs e)
		{
			FileDialog inputfile = new OpenFileDialog();
			inputfile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			ProductsList.Clear();

			if (inputfile.ShowDialog() ?? true)
			{
				importXml(inputfile.FileName);
			}

		}

		private void importXml(string inputfile)
		{
			using (var reader = new StreamReader(inputfile))
			{
				XmlSerializer deserializer = new XmlSerializer(ProductsList.GetType());
				ProductsList = (List<Product>)deserializer.Deserialize(reader);
			}
			AddUpdateAppSettings("recent_data", inputfile);
			lvProducts.ItemsSource = ProductsList;
			lvProducts.Items.Refresh();
		}

		private void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
			SaveXml(ProductsList);
		}
		public void SaveXml(List<Product> products)
		{
			SaveFileDialog savefile = new SaveFileDialog();
			savefile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

			if (savefile.ShowDialog() ?? true)
			{
				XmlSerializer serializer = new XmlSerializer(products.GetType());

				using (Stream s = File.Create(savefile.FileName))
				{
					serializer.Serialize(s, products);
				}

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

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Zapisać dane?", "Zamykanie programu", MessageBoxButton.YesNo);
			if (result == MessageBoxResult.Yes) { SaveXml(ProductsList); }
		}

	}


	public class Product
	{
		public string Name { get; set; }

		public string ID { get; set; }

		public int Count { get; set; }

		public Product() { }
	}


}
