using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;

public class Item
{
    public string Nimi { get; set; }
    public string Arvio { get; set; }
    public string Maa { get; set; }

    #region CONSTRUCTORS
    public Item(string a, string b, string c)
    {
        this.Nimi = a;
        this.Arvio = b;
        this.Maa = c;
    }
    #endregion
}

namespace Tehtava6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            status.Text = ConfigurationManager.AppSettings["Path"];

            cbbMaa.Items.Add("France");
            cbbMaa.Items.Add("Germany");
            cbbMaa.Items.Add("Chile");
            cbbMaa.Items.Add("Romanien");
            cbbMaa.Items.Add("South Africa");
            cbbMaa.Items.Add("Portugal");
            cbbMaa.Items.Add("Hungary");
            cbbMaa.Items.Add("Suomi");
        }

        private bool UserFilter(object item)
        {
            if (cbbMaa.SelectedIndex == -1)
                return true;
            else
                return ((item as Item).Maa.IndexOf(cbbMaa.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void cbbMaa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }

        private void bttLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Item> items = new List<Item>();

            lvUsers.ItemsSource = items;

            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load(ConfigurationManager.AppSettings["Path"]);

            XmlNodeList idNodes = xmlFile.SelectNodes("viinikellari/wine");

            foreach (XmlNode node in idNodes)
            {
                items.Add(new Item(node["nimi"].InnerText, node["arvio"].InnerText, node["maa"].InnerText));
            }

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;
        }
    }
}
