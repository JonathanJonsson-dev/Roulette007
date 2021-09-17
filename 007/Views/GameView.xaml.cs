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
                var allowedPoint = GetAllowedPoint(dropPoint);
                Canvas.SetLeft(marker, allowedPoint.X);
                Canvas.SetTop(marker, allowedPoint.Y);
                if (!board.Children.Contains(marker))
                {
                    markerboard.Children.Remove(marker);
                    board.Children.Add(marker);
                }
                markertest.Content = $"X: {allowedPoint.X} Y: {allowedPoint.Y}";
            }
        }
        private Point GetAllowedPoint(Point point)
        {
            double cellSizeX = 1;
            double cellSizeY = 1;
            double offsetX = 0;
            double offsetY = 0;
            var x = point.X;
            var y = point.Y;
            if (y < 67.5)// the number 0
            {
                cellSizeY = 50;
            }
            if (x > 109 && y>=67.5 && y<538)//Number 1-36 of the board
            {
                cellSizeX = 25;
                cellSizeY = 20.3;
                offsetY = +10;
                offsetX = +8;
            }
            if(x<90 && x>50)//Dozen betting of board
            {
                cellSizeX = 50;
                cellSizeY = 150;
                //offsetY = +10;
                offsetX = +25;
            }
            var col = Math.Floor(y / cellSizeY);
            var row = Math.Floor(x / cellSizeX);

            y = col * cellSizeY + offsetY;
            x = row * cellSizeX + offsetX;
            return new Point(x, y);

        }
    }
}
