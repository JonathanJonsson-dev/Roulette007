using _007.Data;
using _007.Models;
using System;
using System.Collections.ObjectModel;
using _007.Views;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.IO;
using System.Windows.Threading;
using System.Windows.Data;

namespace _007.ViewModels
{
    public class WheelViewModel : BaseViewModel
    {
        #region Variables

        //According to single zero wheel
        private readonly int[] wheelNumbers = {0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33,
            1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26};

        private readonly GameViewModel gameViewModel;

        int winAmount;
        #endregion

        #region Properties
        public double WheelStopAngle { get; set; } = 0; //angle att which the wheel stops
        public int WinningNumber { get; set; } //winning number
        //a collection of wheel piesces
        public ObservableCollection<WheelPiece> WheelCollection { get; set; } = new ObservableCollection<WheelPiece>();
        //cordinates to draw wheel labels
        public double CenterPointX { get; set; }
        public double CenterPointY { get; set; }
        public double AngularPOsition { get; set; }
        public double MainBoardHeight { get; set; }
        public double MainBoardWidth { get; set; }
        public double WheelPieceWidth { get; set; }
        public double WheelPieceHeight { get; set; }
        public double WheelPieceDiameter { get; set; }
        public double BallCenterX { get; set; }
        public double BallCenterY { get; set; }
        public double BallTranslateX { get; set; }
        public double BallTranslateY { get; set; }

        #endregion

        public WheelViewModel(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
            DetermineWheelPieceValues(); //Set values to wheel piece variables
            FillWheel();
            UpdateWheelPieceValues(); //More wheel piece variable value
        }

        /// <summary>
        /// Set values to wheel piece object properties
        /// </summary>
        private void UpdateWheelPieceValues()
        {
            foreach(WheelPiece piece in WheelCollection)
            {
                piece.UpdateWheelPiece(WheelPieceWidth, WheelPieceHeight, piece.XPosition, piece.YPosition, CenterPointX, CenterPointY);
            }
        }

        /// <summary>
        /// Calculate values for wheel piece variables
        /// </summary>
        private void DetermineWheelPieceValues()
        {
            MainBoardHeight = Constants.MainBorderHeight;
            MainBoardWidth = Constants.MainBorderWidth;
            WheelPieceDiameter = Constants.MainBorderWidth > Constants.MainBorderHeight ? Constants.InnerWheelDiameterPercentage * Constants.MainBorderHeight : Constants.InnerWheelDiameterPercentage * Constants.MainBorderWidth;
            WheelPieceWidth = (Math.PI * WheelPieceDiameter) / Constants.NumberOfWheelPieces;
            WheelPieceHeight = WheelPieceDiameter * Constants.WheelPieceHeightPercentage;
            CenterPointX = MainBoardWidth / 2;
            CenterPointY = MainBoardHeight / 2;

            //Ball
            var ballYOffsetPixels = Constants.MainBorderWidth > Constants.MainBorderHeight ? (Constants.BallYOffsetPercentage * Constants.MainBorderHeight) / 2 : (Constants.BallYOffsetPercentage * Constants.MainBorderWidth) / 2;
            BallCenterX = CenterPointX - 15;
            BallCenterY = CenterPointY - 15;
            // Ball xy translation (places the ball near the top-edge of the wheel).
            BallTranslateX = BallCenterX;
            BallTranslateY = BallCenterY - ballYOffsetPixels;

        ////center and outer circles diameter and offsets
        //CenterCircleDiameter = Constants.MainBorderWidth > Constants.MainBorderHeight ? Constants.CenterWheelDiameterPercentage * Constants.MainBorderHeight : Constants.CenterWheelDiameterPercentage * Constants.MainBorderWidth;
        //OuterCircleDiameter = Constants.MainBorderWidth > Constants.MainBorderHeight ? Constants.OuterWheelDiameterPercentage * Constants.MainBorderHeight : Constants.OuterWheelDiameterPercentage * Constants.MainBorderWidth;

        //OuterCircleOffsetX = (MainBoardWidth / 2) - (OuterCircleDiameter / 2);
        //OuterCircleOffsetY = (MainBoardHeight / 2) - (CenterCircleDiameter / 2);

        //CenterCircleOffsetX = (MainBoardWidth / 2) - (OuterCircleDiameter / 2);
        //CenterCircleOffsetY = (MainBoardHeight / 2) - (CenterCircleDiameter / 2);
    }

        /// <summary>
        /// Method fill wheel with numbers
        /// </summary>
        private void FillWheel()
        {
             for (int i=0; i<wheelNumbers.Length; i++)
            {
                if (i == 0)
                {
                    WheelPiece piece = new WheelPiece
                    {
                        IsGreenNumber = true,
                        Number = wheelNumbers[i],
                        AngularPosition = i * Constants.WheelPieceDegrees,
                        XPosition = CenterPointX - (WheelPieceWidth / 2),
                        YPosition = CenterPointY - (WheelPieceDiameter / 2),
                        PieceWidth = WheelPieceWidth,
                        PieceHeight = WheelPieceHeight,
                    };

                    WheelCollection.Add(piece);
                }
                else if(i % 2 != 0)
                {
                    WheelPiece piece = new WheelPiece
                    {
                        IsRedNumber = true,
                        Number = wheelNumbers[i],
                        AngularPosition = i * Constants.WheelPieceDegrees,
                        XPosition = CenterPointX - (WheelPieceWidth / 2),
                        YPosition = CenterPointY - (WheelPieceDiameter / 2),
                        PieceWidth = WheelPieceWidth,
                        PieceHeight = WheelPieceHeight,
                    };

                    WheelCollection.Add(piece);
                }
                else
                {
                    WheelPiece piece = new WheelPiece
                    {
                        IsBlackNumber = true,
                        Number = wheelNumbers[i],
                        AngularPosition = i * Constants.WheelPieceDegrees,
                        XPosition = CenterPointX - (WheelPieceWidth / 2),
                        YPosition = CenterPointY - (WheelPieceDiameter / 2),
                        PieceWidth = WheelPieceWidth,
                        PieceHeight = WheelPieceHeight,
                    };

                    WheelCollection.Add(piece);
                }
            }
        }
        
        /// <summary>
        /// Method determines winning number after wheel spin
        /// </summary>
        /// <param name="angel"></param>
        /// <returns></returns>
        private int DetermineWinningNumber(double angle)
        {
            //Each number represents a sector of a circle. Determine angle of each sector out of 37 (360/37)
            double sectorAngle = Constants.WheelPieceDegrees;
            
            //correct anti-clockwise spin angle with -1
            int determinant = (int)Math.Round(-1 * angle / sectorAngle); //gives position of winning number in array of wheel numbers
            if (determinant > 36)
            {
                determinant = 0;
            }
            return wheelNumbers[determinant];
        }

        /// <summary>
        /// Spins wheel
        /// </summary>
        /// <param name="_view"></param>
        public void SpinWheelGetAngle(WheelView _view)
        {
           
            if (gameViewModel.Player.Bets.Count != 0)
            {
                //reset wheel before each spin using Refresh method
                foreach (WheelPiece wheelPiece in WheelCollection)
                {
                    if (wheelPiece.IsWinningNumber)
                    {
                        wheelPiece.IsWinningNumber = false;
                    }
                }
                Refresh(WheelCollection); //refresh collection

                _view.BallControl.Visibility = Visibility.Visible; //Toss ball

                WheelView view = _view; //Wheel object
                //Random angle generator
                Random angleGenerator = new Random();
                //spin wheel counter-clockwise
                WheelStopAngle = -1 * angleGenerator.Next(0, 361);

                double angle = WheelStopAngle;

                #region initialize Double Animation
                //rotates 720 degress
                DoubleAnimation doubleSpinAnimation = new DoubleAnimation();
                doubleSpinAnimation.From = Constants.StartAngle;
                doubleSpinAnimation.To = Constants.FullCircleDegrees*3;
                doubleSpinAnimation.Duration = new Duration(TimeSpan.FromSeconds(Constants.WheelSpinDurationSeconds*3)); //duration of spin in seconds
                doubleSpinAnimation.FillBehavior = FillBehavior.Stop;
                
                CubicEase cubicEase = new CubicEase();
                cubicEase.EasingMode = EasingMode.EaseOut;
                doubleSpinAnimation.EasingFunction = cubicEase;
                PowerEase powerEase = new PowerEase();
                powerEase.EasingMode = EasingMode.EaseOut;
                //doubleSpinAnimation.RepeatBehavior = new RepeatBehavior(Constants.RepeatRatio);

                // rotates to winningnumber
                //DoubleAnimation spinWheelAmination = new DoubleAnimation();
                //spinWheelAmination.From = -Constants.FullCircleDegrees;
                //spinWheelAmination.To = angle;
                //spinWheelAmination.Duration = new Duration(TimeSpan.FromSeconds(Constants.WheelSpinDurationSeconds)); //duration of spin in seconds                                                                 
                //spinWheelAmination.FillBehavior = FillBehavior.HoldEnd;
                //spinWheelAmination.BeginTime = TimeSpan.FromSeconds(4);
                //spinWheelAmination.RepeatBehavior = new RepeatBehavior(Constants.RepeatRatio);
                //spinWheelAmination.Completed += new EventHandler(spinWheelAnimation_Completed);

                #endregion


                #region Ball animation
                //DoubleAnimation ballSpinAnimation = spinWheelAmination.Clone();
                DoubleAnimation ballSpinAnimation = new DoubleAnimation();
                ballSpinAnimation.From = -Constants.FullCircleDegrees;
                ballSpinAnimation.To = 360-angle;
                ballSpinAnimation.Duration = new Duration(TimeSpan.FromSeconds(4.5)); //duration of spin in seconds                                                                 
                ballSpinAnimation.FillBehavior = FillBehavior.HoldEnd;
                ballSpinAnimation.BeginTime = TimeSpan.FromSeconds(2);
                ballSpinAnimation.EasingFunction = powerEase;
                ballSpinAnimation.Completed += new EventHandler(ballSpinAnimation_Completed);
                //720 degrees
                DoubleAnimation ballDoubleSpinAnimation = doubleSpinAnimation.Clone();
                ballDoubleSpinAnimation.To = 720;
                ballDoubleSpinAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
                ballDoubleSpinAnimation.EasingFunction = null;
                #endregion

                #region MediaTimeline and media element for rolling ball
                //Ball media element
                MediaElement ballMediaElement = new MediaElement();
                    ballMediaElement.Volume = 3.0;
                    ballMediaElement.Visibility = Visibility.Hidden;
                    view.MainGrid.Children.Add(ballMediaElement); //add media to WheelView

                    // Ball media timeline (sound).
                    MediaTimeline ballRollingMediaTimeline = new MediaTimeline
                    {
                        FillBehavior = FillBehavior.Stop,
                        BeginTime = TimeSpan.FromSeconds(Constants.Zero),
                        Duration = new Duration(TimeSpan.FromSeconds(6)),
                        Source = new Uri(Constants.BallSoundFilePath, UriKind.Relative),
                    };
                    #endregion

                #region Add Storyboard children
                //Wheel
                Storyboard spinWheelStoryBoard = new Storyboard();
                spinWheelStoryBoard.Children.Add(doubleSpinAnimation); //add animation to storyboard 

                //Ball
                Storyboard spinBallStoryBoard = new Storyboard();
               
                spinBallStoryBoard.Children.Add(ballRollingMediaTimeline); //add media time line to storyboard
                spinBallStoryBoard.Children.Add(ballDoubleSpinAnimation); //add animation to storyboard
                spinBallStoryBoard.Children.Add(ballSpinAnimation); //add animation to storyboard
                spinBallStoryBoard.SlipBehavior = SlipBehavior.Slip; //ensures that animation and media starts at same time
                #endregion

                #region Sets animation targets
                //Wheel
                Storyboard.SetTarget(ballRollingMediaTimeline, ballMediaElement); //or //ballRollingMediaTimeline.SetValue(Storyboard.TargetProperty, ballMediaElement); 

                Storyboard.SetTarget(doubleSpinAnimation, view.WheelControl);
                Storyboard.SetTargetProperty(doubleSpinAnimation, new PropertyPath("RenderTransform.Angle"));
                //Ball
                Storyboard.SetTarget(ballDoubleSpinAnimation, view.BallControl);
                Storyboard.SetTargetProperty(ballDoubleSpinAnimation, new PropertyPath("RenderTransform.Children[1].Angle"));

                Storyboard.SetTarget(ballSpinAnimation, view.BallControl);
                Storyboard.SetTargetProperty(ballSpinAnimation, new PropertyPath("RenderTransform.Children[1].Angle"));
                #endregion

                //Begin storyboard
                spinWheelStoryBoard.Begin(view.WheelControl, true);
                spinBallStoryBoard.Begin(view.BallControl, true);

                #region Timer to make sure animation completes before setting winning number
                //var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(8) };
                //timer.Start();
                //timer.Tick += (sender, args) =>
                //{
                //    timer.Stop();
                //    //Get winning number
                //    WinningNumber = DetermineWinningNumber(WheelStopAngle);
                //    //view.Rotate.Angle = WheelStopAngle; //Saves rotation for next spin

                //    //change IsWinningNumber to true for winning wheelPiece
                //    foreach (WheelPiece piece in WheelCollection)
                //    {
                //        if (piece.Number == WinningNumber)
                //        {
                //            piece.IsWinningNumber = true;
                //        }
                //    }
                //    //Refresh wheelcollection to update UI
                //    Refresh(WheelCollection);

                //    MessageBox.Show($"Winning Number is {WinningNumber}", "WinningNumber number", MessageBoxButton.OK, MessageBoxImage.Information);
                //};

                //check if clock created when storyboard began has finished executing the animation
                //if (spinWheelStoryBoard.GetCurrentState(view.WheelControl) == ClockState.Stopped)
                //{
                //    //Get winning number
                //    WinningNumber = DetermineWinningNumber(WheelStopAngle);
                //    view.Rotate.Angle = WheelStopAngle; //Saves rotation for next spin

                //    //change IsWinningNumber to true for winning wheelPiece
                //    foreach (WheelPiece piece in WheelCollection)
                //    {
                //        if (piece.Number == WinningNumber)
                //        {
                //            piece.IsWinningNumber = true;
                //        }
                //    }
                //    //refresh wheelcollection to update UI
                //    Refresh(WheelCollection);

                //MessageBox.Show($"Winning Number is {WinningNumber}", "WinningNumber number", MessageBoxButton.OK, MessageBoxImage.Information);
                //}

                #endregion
            }
            else
            {
                MessageBox.Show("Please place a bet first");
            }
        }

        /// <summary>
        /// Calculate pay, set winning number and update wheel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ballSpinAnimation_Completed(object sender, EventArgs e)
        {
            //Get winning number
            GetWinningNumber();
            //Get Pay
            winAmount = gameViewModel.GameEngine.GetPayout(gameViewModel.Player.Bets);
            //Update player
            MessageBox.Show($"Winning Number is {WinningNumber} \n\n\r " +
                $"Winning amount {winAmount}", "Win", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Method refreshes observable collection in case attributes of existing collection object changees value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        private static void Refresh<T>(ObservableCollection<T> value)
        {
            CollectionViewSource.GetDefaultView(value).Refresh();
        }

        /// <summary>
        /// Method determines winning number, update wheel piece and refreshes collection
        /// </summary>
        private void GetWinningNumber()
        {
            //Get winning number
            WinningNumber = DetermineWinningNumber(WheelStopAngle);

            //change IsWinningNumber to true for winning wheelPiece
            foreach (WheelPiece piece in WheelCollection)
            {
                if (piece.Number == WinningNumber)
                {
                    piece.IsWinningNumber = true;
                }
            }
            //Refresh wheelcollection to update UI
            Refresh(WheelCollection);
        }
    }
}