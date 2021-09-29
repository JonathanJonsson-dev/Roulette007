using _007.Commands;
using _007.Models;
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
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {

        public ICommand DisplaySetNameCommand { get; }

        public PlayerView()
        {
            InitializeComponent();
            DataContext = new PlayerViewModel();
            DisplaySetNameCommand = new DisplaySetNameCommand(this);
            
        }


        

    }
}
