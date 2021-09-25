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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _007.Views
{
    /// <summary>
    /// Interaction logic for PlayerName.xaml
    /// </summary>
    public partial class PlayerName : UserControl
    {
        public PlayerName()
        {
            InitializeComponent();
            DataContext = new PlayerViewModel();
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            DisplayName displayName = new DisplayName();
            displayName.Close();
        }
    }
}
