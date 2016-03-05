using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tehtava7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lbInfo.Items.Clear();
            lbInfo.Items.Add("Merkkejä: --");
            lbInfo.Items.Add("Isoja kirjaimia: --");
            lbInfo.Items.Add("Pieniä kirjaimia --");
            lbInfo.Items.Add("Numeroita: --");
            lbInfo.Items.Add("Erikoismerkkejä: --");

            lbStatus.Items.Clear();
            lbStatus.FontSize = 20;
            lbStatus.Background = Brushes.Gray;
            lbStatus.Items.Add("Anna salasana");
        }

        private void txtPassword_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int countUpperCase = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
                if (char.IsUpper(txtPassword.Text[i])) countUpperCase++;

            int countLowerCase = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
                if (char.IsLower(txtPassword.Text[i])) countLowerCase++;

            int countDigitCase = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
                if (char.IsDigit(txtPassword.Text[i])) countDigitCase++;

            int countSpecialCase = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
                if (!char.IsLetterOrDigit(txtPassword.Text[i])) countSpecialCase++;

            int condition = 0;

            if (countUpperCase != 0)
                condition += 1;   
            if (countLowerCase != 0)
                condition += 1;          
            if (countDigitCase != 0)
                condition += 1;     
            if (countSpecialCase != 0)
                condition += 1;
            
            if (txtPassword.Text.Length <= 8)
            {
                lbStatus.Items.Clear();
                lbStatus.Background = Brushes.Gray;
                lbStatus.Items.Add("Anna salasana");
            }

            if (txtPassword.Text.Length >= 8 && condition >= 1)
            {
                lbStatus.Items.Clear();
                lbStatus.Background = Brushes.Orange;
                lbStatus.Items.Add("Bad");
            }

            if (txtPassword.Text.Length >= 12 && condition >= 2)
            {
                lbStatus.Items.Clear();
                lbStatus.Background = Brushes.Yellow;
                lbStatus.Items.Add("Fair");
            }

            if (txtPassword.Text.Length >= 16 && condition >= 3)
            {
                lbStatus.Items.Clear();
                lbStatus.Background = Brushes.LightGreen;
                lbStatus.Items.Add("Moderate");
            }

            if (txtPassword.Text.Length >= 16 && condition >= 4)
            {
                lbStatus.Items.Clear();
                lbStatus.Background = Brushes.Green;
                lbStatus.Items.Add("Good");
            }

            lbInfo.Items.Clear();
            lbInfo.Items.Add("Merkkejä: " + txtPassword.Text.Length);
            lbInfo.Items.Add("Isoja kirjaimia: " + countUpperCase);
            lbInfo.Items.Add("Pieniä kirjaimia " + countLowerCase);
            lbInfo.Items.Add("Numeroita: " + countDigitCase);
            lbInfo.Items.Add("Erikoismerkkejä: " + countSpecialCase);
        }
    }
}
