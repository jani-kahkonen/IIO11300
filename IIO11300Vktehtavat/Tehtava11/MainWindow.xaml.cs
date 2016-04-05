using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Tehtava11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        SMLiigaEntities ctx;
        ObservableCollection<Pelaajat> localBooks;
        ICollectionView view; // DataGridin filtteröintiä varten

        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            // Luodaan konteksti = datasisältö
            ctx = new SMLiigaEntities();

            // Ladataan kirjatiedot paikalliseksi
            ctx.Pelaajat.Load();
            localBooks = ctx.Pelaajat.Local;

            // Luodaan view
            view = CollectionViewSource.GetDefaultView(localBooks);

            // Haetaan kirjat DataGridiin
            lstPlayers.DataContext = localBooks;
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spBook.DataContext = lstPlayers.SelectedItem;
        }

        private void btnSchDB_Click(object sender, RoutedEventArgs e)
        {
            view.Filter = MyGroupFilter;
        }

        private bool MyGroupFilter(object item)
        {
            return (item as Pelaajat).seura.Contains(txtGroup.Text);
        }

        private void btnAddDB_Click(object sender, RoutedEventArgs e)
        {
            ctx.SaveChanges();
        }

        private void btnExt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClr_Click(object sender, RoutedEventArgs e)
        {
            txtFName.Clear();
            txtLName.Clear();
            txtPrice.Clear();
            txtGroup.Clear();
        }
    }
}