using _007.Data;
using _007.ViewModels;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Media;

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
        public void GetPayout(ObservableCollection<Bet> bets)
        {
            int totalPayout = 0;
            
            foreach (var bet in bets)//Loops through every number in the bet to check against the winning number
            {
                foreach (var number in bet.Numbers)
                {
                    if (number == gameViewModel.WheelViewModel.WinningNumber)
                    {
                        totalPayout+= bet.Value * GetPayoutRatio(bet.Type); //Returns the players payout
                    }
                }
                gameViewModel.gameView.board.Children.Remove(bet.Mark);


            }
            gameViewModel.Player.Bets.Clear();
           
            MediaPlayer player = new MediaPlayer();
            if (totalPayout > 0)
            {
                if (random.NextDouble() > 0.5) // Play random winning sound. 
                {
                    player.Open(new Uri(@"Resources\WinningSound1.wav", UriKind.Relative));
                    player.Volume = 0.1;
                    player.Play();
                }
                else
                {
                    player.Open(new Uri(@"Resources\WinningSound2.mp3", UriKind.Relative));
                    player.Volume = 0.1;
                    player.Play();
                }

                //SoundPlayer sound = new SoundPlayer(Properties.Resources.WinningSound1);
                //sound.Play();
            }
            else
            {
                player.Open(new Uri(@"Resources\LosingSound.wav", UriKind.Relative));
                player.Volume = 0.1;
                player.Play();
                //SoundPlayer sound = new SoundPlayer(Properties.Resources.LosingSound);
                //sound.Play();
            }
            gameViewModel.Player.Pot += totalPayout; //Returns nothing for the player because the have lost
            
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
                case Data.BetType.Fivebet:
                    return 3;

                case Data.BetType.Sixline: case Data.BetType.Column: case Data.BetType.Dozen:
                    return 2;

                case Data.BetType.Odd: case Data.BetType.Even: case Data.BetType.Red: case Data.BetType.Black: case Data.BetType.Low: case Data.BetType.High:
                    return 1;
            }
            return 0;
        }
      
        public Bet CreateBet(Marker marker, Point point)// Handles inside bets
        {
            
            List<int> numbers = new List<int>();
            int numberToFind = 0;
            int row;
            int col;
            point.X = Math.Round(point.X);
            point.Y = Math.Round(point.Y);
            BetType betType = BetType.Straightup;
            if(point.Y == 30)//Basket or Fivebet
            {
                betType = BetType.Basket;
                if (point.X ==115)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        numbers.Add(i);
                    }
                    betType = BetType.Fivebet;
                }
                else if(point.X == 165)
                {
                    numbers.Add(0);
                    numbers.Add(1);
                    numbers.Add(2);
                }
                else
                {
                    numbers.Add(0);
                    numbers.Add(2);
                    numbers.Add(3);
                }
                
                
            }
            else if (point.X==115)//Checks for sixline, streetbet
            {
                if ((point.Y - 5) % 50 == 0)//Street bet
                {
                    betType = BetType.Street;
                    row = (int)Math.Round(point.Y / 50)-1; //Gets row
                    for(int i = 1; i <= 3; i++)
                    {
                        numbers.Add((row * 3) + i);//Math to get numbers
                    }
                }
                else //Sixline bet
                {
                    betType = BetType.Sixline;
                  
                    for (int i = 0; i<=50; i+=50)
                    {
                        row = (int)Math.Round((point.Y -25 + i) / 50) - 1;
                        for (int m = 1; m <= 3; m++)
                        {
                            numbers.Add((row * 3) + m);//Math to get numbers
                        }
                    }
                    
                }
            }
            else if ((point.Y - 5) % 50 != 0 && (point.X + 10) % 50 != 0)//checks for corner bet
            {
                betType = BetType.Corner;
                col = (int)Math.Round(point.X / 50) - 2; //Gets col
                for (int i = 0; i <= 50; i += 50)
                {
                    row = (int)Math.Round((point.Y - 25 + i) / 50) - 1;
                   
                    for (int m = 0; m < 2; m++)
                    {
                        numbers.Add((row * 3) + (col + m));//Math to get numbers
                    }
                }
            }
            else if ((point.Y - 5) % 50 != 0 || (point.X + 10) % 50 !=0)//checks for split bet
            {
                betType = BetType.Split;
                if ((point.Y - 5) % 50 != 0) 
                {
                    col = (int)Math.Round(point.X / 50) - 2; //Gets col
                    for (int i = 0; i <= 50; i += 50)
                    {
                        row = (int)Math.Round((point.Y - 25 + i) / 50) - 1;



                        numbers.Add((row * 3) + col);//Math to get numbers

                    }
                }
                else
                {
                    row = (int)Math.Round(point.Y / 50) - 1; //Gets row
                    for (int i = 0; i <= 50; i += 50)
                    {
                        col = (int)Math.Round((point.X - 25 + i) / 50) - 2; //Gets col



                        numbers.Add((row * 3) + col);//Math to get numbers

                    }
                }
            }
            else//A number bet (Straightup)
            {
                row = (int)Math.Round(point.Y / 50) - 1; //Gets row
                col = (int)Math.Round(point.X / 50) - 2; //Gets col
                numberToFind = col + (row * 3); //Math to find the number 

                if (numberToFind < 0)
                    numberToFind = 0;
                numbers.Add(gameViewModel.BoardViewModel.Board[numberToFind].BoardPieceNumber);
                
            }
           
            
            Bet bet = new Bet
            {
                Mark = marker,
                Type = betType,
                Value = marker.Value,
                Numbers = numbers
            };
            return bet;
        }
        public Bet CreateBet(Marker marker, BetType betType, Point point)// handles outside bet
        {
            List<int> numbers = new List<int>();
            switch (betType)
            {
                case Data.BetType.Dozen:
                    if(point.Y==130)
                    {
                        for(int i = 1; i <= 12; i++)
                        {
                            numbers.Add(i);
                        }
                    }
                    else if(point.Y==330)
                    {
                        for (int i = 12; i <= 24; i++)
                        {
                            numbers.Add(i);
                        }
                    }
                    else
                    {
                        for (int i = 24; i <= 36; i++)
                        {
                            numbers.Add(i);
                        }
                    }
                    break;
                case Data.BetType.Column:
                    if (point.X == 140)
                    {
                        for (int i = 1; i <= 36; i+=3)
                        {
                            numbers.Add(i);
                        }
                    }
                    else if (point.X == 190)
                    {
                        for (int i = 2; i <= 36; i += 3)
                        {
                            numbers.Add(i);
                        }
                    }
                    else
                    {
                        for (int i = 3; i <= 36; i += 3)
                        {
                            numbers.Add(i);
                        }
                    }
                    break;
                case Data.BetType.Low:
                    for(int i = 1; i <=18; i++)
                    {
                        numbers.Add(i);
                    }
                    break;
                case Data.BetType.High:
                    for (int i = 19; i <= 36; i++)
                    {
                        numbers.Add(i);
                    }
                    break;
                case Data.BetType.Odd:
                    for(int i = 1; i <= 36; i++)
                    {
                        if (i % 2 != 0)
                        {
                            numbers.Add(i);
                        }
                    }
                    break;
                case Data.BetType.Even:
                    for (int i = 1; i <= 36; i++)
                    {
                        if (i % 2 == 0)
                        {
                            numbers.Add(i);
                        }
                    }
                    break;
                case Data.BetType.Red:
                    foreach (var boardPiece in gameViewModel.BoardViewModel.Board)
                    {
                        if(boardPiece.BoardPieceColor == Brushes.Red)
                        {
                            numbers.Add(boardPiece.BoardPieceNumber);
                        }
                    }
                    break;
                case Data.BetType.Black:
                    foreach (var boardPiece in gameViewModel.BoardViewModel.Board)
                    {
                        if (boardPiece.BoardPieceColor == Brushes.Black)
                        {
                            numbers.Add(boardPiece.BoardPieceNumber);
                        }
                    }
                    break;




            
            }
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
