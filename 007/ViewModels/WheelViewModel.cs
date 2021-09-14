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
        private double wheelPieceWidth;
        private double wheelPieceHeight;
        private double centerPointX;
        private double centerPointY;
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
                piece.UpdateWheelPiece(wheelPieceWidth, wheelPieceHeight, piece.XPosition, piece.YPosition, centerPointX, centerPointY);
            }
        }

        /// <summary>
        /// Calculate values for wheel piece variables
        /// </summary>
        private void DetermineWheelPieceValues()
        {
            wheelPieceWidth = (2* Math.PI * Constants.WheelRadius) / Constants.NumberOfWheelPieces;
            wheelPieceHeight = 2 * Constants.WheelRadius * Constants.WheelPieceHeightPercentage;
            centerPointX = Constants.MainBorderWidth / 2;
            centerPointY = Constants.MainBorderWidth / 2;
                        
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
                        Label = wheel.wheelNumbers[i],
                        AngularPosition = i * Constants.WheelPieceDegrees,
                        XPosition = CenterPointX + Constants.WheelRadius * Math.Cos((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        YPosition = CenterPointY + Constants.WheelRadius * Math.Sin((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        PieceWidth = wheelPieceWidth,
                        PieceHeight = wheelPieceHeight,
                    };

                    WheelCollection.Add(piece);
                }
                else if(i % 2 != 0)
                {
                    WheelPiece piece = new WheelPiece
                    {
                        IsRedNumber = true,
                        Label = wheel.wheelNumbers[i],
                        AngularPosition = i * Constants.WheelPieceDegrees,
                        XPosition = Constants.MainBorderWidth / 2 + Constants.WheelRadius * Math.Cos((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        YPosition = Constants.MainBorderWidth / 2 + Constants.WheelRadius * Math.Sin((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        PieceWidth = wheelPieceWidth,
                        PieceHeight = wheelPieceHeight,
                    };

                    WheelCollection.Add(piece);
                }
                else
                {
                    WheelPiece piece = new WheelPiece
                    {
                        IsBlackNumber = true,
                        Label = wheel.wheelNumbers[i],
                        AngularPosition = i * Constants.WheelPieceDegrees,
                        XPosition = Constants.MainBorderWidth / 2 + Constants.WheelRadius * Math.Cos((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        YPosition = Constants.MainBorderWidth / 2 + Constants.WheelRadius * Math.Sin((i * Constants.WheelPieceDegrees) * Math.PI / 180.0),
                        PieceWidth = wheelPieceWidth,
                        PieceHeight = wheelPieceHeight,
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
