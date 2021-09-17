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
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
            DataContext = new GameViewModel();
           
        }

        private void board_DragOver(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is Marker)
            {
                var marker = (Marker)data;
                Point dropPoint = e.GetPosition(board);
                Canvas.SetLeft(marker, dropPoint.X);
                Canvas.SetTop(marker, dropPoint.Y);
                if (!board.Children.Contains(marker))
                {
                    markerboard.Children.Remove(marker);
                    board.Children.Add(marker);
                }
                
            }
        }
    }
}
