using _007.Commands;
using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _007.ViewModels
{
    public class WheelViewModel : BaseViewModel
    {
        public double Angle { get; set; }

        int[] wheelNumbers = new int[] { 0, 26, 3, 35, 12, 28, 7, 29, 18, 22, 9, 31, 14, 20, 1, 33, 16, 24, 5, 10, 23, 8, 30, 11, 36, 13, 27, 6, 34, 17, 25, 2, 21, 4, 19, 15, 32 };

        public int WinningNumber { get; set; }

        public ICommand SpinnWheelCommand { get; }

        //variables
        private readonly Wheel wheel = new Wheel();

        //int wheelAngel;

        //wheel numbers collection

        //a collection of wheel piesces
        public ObservableCollection<BoardPiece> WheelCollection { get; set; } = new ObservableCollection<BoardPiece>();

        public WheelViewModel()
        {
            FillWheel();
            SpinnWheelCommand = new SpinnWheelCommand(this);
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
        /// <summary>
        /// Spinns wheel and sets the prop winningnumber. 
        /// </summary>
        public void SpinnWheel()
        {
            Random random = new Random();
            Angle = random.Next(0, 360);
            double degreesPerSlice = 360.00 / 37.00;
            int winningNumberIndex = (int)Math.Floor(Angle / degreesPerSlice);
            if (winningNumberIndex > 36)
            {
                WinningNumber = wheelNumbers[36];
            }
            else
            {
                WinningNumber = wheelNumbers[winningNumberIndex];
            }
        }

    }
}
