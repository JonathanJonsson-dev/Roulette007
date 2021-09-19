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

namespace _007.ViewModels
{
    public class WheelViewModel : BaseViewModel
    {
        #region Variables

        //According to single zero wheel
        private readonly int[] wheelNumbers = {0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33,
            1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26};
        #endregion

        #region Properties
        public double WheelStopAngle { get; set; } //angle att which the wheel stops
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
        public double CenterCircleDiameter { get; set; }
        public double OuterCircleDiameter { get; set; }
        public double OuterCircleOffsetX { get; set; }
        public double OuterCircleOffsetY { get; set; }
        public double CenterCircleOffsetX { get; set; }
        public double CenterCircleOffsetY { get; set; }
        public double CurrentAngle { get; set; }

        //public double CurrentAngle { get; set; }

        #endregion

        public WheelViewModel()
        {
            DetermineWheelPieceValues(); //Set values to wheel piece variables
            FillWheel();
            UpdateWheelPieceValues();
            //GetAngle();
            //DrawWheelLabels();

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

            //center and outer circles diameter and offsets
            CenterCircleDiameter = Constants.MainBorderWidth > Constants.MainBorderHeight ? Constants.CenterWheelDiameterPercentage * Constants.MainBorderHeight : Constants.CenterWheelDiameterPercentage * Constants.MainBorderWidth;
            OuterCircleDiameter = Constants.MainBorderWidth > Constants.MainBorderHeight ? Constants.OuterWheelDiameterPercentage * Constants.MainBorderHeight : Constants.OuterWheelDiameterPercentage * Constants.MainBorderWidth;

            OuterCircleOffsetX = (MainBoardWidth / 2) - (OuterCircleDiameter / 2);
            OuterCircleOffsetY = (MainBoardHeight / 2) - (CenterCircleDiameter / 2);

            CenterCircleOffsetX = (MainBoardWidth / 2) - (OuterCircleDiameter / 2);
            CenterCircleOffsetY = (MainBoardHeight / 2) - (CenterCircleDiameter / 2);
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
        private int DetermineWinningNumber(double angel)
        {
            //Each number represents a sector of a circle. Determine angle of each sector out of 37 (360/37)
            double sectorAngle = 9.7297;
            //correct anti-clockwise spin angle with -1
            int determinant = (int)Math.Floor(-1 * angel / sectorAngle); //gives position of winning number in array of wheel numbers

            return wheelNumbers[determinant];
        }

        public void SpinWheelGetAngle()
        {
            WheelView view = new WheelView(); //Wheel object

            //Random angle generator
            Random angleGenerator = new Random();
            //spin wheel counter-clockwise
            WheelStopAngle = -1 * angleGenerator.Next(0, 361);            
            //initialize Double Animation
            DoubleAnimation spinWheelAmination = new DoubleAnimation();
            spinWheelAmination.From = 0;
            spinWheelAmination.By = WheelStopAngle;           
            spinWheelAmination.Duration = TimeSpan.FromSeconds(30); //duration of spin in seconds
            spinWheelAmination.RepeatBehavior = new RepeatBehavior(2);
            spinWheelAmination.FillBehavior = FillBehavior.HoldEnd;

            spinWheelAmination.SetValue(Storyboard.TargetProperty, view.WheelControl);
            spinWheelAmination.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath(RotateTransform.AngleProperty)); 
                //or
            //Storyboard.SetTargetName(spinWheelAmination, "WheelControl");
            //Storyboard.SetTargetProperty(spinWheelAmination, new PropertyPath(RotateTransform.AngleProperty));

            //Ball media element
            MediaElement ballMediaElement = new MediaElement();
            view.MainGrid.Children.Add(ballMediaElement); //add media to WheelView
            //ballMediaElement.LoadedBehavior = MediaState.Play;
            //ballMediaElement.UnloadedBehavior = MediaState.Stop;
            ballMediaElement.Volume = 2.0;
            //ballMediaElement.IsMuted = false;
            ballMediaElement.MediaOpened += new RoutedEventHandler(BallMediaElementMediaOpenedEventHandler);

            // Ball media timeline (sound).
            MediaTimeline ballRollingMediaTimeline = new MediaTimeline
            {
                FillBehavior = FillBehavior.Stop,
                BeginTime = new TimeSpan(0,0,0),
                Duration = new Duration(TimeSpan.FromSeconds(60)),
                Source = new Uri(@"C:\Users\HP\Source\Repos\SUP21_Grupp7\007\Views\Utilities\BallRolling.mp4"),
            };
            ballRollingMediaTimeline.SetValue(Storyboard.TargetProperty, ballMediaElement); //or
            //Storyboard.SetTarget(ballRollingMediaTimeline, ballMediaElement);


            //Storyboard
            Storyboard spinWheelStoryBoard = new Storyboard(); 
            spinWheelStoryBoard.Children.Add(spinWheelAmination); //add animation to storyboard    
            spinWheelStoryBoard.Children.Add(ballRollingMediaTimeline); //add media time line to storyboard
            spinWheelStoryBoard.SlipBehavior = SlipBehavior.Slip;
            //Start the storyboard Specifying a containing element
            spinWheelStoryBoard.Begin(view.WheelControl, true);

            //spinWheelStoryBoard.Completed += new EventHandler(WheelSpinStopped); 
            //check is clock created when storyboard began has finished executing the animation
            if (spinWheelStoryBoard.GetCurrentState(view.WheelControl) == ClockState.Stopped)
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
            }
        }

        /// <summary>
        /// Handles the MediaOpenedEvent for the BallMediaElement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BallMediaElementMediaOpenedEventHandler(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = sender as MediaElement;
            mediaElement.Play();
        }
    }
}
