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
        public int GetPayoutt(Bet bet)
        {
            foreach (var number in bet.Numbers)//Loops through every number in the bet to check against the winning number
            {
                if(number == winningNumber)
                {
                    return bet.Amount * GetOdds(bet.Type); // Returns bet amount times the odds eg. Betting on a single number with the odds 36/1 and bet amount of 10 will be 10 * 36 = 360 as payout
                }
            }
            return bet.Amount * -1; //Returns the negative number of the bet amount (1000 becomes -1000) as payout
        }
        private int GetOdds(BetType type)
        {
            return 1;//placeholder for the actual method
        }
      
        
    }
}
