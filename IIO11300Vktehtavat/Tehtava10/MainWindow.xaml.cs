using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace Tehtava10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OleDbConnection oleCon;
        public OleDbCommand oleComd;

        public MainWindow()
        {
            InitializeComponent();

            BindData();
        }

        public void BindData()
        {

            oleCon = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Jani\Documents\Visual Studio 2015\Projects\IIO11300\IIO11300Vktehtavat\Tehtava10\SMLiiga.accdb");

            oleComd = new OleDbCommand("SELECT * FROM Pelaajat", oleCon);

            DataSet dtst = new DataSet();

            OleDbDataAdapter adpt = new OleDbDataAdapter();

            try
            {
                oleCon.Open();

                adpt.SelectCommand = oleComd;

                adpt.Fill(dtst, "Pelaajat");

                lstPlayer.DataContext = dtst;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oleCon.Close();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
