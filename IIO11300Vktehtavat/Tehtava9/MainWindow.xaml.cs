using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Tehtava9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt;
        DataView dv;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bttSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetData();

                dv = dt.DefaultView;
                
                grdAsiakkaat.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttNew_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tbFname = new TextBlock();
            tbFname.Text = "Etunimi: ";
            myStackpanel.Children.Add(tbFname);

            TextBox txtFname = new TextBox();
            txtFname.Width = 40;
            myStackpanel.Children.Add(txtFname);

            TextBlock tbLname = new TextBlock();
            tbLname.Text = "Sukunimi: ";
            myStackpanel.Children.Add(tbLname);

            TextBox txtLname = new TextBox();
            txtLname.Width = 40;
            myStackpanel.Children.Add(txtLname);

            TextBlock tbAddress = new TextBlock();
            tbAddress.Text = "Osoite: ";
            myStackpanel.Children.Add(tbAddress);

            TextBox txtAddress = new TextBox();
            txtAddress.Width = 40;
            myStackpanel.Children.Add(txtAddress);

            TextBlock tbPostCode = new TextBlock();
            tbPostCode.Text = "Postinumero: ";
            myStackpanel.Children.Add(tbPostCode);

            TextBox txtPostCode = new TextBox();
            txtPostCode.Width = 40;
            myStackpanel.Children.Add(txtPostCode);

            TextBlock tbCity = new TextBlock();
            tbCity.Text = "Kaupunki: ";
            myStackpanel.Children.Add(tbCity);

            TextBox txtCity = new TextBox();
            txtCity.Width = 40;
            myStackpanel.Children.Add(txtCity);

            Button newCustomer = new Button();
            newCustomer.Content = "Luo uusi";
            myStackpanel.Children.Add(newCustomer);

            newCustomer.Click += (source, RoutedEventArgse) =>
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Tehtava9.Properties.Settings.Default.Tietokanta))
                    {
                        conn.Open();

                        string sql = "INSERT INTO customer (firstname, lastname, address, city) VALUES (@Enimi, @Snimi, @Osoite, @Maa)";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@Enimi", txtFname.Text);
                        cmd.Parameters.AddWithValue("@Snimi", txtLname.Text);
                        cmd.Parameters.AddWithValue("@Osoite", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Maa", txtCity.Text);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            };
        }

        private void bttDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)grdAsiakkaat.SelectedItems[0];

            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM customer WHERE id={0}", row[0]), conn);

                    if (MessageBox.Show("Haluatko varmasti poistaa asiakkaan " + row[1] + " " + row[2] + "?", "Viinikellarin asiakkaat", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region METHODS

        private void GetData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9.Properties.Settings.Default.Tietokanta))
                {
                    dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM customer", conn);

                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
