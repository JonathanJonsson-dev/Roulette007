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
    public class WheelViewModel
    {
        //variables
        private readonly Wheel wheel = new Wheel();

        //int wheelAngel;

        //wheel numbers collection

        //a collection of wheel piesces
        public ObservableCollection<BoardPiece> WheelCollection { get; set; } = new ObservableCollection<BoardPiece>();

        public WheelViewModel()
        {
            FillWheel();
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
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Green,
                        BoardPieceNumber = wheel.wheelNumbers[i],
                    };

                    WheelCollection.Add(boardPiece);
                }
                else if(i % 2 != 0)
                {
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Red,
                        BoardPieceNumber = wheel.wheelNumbers[i],
                    };

                    WheelCollection.Add(boardPiece);
                }
                else
                {
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Black,
                        BoardPieceNumber = wheel.wheelNumbers[i],
                    };

                    WheelCollection.Add(boardPiece);
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

    }
}
