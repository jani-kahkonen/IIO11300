using System;
using System.Data; // for general ADO-classes
using System.Data.SqlClient; // for sql server classes
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TehtäväV8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        DataTable dt;
        DataView dv;
        List<string> cities;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void IniMyStuff()
        {
            // Asetetaan kaupunkien nimet ComboBoxiin.
            cities = new List<string>();
            // VE1 kaupungin nimet "kovakoodattuna".
            //cities.Add("Jyväskylä");
            //cities.Add("Helsinki");
            //cities.Add("New York");

            // VE2 käydään loopittamalla DataTable läpi.
            string kaupunki = "";

            foreach (DataRow item in dt.Rows)
            {
                kaupunki = item[3].ToString();

                // Lisätään kaupunki vain kerran listaan.
                if(!cities.Contains(kaupunki))
                    cities.Add(item[3].ToString());
            }

            // VE3 LINQ:lla voi tehdä kyselyn tyypitettyyn DataTableen, huom. ei kaikille DataTableille.
            // var result = (from c in dt select c.City).Distinct();

            // Databindaus.
            cbCities.ItemsSource = cities;
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan viiniasikkaat palvelimelta ja näytetään ne ListBoxissa.
            try
            {
                GetData();

                // V1 dataview filtterointi ja sorttaus.
                dv = dt.DefaultView;

                // Datan sitominen UI-kontrolliin, kelpaa DataTable, DataView, DataReader, Oliokokoelma.
                lbCustomers.DataContext = dv;

                // Huom. DataTable sarake (column) on casesensitiivinen.
                lbCustomers.DisplayMemberPath = "Lastname";

                IniMyStuff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Vaihdetaan stacpanelin datacontext viittaamaan valittuun asiakkaaseen.
            spCustomer.DataContext = lbCustomers.SelectedItem;
        }

        #region METHODS

        private void GetData()
        {
            // Luodaan yhteys tietokantaan connectionStringin avulla.
            try
            {
                using (SqlConnection conn = new SqlConnection(TehtäväV8.Properties.Settings.Default.Tietokanta))
                {
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vCustomers", conn);

                    // Pistetään DataAdapter hakemaan tiedot muistiin = DataTableen.
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Asetetaan DataView:llä filtteri.
            dv.RowFilter = string.Format("City LIKE '{0}'", cbCities.SelectedValue);
        }
    }
}
