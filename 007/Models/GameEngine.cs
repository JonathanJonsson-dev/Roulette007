using _007.Data;
using _007.ViewModels;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace _007.Models
{
    public class GameEngine
    {
        private readonly GameViewModel gameViewModel;
        private static readonly Random random = new Random();
        public int WinningNumber { get; set; }
        public GameEngine(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }
        /// <summary>
        /// Loops through the numbers in the bet and return a payout based upon odds
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        public double GetPayout(Bet bet)
        {
            foreach (var number in bet.Numbers)//Loops through every number in the bet to check against the winning number
            {
                
                if(number == WinningNumber)
                {
                    return bet.Value * GetPayoutRatio(bet.Type); //Returns the players payout
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
      
        public Bet CreateBet(Marker marker, Point point)// Handles bet made on number part of gameboard
        {
            bool placeholder = true;
            List<int> numbers = new List<int>();
            int numberToFind = 0;
            point.X = Math.Round(point.X);
            point.Y = Math.Round(point.Y);
            BetType betType = BetType.Straightup;
            if (point.X==115)//Checks for sixline or streetbet
            {
                if ((point.Y - 5) % 50 == 0)//Street bet
                {
                    betType = BetType.Street;
                }
                else //Sixline bet
                {
                    betType = BetType.Sixline;
                }
            }
            else if ((point.Y - 5) % 50 != 0 && (point.X + 10) % 50 != 0)//checks for corner bet
            {
                betType = BetType.Corner;
            }
            else if ((point.Y - 5) % 50 != 0 || (point.X + 10) % 50 !=0)//checks for split bet
            {
                betType = BetType.Split;
            }
            else//A number bet (Straightup)
            {
                point.Y = Math.Round(point.Y / 50) - 1; //Gets row
                point.X = Math.Round(point.X / 50) - 2; //Gets col
                numberToFind = (int)point.X + ((int)point.Y * 3); //Math to find the number 

                if (numberToFind < 0)
                    numberToFind = 0;
                numbers.Add(gameViewModel.BoardViewModel.Board[numberToFind].BoardPieceNumber);
                
            }
           
            
            Bet bet = new Bet
            {
                Mark = marker,
                Type = betType,
                Value = numberToFind,
                Numbers = numbers
            };
            return bet;
        }
        public Bet CreateBet(Marker marker, BetType betType, List<int> numbers)// handles bet not on number part of board like 1st 12 and 1-18 where numbers are know easily
        {

            Bet bet = new Bet
            {
                Mark = marker,
                Type = betType,
                Value = marker.Value,
                Numbers = numbers
            };
            return bet;
        }
    }
}
