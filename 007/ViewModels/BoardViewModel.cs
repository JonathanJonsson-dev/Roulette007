﻿using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        public ObservableCollection<BoardPiece> Board { get; set; } = new ObservableCollection<BoardPiece>();
        public ObservableCollection<PlaceBet> CurrentBet { get; set; } = new ObservableCollection<PlaceBet>();
        public ObservableCollection<SpecialBoardPiece> BoardBottom { get; set; } = new ObservableCollection<SpecialBoardPiece>();
        public ObservableCollection<SpecialBoardPiece> SpecialBetBoardColumnTwo { get; set; } = new ObservableCollection<SpecialBoardPiece>();
        public ObservableCollection<SpecialBoardPiece> SpecialBetBoardColumnOne { get; set; } = new ObservableCollection<SpecialBoardPiece>();
        
        public List<PlaceBet> Input { get; set; } = new List<PlaceBet>();
        public int LastWinningNumber { get; set; }

        private GameEngine gameEngine;

        private PlayerViewModel player;

        public List<Bet> bets { get; set; } = new List<Bet>();

        public BoardViewModel(PlayerViewModel player, GameEngine gameEngine)
        {
            this.player = player;
            this.gameEngine = gameEngine;
            FillBoard();
            FillBetInput();
            FillBottomBoard();
            FillSpecialBetBoardColumnTwo();
            FillSpecialBetBoardColumnOne();
        }

        private void FillSpecialBetBoardColumnOne()
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "1 to 18",
                        BetType = Data.BetType.Low

                    };
                    specialBoardPiece.Height = 80;
                    SpecialBetBoardColumnOne.Add(specialBoardPiece);
                }
                else if (i == 1)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "Even",
                        BetType = Data.BetType.Even

                    };
                    specialBoardPiece.Height = 80;
                    SpecialBetBoardColumnOne.Add(specialBoardPiece);
                }
                else if (i == 2)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "",
                        BetType = Data.BetType.Red,
                        BoardPieceColor = Brushes.Red

                    };
                    specialBoardPiece.Height = 80;
                    SpecialBetBoardColumnOne.Add(specialBoardPiece);
                }
                else if (i == 3)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "",
                        BetType = Data.BetType.Black,
                        BoardPieceColor = Brushes.Black

                    };
                    specialBoardPiece.Height = 80;
                    SpecialBetBoardColumnOne.Add(specialBoardPiece);
                }
                else if (i == 4)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "Odd",
                        BetType = Data.BetType.Odd,
                    };
                    specialBoardPiece.Height = 80;
                    SpecialBetBoardColumnOne.Add(specialBoardPiece);
                }
                else
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "19 to 36",
                        BetType = Data.BetType.High

                    };
                    specialBoardPiece.Height = 80;
                    SpecialBetBoardColumnOne.Add(specialBoardPiece);
                }
            }
        }
        private void FillSpecialBetBoardColumnTwo()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "1st 12",
                        BetType = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    SpecialBetBoardColumnTwo.Add(specialBoardPiece);
                }
                else if (i == 1)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "2nd 12",
                        BetType = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    SpecialBetBoardColumnTwo.Add(specialBoardPiece);
                }
                else
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "3rd 12",
                        BetType = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    SpecialBetBoardColumnTwo.Add(specialBoardPiece);
                }
                
            }
        }

        private void FillBottomBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece 
                {   
                    BoardPieceLabel = "2 to 1",
                    BetType = Data.BetType.Column
                    
                };
                specialBoardPiece.Width = 50;
                BoardBottom.Add(specialBoardPiece);
            }

        }
        public void CreateBet(PlaceBet placeBet)
        {
            if (!ExistingBet(placeBet.Id) && placeBet.Amount != 0)//If theres no existing bet of the same id number
            {
                if (player.Pot >= placeBet.Amount)//Checks the player can afford the bet
                {


                    List<int> numbers = CreateListOfBetNumbers(placeBet.Id);
                    Bet bet = new Bet()
                    {
                        Numbers = numbers,
                        Id = Board[placeBet.Id].BoardPieceNumber,
                        Amount = placeBet.Amount
                    };
                    bets.Add(bet);
                    player.Pot -= bet.Amount;
                    Board[placeBet.Id].BoardPieceColor = Brushes.Yellow;
                }
                else
                {
                    placeBet.Amount = 0;//Returns inputbox to 0
                }
            }
            else//Updates existing bet
            {
                foreach (var bet in bets)
                {
                    if(bet.Id == placeBet.Id)
                    {
                        player.Pot += bet.Amount;
                        bet.Amount = placeBet.Amount;
                        player.Pot -= bet.Amount;
                    }
                }
            }
            CurrentBet.Clear();

        }
        public void ShowBet(BoardPiece piece)//Shows inputbox for current boardpiece
        {
            CurrentBet.Clear();
            CurrentBet.Add(Input[piece.BoardPieceNumber]);
        }
        private List<int> CreateListOfBetNumbers(int id) //Adds all the numbers that the bet contains to a list 
        {
            BoardPiece piece = Board[id];
            List<int> numbers = new List<int>();
            switch (piece.Type)
            {
                case Data.BetType.Straightup:
                    numbers.Add(piece.BoardPieceNumber);
                    break;
                case Data.BetType.Split:
                    break;
                case Data.BetType.Basket:
                    break;
                case Data.BetType.Street:
                    break;
                case Data.BetType.Corner:
                    break;
                case Data.BetType.Sixline:
                    break;
                case Data.BetType.Column:
                    break;
                case Data.BetType.Dozen:
                    break;
                case Data.BetType.Odd:
                    break;
                case Data.BetType.Even:
                    break;
                case Data.BetType.Red:
                    break;
                case Data.BetType.Black:
                    break;
                case Data.BetType.Low:
                    break;
                case Data.BetType.High:
                    break;
                default:
                    break;
            }
            return numbers;
        }
        private bool ExistingBet(int id)//Checks if the bet exist
        {
            bool itExist = false;
            foreach (var bet in bets)
            {
                if (bet.Id == id)
                {
                    itExist = true;
                }
               
            }
            return itExist;
        }
        public void StartRound()//Starts the game temporary placement
        {
            LastWinningNumber = gameEngine.GenerateWinningNumber();
            Payout();
        }
        public void Payout()//Sends all bets made to gameEnigne for payout
        {
            foreach (var bet in bets)
            {
                player.Pot += gameEngine.GetPayout(bet);
            }
            ResetRound();
        }
        private void ResetRound()//Resets for new round
        {
            bets.Clear();
            Board.Clear();
            FillBoard();
            Input.Clear();
            FillBetInput();
        }
        private void FillBoard()
        {
            for (int i = 0; i < 37; i++)
            {
                if (i == 0)
                {
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Green,
                        BoardPieceNumber = 0
                    };

                    boardPiece.Width = 150;
                    Board.Add(boardPiece);

                }
                else if (i == 11 || i == 13 || i == 15 || i == 17 || i == 29 || i == 31 || i == 33 || i == 35)
                {
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Black,
                        BoardPieceNumber = i
                    };

                    Board.Add(boardPiece);
                }
                else if (i == 12 || i == 14 || i == 16 || i == 18 || i == 30 || i == 32 || i == 34 || i == 36)
                {
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Red,
                        BoardPieceNumber = i
                    };

                    Board.Add(boardPiece);
                }
                else if (i % 2 == 0)
                {
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Black,
                        BoardPieceNumber = i
                    };

                    Board.Add(boardPiece);
                }
                else
                {
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Red,
                        BoardPieceNumber = i
                    };

                    Board.Add(boardPiece);
                }
            }
        }

        private void FillBetInput()//Creates inputboxes for every boardpiece
        {
            for (int i = 0; i < Board.Count; i++)
            {
                PlaceBet placeBet = new PlaceBet
                {
                    Id = i
                };
                Input.Add(placeBet);
            }
        }

    }
}
