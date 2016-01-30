using System;
using System.IO;
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
using JAMK.IT.IIO11300;

namespace H3MittausData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            lbData.Items.Clear();

            try
            {
                // Create an instance of StreamReader to read from a file.
                using (StreamReader sr = new StreamReader(txtReportFile.Text))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        lbData.Items.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            // luodaan uusi mittausdata olio ja näytetään se käyttäjälle
            MittausData md = new MittausData(   DateTime.Today.ToShortDateString(),
                                                txtFileName.Text,
                                                txtReportFile.Text);
            lbData.Items.Add(md);

            // This text is always added, making the file longer over time if it is not deleted.
            using (StreamWriter sw = File.AppendText(txtReportFile.Text))
            {
                sw.WriteLine(md);
            }

            string fileName = txtFileName.Text;
            string sourcePath = txtSourcePath.Text;
            string targetPath = txtTargetPath.Text;

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            try
            {
                // To copy a file to another location and overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            IniMyStuff();
        }
    }
}
