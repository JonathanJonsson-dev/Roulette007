using _007.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace _007.Models
{
    public class WheelPiece
    {
        #region Properties
        public bool IsRedNumber { get; set; } = false; //if number is read
        public bool IsBlackNumber { get; set; } = false; //if number is black
        public bool IsGreenNumber { get; set; } = false; //if number is green

        public int Label { get; set; } //Wheel piece number
        public double AngularPosition { get; set; } //Wheel piece position in a circle as an angle
        
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double PieceWidth { get; set; } //Width of wheel piece
        public double PieceHeight { get; set; }
        public double CenterPointX { get; set; } 
        public double CenterPointY { get; set; }

        /// <summary>
        /// Gets the collection of polygon points.
        /// </summary>
        public PointCollection Points { get; private set; }

        #endregion

        public void UpdateWheelPiece(double widthPixels, double heightPixels, double xPositionPixels, double yPositionPixels, double wheelCenterPointXPixels, double wheelCenterPointYPixels)
        {
            // Update polygon.
            Points = new PointCollection
            {
                new System.Windows.Point(xPositionPixels, yPositionPixels),
                new System.Windows.Point(xPositionPixels + widthPixels, yPositionPixels),
                new System.Windows.Point(xPositionPixels + (Constants.WheelPieceWidth1Percentage * widthPixels), yPositionPixels + heightPixels),
                new System.Windows.Point(xPositionPixels + (Constants.WheelPieceWidth2Percentage * widthPixels), yPositionPixels + heightPixels)
            };
            //RaisePropertyChanged("Points");

            // Update the x/y position and width of the pocket.
            //XPosition = xPositionPixels;
            //YPosition = yPositionPixels;
            //PieceWidth = widthPixels;

            //Update wheel center point.
            CenterPointX = wheelCenterPointXPixels;
            CenterPointY = wheelCenterPointYPixels;
        }
    }
}
