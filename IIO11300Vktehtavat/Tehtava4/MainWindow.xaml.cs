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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.IO;
using System.Windows.Controls.Primitives;

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private ArrayList array = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbbSeura_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Seura 1");
            data.Add("Seura 2");
            data.Add("Seura 3");
            data.Add("Seura 4");
            data.Add("Seura 5");
            data.Add("Seura 6");
            data.Add("Seura 7");
            data.Add("Seura 8");
            data.Add("Seura 9");
            data.Add("Seura 10");
            data.Add("Seura 11");
            data.Add("Seura 12");
            data.Add("Seura 13");
            data.Add("Seura 14");
            data.Add("Seura 15");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

             // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    throw new Exception("Etunimi");
                }
                if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    throw new Exception("Sukunimi");
                }
                if (string.IsNullOrEmpty(txtCost.Text))
                {
                    throw new Exception("Siirtohinta");
                }

                var path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Kuvat\", txtImage.Text);
                var uri = new Uri(path);
                var bitmap = new BitmapImage(uri);
                media.Source = bitmap;

                Pelaaja pelaaja = new Pelaaja(txtFirstName.Text, txtLastName.Text, Int32.Parse(txtCost.Text), cbbSeura.Text, txtImage.Text);

                array.Add(pelaaja);

                lbPlayers.Items.Add(pelaaja.getEsitysnimi());
            }
            catch (Exception ex)
            {
                status.Text = ex.Message;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Pelaaja selectedPlayer;

            selectedPlayer = array[lbPlayers.SelectedIndex] as Pelaaja;

            selectedPlayer.Etunimi = txtFirstName.Text;
            selectedPlayer.Sukunimi = txtLastName.Text;
            selectedPlayer.Hinta = Int32.Parse(txtCost.Text);
            selectedPlayer.Seura = cbbSeura.Text;
            selectedPlayer.Polku = txtImage.Text;

            array[lbPlayers.SelectedIndex] = selectedPlayer;

            lbPlayers.Items.Clear();

            for(int i = 0; i < array.Count; ++i)
            {
                selectedPlayer = array[i] as Pelaaja;
                lbPlayers.Items.Add(selectedPlayer.getEsitysnimi());
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbPlayers.SelectedItem != null)
            {
                Pelaaja selectedPlayer;

                selectedPlayer = array[lbPlayers.SelectedIndex] as Pelaaja;

                array.Remove(selectedPlayer);
   
                lbPlayers.Items.Clear();

                for (int i = 0; i < array.Count; ++i)
                {
                    selectedPlayer = array[i] as Pelaaja;
                    lbPlayers.Items.Add(selectedPlayer.getEsitysnimi());
                }
            }
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            using (TextWriter writer = File.CreateText(@"players.txt"))
            {
                foreach (Pelaaja player in array)
                {
                    writer.WriteLine(player.Etunimi);
                    writer.WriteLine(player.Sukunimi);
                    writer.WriteLine(player.Hinta);
                    writer.WriteLine(player.Seura);
                    writer.WriteLine(player.Polku);
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lbPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbPlayers.SelectedItem != null)
            {
                Pelaaja selectedPlayer;

                selectedPlayer = array[lbPlayers.SelectedIndex] as Pelaaja;

                txtFirstName.Text = selectedPlayer.Etunimi;
                txtLastName.Text = selectedPlayer.Sukunimi;
                txtCost.Text = selectedPlayer.Hinta.ToString();
                cbbSeura.Text = selectedPlayer.Seura;
                txtImage.Text = selectedPlayer.Polku;

                var path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Kuvat\", txtImage.Text);
                var uri = new Uri(path);
                var bitmap = new BitmapImage(uri);
                media.Source = bitmap;
            }
        }
    }
}
