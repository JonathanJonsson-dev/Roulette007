using _007.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace _007.ViewModels
{
    public class SpinningWheelViewModel : BaseViewModel
    {
        public double Angle { get; set; }

        int[] wheelNumbers = new int[] { 0, 26, 3, 35, 12, 28, 7, 29, 18, 22, 9, 31, 14, 20, 1, 33, 16, 24, 5, 10, 23, 8, 30, 11, 36, 13, 27, 6, 34, 17, 25, 2, 21, 4, 19, 15, 32};

        public int WinningNumber { get; set; }

        public ICommand SpinnWheelCommand { get; }

        public SpinningWheelViewModel()
        {
            SpinnWheelCommand = new SpinnWheelCommand(this);
        }

        public void SpinnWheel()
        {
            Random random = new Random();
            Angle = random.Next(0,360);
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
