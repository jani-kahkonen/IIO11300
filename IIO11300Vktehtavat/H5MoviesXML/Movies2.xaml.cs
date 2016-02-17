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
using System.Windows.Shapes;
using System.Xml;

namespace H5MoviesXML
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Tallennetaan muuttunut tieto XML- tiedostoon.

            try
            {
                string file = xdpMovies.Source.LocalPath;
                xdpMovies.Document.Save(file);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            // Lisätään XML- dokumenttiin uusi elementti.

            if (lbMovies.SelectedIndex > -1)
            {
                //Huom. textboxit ja listbox dindattu dataan
                lbMovies.SelectedIndex = -1;
            }
            else
            {
                // Lisätään uusi node
                string file = xdpMovies.Source.LocalPath;

                // Viittaus XML dokumenttiin ja sen juurielementtiin.
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");

                // Luodaan uusi node.
                XmlNode newMovie = doc.CreateElement("Movie");

                // Lisätään attribuutit.
                XmlAttribute attr = doc.CreateAttribute("Name");
                attr.Value = txtName.Text;
                newMovie.Attributes.Append(attr);   // Liittää atribuutin kokoelmaan.

                XmlAttribute attr2 = doc.CreateAttribute("Director");
                attr2.Value = txtDirector.Text;
                newMovie.Attributes.Append(attr2);

                XmlAttribute attr3 = doc.CreateAttribute("Country");
                attr3.Value = txtCountry.Text;
                newMovie.Attributes.Append(attr3);

                // Lisää noodin juureen.
                root.AppendChild(newMovie);

                // Tallennetaan fileen.
                xdpMovies.Document.Save(file);

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Poistetaan XML - dokumentista valittu elementti.
        }
    }
}
