using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Data
{
    public static class Constants
    {
        public const double NumberOfWheelPieces = 37;
        public const double WheelPieceDegrees = 9.7297; //Each number represents a sector of a circle. Agle of each sector out of 37 (360/37)
        public const double WheelPieceHeightPercentage = 0.35;
        public const double WheelPieceWidth1Percentage = 0.90;
        public const double WheelPieceWidth2Percentage = 0.10;
        public const int Zero = 0;
        public const double OuterWheelDiameterPercentage = 0.95;
        public const double CenterWheelDiameterPercentage = 0.80;
        public const double InnerWheelDiameterPercentage = 0.76;
        public const double MidPoint = 0.5;
        public const double StartAngle = 0;
        public const double StartPosition = 0;
        public const int WheelSpinDurationSeconds = 2;
        public const double FullCircleDegrees = 360;
        public const int RepeatRatio = 2;
        public const int MainBorderWidth = 450;
        public const int MainBorderHeight = 450;
        public const string BallSoundFilePath = "././Views/Utilities/RouletteWheelSpinn.mp3";
        public const double BallYOffsetPercentage = 0.90;
        public const int BallSpeedRatio = 3;
    }
}
