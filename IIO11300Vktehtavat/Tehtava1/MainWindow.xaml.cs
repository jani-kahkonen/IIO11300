/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2015 Modified: 13.1.2016
* Authors: Jani Kähkönen, Esa Salmikangas
*/
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

namespace Tehtava1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double resultWndArea = 0, resultFrmArea = 0, resultFrmPerimeter = 0;
            //TODO
            try
            {
                resultWndArea = BusinessLogicWindow.CalculateArea(Convert.ToDouble(txtWidht.Text), Convert.ToDouble(txtHeight.Text));
                resultFrmPerimeter = BusinessLogicWindow.CalculatePerimeter(Convert.ToDouble(txtWidht.Text), Convert.ToDouble(txtHeight.Text));
                resultFrmArea = BusinessLogicWindow.CalculateArea(Convert.ToDouble(txtFrmWidth.Text), resultFrmPerimeter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
            txtResultWndArea.Text = resultWndArea.ToString();
            txtResultFrmArea.Text = resultFrmArea.ToString();
            txtResultFrmPerimeter.Text = resultFrmPerimeter.ToString();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
        public static double CalculatePerimeter(double widht, double height)
        {
            return widht * 2 + height * 2;
        }
        public static double CalculateArea(double widht, double height)
        {
            return widht * height;
        }
    }
}
