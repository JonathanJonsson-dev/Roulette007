using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class Board
    {
        // All board numbers
        public readonly List<int> boardNumbers;

        //constructor
        public Board()
        {
            boardNumbers = new List<int>();
            //generate numbers
            GenerateBoardNumbers();
        }

        private void GenerateBoardNumbers()
        {
            if(boardNumbers == null)
            for(int i = 0; i < 37; i++)
            {
                boardNumbers.Add(i);
            }
        }
    }
}
