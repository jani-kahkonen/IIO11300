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
        private List<Book> books;

        public MainWindow()
        {
            InitializeComponent();

            InitMyStuff();
        }

        private void InitMyStuff()
        {
            try
            {
                books = BLPlayer.GetBooks(true);

                lstBooks.DataContext = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spBook.DataContext = lstBooks.SelectedItem;
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book current = (Book)spBook.DataContext;

                BLPlayer.UpdateBook(current);

                MessageBox.Show(string.Format("Kirja {0} päivitetty kantaan onnistuneesti", current.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
