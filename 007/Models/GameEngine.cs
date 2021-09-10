using _007.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class GameEngine
    {
        private static readonly Random random = new Random();
        public int WinningNumber { get; set; }
        /// <summary>
        /// Generates the winning number for the round 
        /// </summary>
        /// <returns></returns>
        public int GenerateWinningNumber()
        {
            return WinningNumber = random.Next(37); //Returns a random integer between 0-36
        }
        /// <summary>
        /// Loops through the numbers in the bet and return a payout based upon odds
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        public int GetPayout(Bet bet)
        {
            foreach (var number in bet.Numbers)//Loops through every number in the bet to check against the winning number
            {
                
                if(number == WinningNumber)
                {
                    return bet.Amount * GetPayoutRatio(bet.Type); //Returns the players payout, (int)bet.Type = payout ratio found in BetType.cs
                }
            }
            return 0; //Returns nothing for the player because the have lost
        }
        private int GetPayoutRatio(BetType type)
        {
            switch (type)
            {
                case Data.BetType.Straightup:
                    return 35;
                    
                case Data.BetType.Split:
                    return 17;

                case Data.BetType.Basket: case Data.BetType.Street:
                    return 11;

                case Data.BetType.Corner:
                    return 8;

                case Data.BetType.Sixline: case Data.BetType.Column: case Data.BetType.Dozen:
                    return 2;

                case Data.BetType.Odd: case Data.BetType.Even: case Data.BetType.Red: case Data.BetType.Black: case Data.BetType.Low: case Data.BetType.High:
                    return 1;
            }
            return 0;
        }
      
        
    }
}
