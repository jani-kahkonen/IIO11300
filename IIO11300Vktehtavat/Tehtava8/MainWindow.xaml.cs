using System;
using System.Data;  //sisältää ADO;n perusluokat
using System.Data.SqlClient; //SQL Server spesifiset luokat
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

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Customer
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        #region CONSTRUCTORS
        public Customer(string fname, string lname, string address, string city)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.Address = address;
            this.City = city;
        }
        #endregion
    }

    public partial class MainWindow : Window
    {
        private DataTable dt = new DataTable("Asiakkaat");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bttSearch_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT firstname, lastname, address, city FROM vCustomers";

            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava8.Properties.Settings.Default.Tietokanta))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn); 
                    adapter.Fill(dt);

                    conn.Close();
                }
                lbAsiakkaat.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbAsiakkaat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int curItem = lbAsiakkaat.SelectedIndex;

            Customer selectedCustomer = new Customer(
                dt.Rows[curItem][0].ToString(),
                dt.Rows[curItem][1].ToString(),
                dt.Rows[curItem][2].ToString(),
                dt.Rows[curItem][3].ToString());

            spRight.DataContext = selectedCustomer;
        }
    }
}
