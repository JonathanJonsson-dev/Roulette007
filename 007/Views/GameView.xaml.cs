using _007.Data;
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
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private readonly GameViewModel gameViewModel;
        public GameView()
        {
            InitializeComponent();
            gameViewModel = new GameViewModel(this);
            DataContext = gameViewModel;
            SetPlayerNameView setPlayerNameView = new SetPlayerNameView(gameViewModel.Player);
            setPlayerNameView.Show();
            setPlayerNameView.Topmost = true;

        }
        readonly MediaPlayer player = new MediaPlayer();
        private void board_DragOver(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is Marker)
            {
                var marker = (Marker)data;
                Point dropPoint = e.GetPosition(board);
                marker.Margin = new Thickness(0, 0, 0, 0);
                var allowedPoint = GetAllowedPoint(dropPoint);
                Canvas.SetLeft(marker, allowedPoint.X);
                Canvas.SetTop(marker, allowedPoint.Y);
                if (!board.Children.Contains(marker))
                {
                    markerboard.Children.Remove(marker);
                    board.Children.Add(marker);
                }
                else
                {
                    Bet betToRemove = new Bet { Value = 0};
                    foreach (var bet in gameViewModel.Player.Bets)
                    {
                        if(bet.Mark == marker)
                        {
                            betToRemove = bet;
                        }
                    }
                    gameViewModel.Player.Bets.Remove(betToRemove);
                    gameViewModel.Player.Pot += betToRemove.Value;
                }


            }
        }
        private Point GetAllowedPoint(Point point)
        {
            
            double cellSizeX = 25;
            double cellSizeY = 25;
            int offsetX = -10;
            int offsetY = 5;
            var x = point.X;
            var y = point.Y;
            Point _point;

            
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
            else if (y > 624)
            {
                _point.Y = 655;
                if (x > 130 && x <= 181)
                    _point.X = 140;
                else if (x > 181 && x <= 231)
                    _point.X = 190;
                else
                    _point.X = 240;
            }
            else if(x > 240)
            {
                _point.X = 240;
                
            }

            return _point;


        }

        private void markerboard_DragOver(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is Marker)
            {
                var marker = (Marker)data;
                marker.Margin = new Thickness(0, 0, 0, 0);
                Point dropPoint = e.GetPosition(board);


                Canvas.SetLeft(marker, dropPoint.X);
                Canvas.SetTop(marker, dropPoint.Y);
                if (!markerboard.Children.Contains(marker))
                {
                    try
                    {
                        board.Children.Remove(marker);
                        markerboard.Children.Add(marker);
                    }
                    catch
                    {

                    }
                }


            }
        }

        private void board_Drop(object sender, DragEventArgs e)
        {
            Random r = new Random();
            object data = e.Data.GetData(DataFormats.Serializable);
            Marker marker;
                if (data is Marker)
                {
                    marker = (Marker)data;
                if (gameViewModel.Player.Name != "")
                {
                    bool isAlreadyOn = false;
                    foreach (var bet in gameViewModel.Player.Bets)
                    {
                        if (marker == bet.Mark)
                        {
                            isAlreadyOn = true;
                        }
                    }
                    if (!isAlreadyOn)
                    {
                        if (gameViewModel.Player.Pot - marker.Value >= 0)
                        {
                            Point point = e.GetPosition(board);
                            point = GetAllowedPoint(point);
                            Bet bet = new Bet();
                            if (point.X >= 115 && point.Y < 624 && point.Y>29)
                            {
                                bet = gameViewModel.GameEngine.CreateBet(marker, point);

                            }
                            else if (point.Y <= 29)// the number 0
                            {
                                bet.Mark = marker;
                                List<int> list = new List<int>
                                {
                                    0
                                };
                                bet.Numbers = list;
                                bet.Value = marker.Value;
                                bet.Type = BetType.Zero;
                            }
                            else if (point.X > 75 && point.X < 130)
                            {
                                bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.Dozen, point);
                            }
                            else if (point.X < 75)
                            {
                              
                                if (point.Y > 50 && point.Y <= 100)
                                    bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.Low, point);
                                else if (point.Y > 100 && point.Y <= 200)
                                    bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.Even, point);
                                else if (point.Y > 200 && point.Y <= 300)
                                    bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.Red, point);
                                else if (point.Y > 300 && point.Y <= 400)
                                    bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.Black, point);
                                else if (point.Y > 400 && point.Y <= 500)
                                    bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.Odd, point);
                                else
                                    bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.High, point);


                            }
                            else if (point.Y > 624)
                            {

                                bet = gameViewModel.GameEngine.CreateBet(marker, Data.BetType.Column, point);

                            }
                           


                            gameViewModel.Player.Bets.Add(bet);
                            gameViewModel.Player.Pot -= (int)marker.Value;
                            string chipLabel = "007";
                            if(marker.ChipLabel == "All In")
                            {
                                chipLabel = "All In";
                            }
                            Marker newMark = new Marker
                            {
                                Value = marker.Value,
                                MarkerColor = marker.MarkerColor,
                                Margin = marker.GetMarkerMargin(marker.colors),
                                colors = marker.colors,
                                ChipLabel = chipLabel
                            };
                            
                            markerboard.Children.Add(newMark);
                            marker.Margin = new Thickness(r.Next(0, 10), r.Next(0, 10), r.Next(0, 10), r.Next(0, 10));
                        }
                        else
                        {
                            board.Children.Remove(marker);

                            marker.Margin = marker.GetMarkerMargin(marker.colors);
                            markerboard.Children.Add(marker);
                            MessageBox.Show("You can't afford");
                        }
                    }
                    player.Open(new Uri(@"Resources/ChipDown.wav", UriKind.Relative));
                    player.Volume = 0.05;
                    player.Play();
                }
                else
                {
                    board.Children.Remove(marker);

                    marker.Margin = marker.GetMarkerMargin(marker.colors);
                    markerboard.Children.Add(marker);
                    MessageBox.Show("Please enter your name first.");
                }
            }
           


        }

        private void markerboard_Drop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            Marker marker;
            if (data is Marker)
            {
                marker = (Marker)data;
                Bet betToRemove = null;
                foreach (var bet in gameViewModel.Player.Bets)
                {
                    if (marker == bet.Mark)
                    {
                        betToRemove = bet;
                    }
                }
                if (betToRemove != null)
                {
                    gameViewModel.Player.Bets.Remove(betToRemove);


                   
                    gameViewModel.Player.Pot += (int)marker.Value;
                    markerboard.Children.Remove(marker);
                }
                marker.Margin = marker.GetMarkerMargin(marker.colors);
                player.Open(new Uri(@"Resources/ChipDown.wav", UriKind.Relative));
                player.Volume = 0.05;
                player.Play();

            }
        }
       
    }
}
