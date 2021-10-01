using _007.Data;
using _007.ViewModels;
using _007.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace _007.Models
{
    public class GameEngine
    {
        private readonly GameViewModel gameViewModel;
        private static readonly Random random = new Random();
        
       
        private int bonusRatio = 1;
     
        private int poweredUpBoardPieceId;
        public GameEngine(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        private void SaveHighscore()
        {
            List<Highscore> highscores = new List<Highscore>();

            foreach (HighscorePiece highscorePiece in gameViewModel.Highscores)
            {
                Highscore highscore = new Highscore {PlayerName = highscorePiece.PlayerName, Score=highscorePiece.Score};
                highscores.Add(highscore);
            }

            var json = JsonConvert.SerializeObject(highscores);
            File.WriteAllText("highscores.json", json);
        }

        /// <summary>
        /// Checks if the current player pot is higher than highest value in highscores. Then add the score to highscore collection. 
        /// Sorts by descending order and removes the last item if the collection is larger than 5 items. 
        /// </summary>
        private void CheckHighscore()
        {
            int maxValue = MaxValueObservableCollection();
            if (gameViewModel.Pot > maxValue)
            {
                HighscorePiece scorePiece = new HighscorePiece() { PlayerName = gameViewModel.Name, Score = gameViewModel.Pot };
                gameViewModel.Highscores.Add(scorePiece);
            }
            this.gameViewModel.Highscores = new ObservableCollection<HighscorePiece>(gameViewModel.Highscores.OrderByDescending(o => o.Score)); // Sorts the Highscore collection in descending order.

            if (gameViewModel.Highscores.Count > 5)
            {
                this.gameViewModel.Highscores.Remove(gameViewModel.Highscores.Last());
            }
        }

        /// <summary>
        /// Gets the maximum score from highscores collection. 
        /// </summary>
        /// <returns>maxValue</returns>
        private int MaxValueObservableCollection()
        {
            int maxValue = 0;
            foreach (HighscorePiece game in gameViewModel.Highscores)
            {
                if (game.Score > maxValue)
                {
                    maxValue = game.Score;
                }
            }
            return maxValue;
        }

        #region
        /// <summary>
        /// Loops through the numbers in the bet and return a payout based upon BetType
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        public int GetPayout(ObservableCollection<Bet> bets)
        {
            int totalPayout = 0;
            
            foreach (var bet in bets)//Loops through every number in the bet to check against the winning number
            {
                foreach (var number in bet.Numbers)
                {
                    if (number == gameViewModel.WheelViewModel.WinningNumber)
                    {
                        if(bet.Type == gameViewModel.BoardViewModel.CompleteBoard[poweredUpBoardPieceId].Type) //If bet type = the powered up bets type
                        {
                            totalPayout += bet.Value * GetPayoutRatio(bet.Type) * bonusRatio + bet.Value; 
                        }
                        else
                        {
                            totalPayout += bet.Value * GetPayoutRatio(bet.Type) + bet.Value; 

                        }


                    }
                }
                gameViewModel.gameView.board.Children.Remove(bet.Mark);
            }
            
            gameViewModel.Bets.Clear();
            PlayWinningLosingSound(totalPayout);
            gameViewModel.Pot += totalPayout; //Returns nothing for the player because the have lost
            CheckHighscore();
            SaveHighscore();
            return totalPayout;
        }
        /// <summary>
        /// Returns payout ratio based upon BetType as int
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private int GetPayoutRatio(BetType type)
        {
            switch (type)
            {
                case Data.BetType.Straightup:
                    return 35;

                case Data.BetType.Split:
                    return 17;

                case Data.BetType.Basket:
                case Data.BetType.Street:
                    return 11;

                case Data.BetType.Corner:
                    return 8;
                case Data.BetType.Fivebet:
                    return 3;

                case Data.BetType.Sixline:
                case Data.BetType.Column:
                case Data.BetType.Dozen:
                    return 2;

                case Data.BetType.Odd:
                case Data.BetType.Even:
                case Data.BetType.Red:
                case Data.BetType.Black:
                case Data.BetType.Low:
                case Data.BetType.High:
                    return 1;
            }
            return 0;
        }
        /// <summary>
        /// Play winning or losing sound depending on if totalPayout is negative or positive. 
        /// </summary>
        /// <param name="totalPayout"></param>
        private void PlayWinningLosingSound(int totalPayout)
        {
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
                    player.Volume = 0.8;
                    player.Play();
                }
            }
            else
            {
                player.Open(new Uri(@"Resources\LosingSound.wav", UriKind.Relative));
                player.Volume = 0.2;
                player.Play();
            }
        }
        #endregion 
        #region
        /// <summary>
        /// Goes to next round and if power up round launches powerup method
        /// </summary>
        public void NextRound()
        {
            gameViewModel.Round++;
            if(gameViewModel.NextPowerUp == 0)
            {
                gameViewModel.BoardViewModel.ChangeBorderColorPowerUp(-1);
                gameViewModel.NextPowerUp = random.Next(3, 11);
                gameViewModel.BonusRatioMessage = "";
            }
            gameViewModel.NextPowerUp--;
            if(bonusRatio!=1)
            bonusRatio = 1;
            if (gameViewModel.NextPowerUp <= 0)
            {
                PowerUp();
            }
        }
        /// <summary>
        /// Chooses a boradpiece to power up
        /// </summary>
        private void PowerUp()
        {
                poweredUpBoardPieceId = gameViewModel.BoardViewModel.CompleteBoard[6].BoardPieceNumber;
                bonusRatio = random.Next(2, 5);
                gameViewModel.BoardViewModel.ChangeBorderColorPowerUp(poweredUpBoardPieceId);
                gameViewModel.BonusRatioMessage = $"This Round {gameViewModel.BoardViewModel.CompleteBoard[poweredUpBoardPieceId].BoardPieceLabel}" +
                    $" is worth {bonusRatio}X more if betting on {gameViewModel.BoardViewModel.CompleteBoard[poweredUpBoardPieceId].Type}";

        }
        #endregion
        #region
        /// <summary>
        /// Generates inside bets
        /// </summary>
        /// <param name="marker"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public Bet CreateBet(Marker marker, Point point)
        {
            
            List<int> numbers = new List<int>();
            int numberToFind;
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
                PayoutRatio = GetPayoutRatio(betType),
                Numbers = numbers
            };
            return bet;
        }
        /// <summary>
        /// Generates inside bets
        /// </summary>
        /// <param name="marker"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public Bet CreateBet(Marker marker, BetType betType, Point point)
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
                PayoutRatio = GetPayoutRatio(betType),
                Numbers = numbers
            };
            return bet;
        }
        #endregion
    }
}
