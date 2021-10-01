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

        Storyboard spinBallStoryBoard; //storyboard to spin ball

        private WheelView wheel;
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

        #region Events

        #endregion

        #region Constructor
        public WheelViewModel(GameViewModel gameViewModel)
        {
            try
            {
                this.gameViewModel = gameViewModel;
                DetermineWheelPieceValues(); //Set values to wheel piece variables
                FillWheel();
                UpdateWheelPieceValues(); //More wheel piece variable value
            }
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.Constructor: " + ex.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Set values to wheel piece object properties
        /// </summary>
        private void UpdateWheelPieceValues()
        {
            try
            {
                foreach(WheelPiece piece in WheelCollection)
                {
                    piece.UpdateWheelPiece(WheelPieceWidth, WheelPieceHeight, piece.XPosition, piece.YPosition, CenterPointX, CenterPointY);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.UpdateWheelPieceValues(): " + ex.ToString());
            }
        }

        /// <summary>
        /// Calculate values for wheel piece variables
        /// </summary>
        private void DetermineWheelPieceValues()
        {
            try
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
            }
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.DetermineWheelPieceValues(): " + ex.ToString());
            }
        }

        /// <summary>
        /// Method fill wheel with numbers
        /// </summary>
        private void FillWheel()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.FillWheel(): " + ex.ToString());
            }
        }
        
        /// <summary>
        /// Method determines winning number after wheel spin
        /// </summary>
        /// <param name="angel"></param>
        /// <returns></returns>
        private int DetermineWinningNumber(double angle)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.DetermineWinningNumber(): " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to toss ball and animate bounce
        /// </summary>
        /// <param name="wheel"></param>
        private void TossBall()
        {
            try
            {
                wheel.BallControl.Visibility = Visibility.Visible; //Toss ball

                //Ball toss mediaelement
                MediaElement tossBallMediaElement = new MediaElement
                {
                    Volume = 5.0,
                    Visibility = Visibility.Hidden
                };
                wheel.MainGrid.Children.Add(tossBallMediaElement); //add media to WheelView

                // Ball toss media timeline (sound)
                MediaTimeline tossBallMediaTimeline = new MediaTimeline
                {
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                    Source = new Uri(Constants.BallTossFilePath, UriKind.Relative),
                    RepeatBehavior = new RepeatBehavior(3)
                };

                //Bounce ball
                DoubleAnimation tossBallAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 20,
                    Duration = new Duration(TimeSpan.FromSeconds(1)), //duration of bounce in seconds
                    BeginTime = TimeSpan.FromSeconds(0),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(3)
                };
                //easing function
                BounceEase bounces = new BounceEase
                {
                    Bounces = 1,
                    Bounciness = 3,
                    EasingMode = EasingMode.EaseOut
                };
                tossBallAnimation.EasingFunction = bounces;
                //Set targets
                Storyboard.SetTarget(tossBallMediaTimeline, tossBallMediaElement);
                Storyboard.SetTarget(tossBallAnimation, wheel.BallControl);
                Storyboard.SetTargetProperty(tossBallAnimation, new PropertyPath("RenderTransform.Children[0].Y"));
                //Storyboard
                Storyboard tossBallStoryboard = new Storyboard();
                tossBallStoryboard.Children.Add(tossBallAnimation);
                tossBallStoryboard.Children.Add(tossBallMediaTimeline);
                tossBallStoryboard.SlipBehavior = SlipBehavior.Slip;
                //Begin storyboard
                tossBallStoryboard.Begin(wheel.BallControl, true);
            }
            catch(Exception ex)
            {
                throw new Exception("WheelViewModel.TossBall(): " + ex.ToString());
            }
        }

        /// <summary>
        /// Spins wheel
        /// </summary>
        /// <param name="_view"></param>
        public void SpinWheelGetAngle(WheelView _wheel)
        {
            try
            {
                if(wheel == null)
                {
                    wheel = _wheel; //initialise wheel object
                }
                
                    spinBallStoryBoard = new Storyboard(); //initialise ball spin storyboard
                    spinBallStoryBoard.Completed += new EventHandler(WheelSpin_Completed); //spin stopped event
                

                //Checks for ongoing spin. only runs if none.
                //if (spinBallStoryBoard.GetCurrentState(wheel.BallControl) == ClockState.Stopped || spinBallStoryBoard.GetIsPaused(wheel.BallControl) == false)
                    //        {
                //checks for bets
                if (gameViewModel.Bets.Count != 0)
                {
                    //Disable spin wheel button to prevent further spin
                    wheel.btnSpin.IsEnabled = false;
                    //reset wheel before each spin using Refresh method
                    foreach (WheelPiece wheelPiece in WheelCollection)
                    {
                        if (wheelPiece.IsWinningNumber)
                        {
                            wheelPiece.IsWinningNumber = false;
                        }
                    }
                    RefreshCollection(WheelCollection); //refresh collection

                    #region Toss ball
                    TossBall();
                    //wheel.BallControl.Visibility = Visibility.Visible;

                    #endregion


                    //Random number generator
                    Random numberGenerator = new Random();
                    //spin wheel counter-clockwise
                    WheelStopAngle = -1 * (Constants.WheelPieceDegrees * numberGenerator.Next(1, 38));

                    double angle = WheelStopAngle;

                    #region initialize Double Animation
                    //rotates 1080 degress
                    DoubleAnimation doubleSpinAnimation = new DoubleAnimation
                    {
                        From = Constants.StartAngle,
                        To = Constants.FullCircleDegrees * Constants.SpeedRatio,
                        Duration = new Duration(TimeSpan.FromSeconds(Constants.WheelSpinDurationSeconds * Constants.SpeedRatio)), //duration of spin in seconds
                        FillBehavior = FillBehavior.Stop
                    };

                    CubicEase cubicEase = new CubicEase
                    {
                        EasingMode = EasingMode.EaseOut
                    };
                    doubleSpinAnimation.EasingFunction = cubicEase;

                    #endregion

                    #region Ball animation
                    //DoubleAnimation ballSpinAnimation = spinWheelAmination.Clone();
                    DoubleAnimation ballSpinAnimation = new DoubleAnimation
                    {
                        From = -Constants.FullCircleDegrees,
                        To = Constants.FullCircleDegrees - angle,
                        Duration = new Duration(TimeSpan.FromSeconds(4.5)), //duration of spin in seconds                                                                 
                        FillBehavior = FillBehavior.HoldEnd,
                        BeginTime = TimeSpan.FromSeconds(2)
                    };

                    PowerEase powerEase = new PowerEase
                    {
                        EasingMode = EasingMode.EaseOut
                    };
                    ballSpinAnimation.EasingFunction = powerEase;
               
                    //720 degrees
                    DoubleAnimation ballDoubleSpinAnimation = doubleSpinAnimation.Clone();
                    ballDoubleSpinAnimation.To = 720;
                    ballDoubleSpinAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
                    ballDoubleSpinAnimation.EasingFunction = null;
                    #endregion

                    #region MediaTimeline and media element for rolling ball
                    //Ball media element
                    MediaElement ballMediaElement = new MediaElement
                    {
                        Volume = 3.0,
                        Visibility = Visibility.Hidden
                    };
                    wheel.MainGrid.Children.Add(ballMediaElement); //add media to WheelView

                    // Ball media timeline (sound).
                    MediaTimeline ballRollingMediaTimeline = new MediaTimeline
                    {
                        FillBehavior = FillBehavior.Stop,
                        BeginTime = TimeSpan.FromSeconds(Constants.Zero),
                        Duration = new Duration(TimeSpan.FromSeconds(5)),
                        Source = new Uri(Constants.BallSoundFilePath, UriKind.Relative),
                    };
                    #endregion

                    #region Add Storyboard children
                    //Wheel
                    Storyboard spinWheelStoryBoard = new Storyboard();
                    spinWheelStoryBoard.Children.Add(doubleSpinAnimation); //add animation to storyboard 

                    //Ball
                    spinBallStoryBoard.Children.Add(ballRollingMediaTimeline); //add media time line to storyboard
                    spinBallStoryBoard.Children.Add(ballDoubleSpinAnimation); //add animation to storyboard
                    spinBallStoryBoard.Children.Add(ballSpinAnimation); //add animation to storyboard
                    spinBallStoryBoard.SlipBehavior = SlipBehavior.Slip; //ensures that animation and media starts at same time
                    #endregion

                    #region Sets animation targets
                    //Wheel
                    Storyboard.SetTarget(ballRollingMediaTimeline, ballMediaElement); //or //ballRollingMediaTimeline.SetValue(Storyboard.TargetProperty, ballMediaElement); 

                    Storyboard.SetTarget(doubleSpinAnimation, wheel.WheelControl);
                    Storyboard.SetTargetProperty(doubleSpinAnimation, new PropertyPath("RenderTransform.Angle"));
                    //Ball
                    Storyboard.SetTarget(ballDoubleSpinAnimation, wheel.BallControl);
                    Storyboard.SetTargetProperty(ballDoubleSpinAnimation, new PropertyPath("RenderTransform.Children[1].Angle"));

                    Storyboard.SetTarget(ballSpinAnimation, wheel.BallControl);
                    Storyboard.SetTargetProperty(ballSpinAnimation, new PropertyPath("RenderTransform.Children[1].Angle"));
                    #endregion

                    //Begin storyboard
                    spinWheelStoryBoard.Begin(wheel.WheelControl, true);
                    spinBallStoryBoard.Begin(wheel.BallControl, true);

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
                //}
            }
            catch(Exception ex)
            {
                throw new Exception("WheelViewModel.SpinWheelGetAngle(): " + ex.ToString());
            }

        }

        /// <summary>
        /// Calculate pay, set winning number and update wheel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WheelSpin_Completed(object sender, EventArgs e)
        {
            try
            {
                //Get winning number
                GetWinningNumber();
                //Get Pay
                winAmount = gameViewModel.GameEngine.GetPayout(gameViewModel.Bets);
                //Update player
                MessageBox.Show($"Winning Number is {WinningNumber} \n\n\r " +
                    $"Winning amount {winAmount}", "Win", MessageBoxButton.OK, MessageBoxImage.Information);
                //enables spin button once spinning is completed
                wheel.btnSpin.IsEnabled = true;
                gameViewModel.GameEngine.NextRound();
            }
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.WheelSPin_Completed(): " + ex.ToString());
            }
        }

        /// <summary>
        /// Method refreshes observable collection in case attributes of existing collection object changees value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        private static void RefreshCollection<T>(ObservableCollection<T> value)
        {
            try
            {
                CollectionViewSource.GetDefaultView(value).Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.Refresh(): " + ex.ToString());
            }
        }

        /// <summary>
        /// Method determines winning number, update wheel piece and refreshes collection
        /// </summary>
        private void GetWinningNumber()
        {
            try
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
                RefreshCollection(WheelCollection);
            }
            catch (Exception ex)
            {
                throw new Exception("WheelViewModel.GetWinningNumber(): " + ex.ToString());
            }
        }
    }
}