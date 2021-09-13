using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class Wheel
    {
        //According to single zero wheel
        public int[] wheelNumbers = {0,32,15,19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33,
            1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26};

        private Random randomAngle = new Random();

        public double wheelAngle;

        public Wheel()
        {
            wheelAngle = randomAngle.Next(361);
        }

       
    }
}
