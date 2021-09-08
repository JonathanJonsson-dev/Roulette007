using _007.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class GameEngine
    {
        private static readonly Random random = new Random();
        int winningNumber;
        /// <summary>
        /// Generates the winning number for the round 
        /// </summary>
        /// <returns></returns>
        public int GenerateWinningNumber()
        {
            return winningNumber = random.Next(37); //Returns a random integer between 0-36
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
                if(number == winningNumber)
                {
                    return bet.Amount * (int)bet.Type; //Returns the players payout, (int)bet.Type = payout ratio found in BetType.cs
                }
            }
            return bet.Amount * -1; //Returns the negative number of the bet amount (1000 becomes -1000) as payout
        }
      
      
        
    }
}
