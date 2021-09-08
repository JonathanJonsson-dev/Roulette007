using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class GameEngine
    {
        private static readonly Random random = new Random();

        public GameEngine()
        {

        }
       
        public int GetRandomNumber()
        {
            return random.Next(37); //Returns a random integer between 0-36
        }
        
    }
}
