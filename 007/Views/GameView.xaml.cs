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
                //markertest.Content = $"X: {Math.Round(dropPoint.X)} Y: {Math.Round(dropPoint.Y)}";
            }
        }
        private Point GetAllowedPoint(Point point)
        {
            double cellSizeX = 25;
            double cellSizeY = 25;
            int offsetX = -8;
            int offsetY = 6;
            var x = point.X;
            var y = point.Y;
            Point _point;
            
            if(x>130 && x <=149)
            {
                cellSizeY = 50;
            }
            var col = Math.Floor(y / cellSizeY);
            var row = Math.Floor(x / cellSizeX);

            _point.Y = col * cellSizeY + offsetY;
            _point.X = row * cellSizeX + offsetX;
            if (y < 48)// the number 0
            {
                _point.X = 192;
                _point.Y = 5;
            }
            else if (x > 75 && x < 130)
            {
                _point.X = 85;
                if (y > 33 && y <= 233)
                    _point.Y = 130;
                else if (y > 233 && y <= 433)
                    _point.Y = 330;
                else
                    _point.Y = 530;
            }
            else if (x < 75)
            {
                _point.X = 16;
                if (y > 50 && y <= 100)
                    _point.Y = 80;
                else if (y > 100 && y <= 200)
                    _point.Y = 180;
                else if (y > 200 && y <= 300)
                    _point.Y = 280;
                else if (y > 300 && y <= 400)
                    _point.Y = 380;
                else if (y > 400 && y <= 500)
                    _point.Y = 480;
                else
                    _point.Y = 580;


            }
            else if(y>624)
            {
                _point.Y = 655;
                if (x > 130 && x <= 181)
                    _point.X = 140;
                else if (x > 181 && x <= 231)
                    _point.X = 190;
                else
                    _point.X = 240;
            }
            
                return _point;
           

        }
    }
}
