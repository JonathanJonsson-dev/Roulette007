using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _007.ViewModels
{
    public class WheelViewModel : BaseViewModel
    {
        //variables
        private readonly Wheel wheel = new Wheel();

        //int wheelAngel;

        //a collection of wheel piesces
        public ObservableCollection<WheelPiece> WheelCollection { get; set; } = new ObservableCollection<WheelPiece>();

        public double CurrentAngle { get; set; }

        public WheelViewModel()
        {
            FillWheel();
            //GetAngle();
        }

        /// <summary>
        /// Method fill wheel with numbers
        /// </summary>
        private void FillWheel()
        {
             for(int i=0; i<wheel.wheelNumbers.Length; i++)
            {
                if (i == 0)
                {
                    WheelPiece piece = new WheelPiece
                    {
                       IsGreenNumber = true,
                       Label = wheel.wheelNumbers[i],
                    };

                    WheelCollection.Add(piece);
                }
                else if(i % 2 != 0)
                {
                    WheelPiece piece = new WheelPiece
                    {
                        IsRedNumber = true,
                        Label = wheel.wheelNumbers[i],
                    };

                    WheelCollection.Add(piece);
                }
                else
                {
                    WheelPiece piece = new WheelPiece
                    {
                        IsBlackNumber = true,
                        Label = wheel.wheelNumbers[i],
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
            //Each number represents a sector of a circle. Determine angle of each sector out of 37
            decimal sectorAngle = 360 / 37;

            int determinant = (int)Math.Truncate(angel / sectorAngle); //gives position of winning number in array of wheel numbers

            return wheel.wheelNumbers[determinant];
        }

        //public void GetAngle(double angle)
        //{
           
        //    CurrentAngle = angle;
        //}

    }
}
