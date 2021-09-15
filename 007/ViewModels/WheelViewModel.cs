using _007.Data;
using _007.Models;
using System;
using System.Collections.ObjectModel;

namespace _007.ViewModels
{
    public class WheelViewModel : BaseViewModel
    {
        //variables
        private readonly Wheel wheel = new Wheel();

        //wheel piece variables
        //private double WheelPieceWidth;
        //private double WheelPieceHeight;
        //private double CenterPointX;
        //private double CenterPointY;
        //private double wheelPieceDiameter;
        //private double xPosition ;
        //private double yPosition;

        //int wheelAngel;

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
             for (int i=0; i<wheel.wheelNumbers.Length; i++)
            {
                if (i == 0)
                {

                    WheelPiece piece = new WheelPiece
                    {
                        IsGreenNumber = true,
                        Number = wheel.wheelNumbers[i],
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
                        Number = wheel.wheelNumbers[i],
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
                        Number = wheel.wheelNumbers[i],
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
        /// Method determines winning number after wheel spin
        /// </summary>
        /// <param name="angel"></param>
        /// <returns></returns>
        private int DetermineWinningNumber(int angel)
        {
            int determinant = (int)Math.Truncate(angel / Constants.WheelPieceDegrees); //gives position of winning number in array of wheel numbers

            return wheel.wheelNumbers[determinant];
        }

        //public void GetAngle(double angle)
        //{
           
        //    CurrentAngle = angle;
        //}

    }
}
