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

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.comboBox.Items.Add("Suomi-lotto");
            this.comboBox.Items.Add("Viking-lotto"); 
            this.comboBox.Items.Add("Eurojackpot-lotto");
            this.comboBox.SelectedIndex = 0;
        }

        private void bttClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bttDraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Arvottavien rivien lukumäärä.
                int count = int.Parse(txtCount.Text);

                Tehtava2.Lotto[] lotto = new Tehtava2.Lotto[count];

                for (int i = 0; i < count; ++i)
                {
                    lotto[i] = new Lotto();

                    // Pelin valinta

                    if (this.comboBox.SelectedIndex == 0)
                    {
                        lotto[i].Lenght = 7;
                        lotto[i].Max = 39;
                        lotto[i].Ext = false;
                    }
                    else if (this.comboBox.SelectedIndex == 1)
                    {
                        lotto[i].Lenght = 6;
                        lotto[i].Max = 48;
                        lotto[i].Ext = false;
                    }
                    else if (this.comboBox.SelectedIndex == 2)
                    {
                        lotto[i].Lenght = 5;
                        lotto[i].Max = 50;
                        lotto[i].Ext = true;
                    }
                }

                // Tee rivit

                for(int i = 0; i < count; ++i)
                {
                    txtContainer.Text += lotto[i].CreateLotto() + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttClear_Click(object sender, RoutedEventArgs e)
        {
            txtContainer.Text = String.Empty;
        }
    }
}
