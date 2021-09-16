﻿using _007.Data;
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

namespace _007.ViewModels
{
    public class WheelViewModel : BaseViewModel
    {
        #region Variables

        //According to single zero wheel
        private readonly int[] wheelNumbers = {0,32,15,19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33,
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
            //wheelPieceHeight = 2 * Constants.WheelRadius * Constants.WheelPieceHeightPercentage;
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

        //private void DrawWheelLabels()
        //{
        //    public int[] Labels
        //{
        //    get { return (int[])GetValue(LabelsProperty); }
        //    set { SetValue(LabelsProperty, value); }
        //}

        //public static readonly DependencyProperty LabelsProperty =
        //DependencyProperty.Register("Labels", typeof(int[]), typeof(WheelPiece), new PropertyMetadata(null, OnLabelsChanged));

        //private static void OnLabelsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    ((WheelPiece)d).InvalidateVisual();
        //}

        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    if (Labels == null || Labels.Length == 0)
        //        return;
        //    var centerX = this.ActualWidth / 2;
        //    var centerY = this.ActualHeight / 2;
        //    var rad = Math.Min(this.ActualWidth / 2, this.ActualHeight / 2);
        //    for (int i = 0; i < Labels.Length; i++)
        //    {
        //        var angle = 360 / (Labels.Length) * i;
        //        var x = centerX + rad * Math.Cos(angle * Math.PI / 180.0);
        //        var y = centerY + rad * Math.Sin(angle * Math.PI / 180.0);
        //        FormattedText text = new FormattedText(
        //            Labels[i],
        //            CultureInfo.GetCultureInfo("en-us"),
        //            FlowDirection.LeftToRight,
        //            new Typeface("Verdana"),
        //            12,
        //            Brushes.Black);
        //        x -= text.Width / 2;
        //        y -= text.Height / 2;
        //        drawingContext.DrawText(text, new Point(x, y));
        //    }
        //}


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
                        //XPosition = CenterPointX + (WheelPieceDiameter / 2) * Math.Cos((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        //YPosition = CenterPointY + (WheelPieceDiameter / 2) * Math.Sin((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
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
                        //XPosition = CenterPointX + (WheelPieceDiameter / 2) * Math.Cos((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        //YPosition = CenterPointY / 2 + (WheelPieceDiameter / 2) * Math.Sin((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
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
                        //XPosition = CenterPointX + (WheelPieceDiameter / 2) * Math.Cos((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        //YPosition = CenterPointY + (WheelPieceDiameter / 2) * Math.Sin((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
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
        /// Method fill wheel with numbers
        /// </summary>
        //private void FillWheel()
        //{
        //    for (int i = 0; i < wheelNumbers.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            WheelPiece piece = new WheelPiece
        //            {
        //                IsGreenNumber = true,
        //                Number = wheelNumbers[i],
        //            };

        //            WheelCollection.Add(piece);
        //        }
        //        else if (i % 2 != 0)
        //        {
        //            WheelPiece piece = new WheelPiece
        //            {
        //                IsRedNumber = true,
        //                Number = wheelNumbers[i],
        //            };

        //            WheelCollection.Add(piece);
        //        }
        //        else
        //        {
        //            WheelPiece piece = new WheelPiece
        //            {
        //                IsBlackNumber = true,
        //                Number = wheelNumbers[i],
        //            };

        //            WheelCollection.Add(piece);
        //        }
        //    }
        //}

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
                //Random angle generator
                Random angleGenerator = new Random();
                //spin wheel counter-clockwise
                WheelStopAngle = -1 * angleGenerator.Next(0, 361);
                //Storyboard
                Storyboard spinStoryBoard = new Storyboard();
                //initialize Double Animation
                DoubleAnimation spinDoubleAmination = new DoubleAnimation();
                spinDoubleAmination.FillBehavior = FillBehavior.HoldEnd;
                //duration of spin in seconds
                spinDoubleAmination.Duration = TimeSpan.FromSeconds(30);
                spinDoubleAmination.RepeatBehavior = new RepeatBehavior(2);
                Storyboard.SetTargetName(spinDoubleAmination, "WheelSpin");
                Storyboard.SetTargetProperty(spinDoubleAmination, new PropertyPath(RotateTransform.AngleProperty));
                spinStoryBoard.Children.Add(spinDoubleAmination);

                //spinStoryBoard.Begin(WheelView. .WheelControl, true);

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
}
