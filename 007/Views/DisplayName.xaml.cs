using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _007.Views
{
    /// <summary>
    /// Interaction logic for DisplayName.xaml
    /// </summary>
    public partial class DisplayName : Window
    {
        public DisplayName()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// closes displayname pop up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
