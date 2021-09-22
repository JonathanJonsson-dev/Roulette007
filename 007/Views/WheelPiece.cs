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
        public bool IsWinningNumber { get; set; } = false; //If number is winning number
        public int Number { get; set; } //Wheel piece number
        public double AngularPosition { get; set; } //Wheel piece position in a circle as an angle
        public string Label //Piece label
        {
            get { return Number.ToString(); }
        }        
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

        /// <summary>
        /// Updates wheel piece properties
        /// </summary>
        /// <param name="widthPixels"></param>
        /// <param name="heightPixels"></param>
        /// <param name="xPositionPixels"></param>
        /// <param name="yPositionPixels"></param>
        /// <param name="wheelCenterPointXPixels"></param>
        /// <param name="wheelCenterPointYPixels"></param>
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

            //Update wheel center point.
            CenterPointX = wheelCenterPointXPixels;
            CenterPointY = wheelCenterPointYPixels;
        }

    }
}
