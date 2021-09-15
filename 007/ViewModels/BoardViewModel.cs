using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        public ObservableCollection<BoardPiece> Board { get; set; }
        public List<BoardPiece> CompleteBoard { get; set; } = new List<BoardPiece>();
        public ObservableCollection<PlaceBet> CurrentBet { get; set; } = new ObservableCollection<PlaceBet>();
        public ObservableCollection<BoardPiece> BoardBottom { get; set; } 
        public ObservableCollection<BoardPiece> SpecialBetBoardColumnTwo { get; set; } 
        public ObservableCollection<BoardPiece> SpecialBetBoardColumnOne { get; set; } 
        
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
          
        }

        private void FillSpecialBetBoardColumnOne()
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    List<int> numbers = new List<int>();
                    for (int n = 1; n < 19; n++)
                    {
                        numbers.Add(n);
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "1 to 18",
                        BoardPieceNumber = i + 40,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        BoardPieceColor = Brushes.Transparent,
                        Type = Data.BetType.Low

                    };
                    specialBoardPiece.Height = 80;
                    CompleteBoard.Add(specialBoardPiece);
                }
                else if (i == 1)
                {
                    List<int> numbers = new List<int>();
                    for (int n = 1; n < 37; n++)
                    {
                        if (n % 2 == 0)
                        {
                            numbers.Add(n);
                        }
                        
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "Even",
                        BoardPieceNumber = i + 40,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        BoardPieceColor = Brushes.Transparent,
                        Type = Data.BetType.Even

                    };
                    specialBoardPiece.Height = 80;
                    CompleteBoard.Add(specialBoardPiece);
                }
                else if (i == 2)
                {
                    List<int> numbers = new List<int>();
                  
                    foreach (var piece in Board)
                    {
                        if(piece.BoardPieceColor == Brushes.Red)
                        {
                            numbers.Add(piece.BoardPieceNumber);
                        }
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "",
                        BoardPieceNumber = i + 40,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        Type = Data.BetType.Red,
                        BoardPieceColor = Brushes.Red

                    };
                    specialBoardPiece.Height = 80;
                    CompleteBoard.Add(specialBoardPiece);
                }
                else if (i == 3)
                {
                    List<int> numbers = new List<int>();
                    foreach (var piece in Board)
                    {
                        if (piece.BoardPieceColor == Brushes.Black)
                        {
                            numbers.Add(piece.BoardPieceNumber);
                        }
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "",
                        BoardPieceNumber = i + 40,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        Type = Data.BetType.Black,
                        BoardPieceColor = Brushes.Black

                    };
                    specialBoardPiece.Height = 80;
                    CompleteBoard.Add(specialBoardPiece);
                }
                else if (i == 4)
                {
                    List<int> numbers = new List<int>();
                    for (int n = 1; n < 37; n++)
                    {
                        if (n % 2 != 0)
                        {
                            numbers.Add(n);
                        }

                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "Odd",
                        BoardPieceNumber = i + 40,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        BoardPieceColor = Brushes.Transparent,
                        Type = Data.BetType.Odd,
                    };
                    specialBoardPiece.Height = 80;
                    CompleteBoard.Add(specialBoardPiece);
                }
                else
                {
                    List<int> numbers = new List<int>();
                    for (int n = 19; n < 37; n++)
                    {
                       
                            numbers.Add(n);
                        
                        
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "19 to 36",
                        BoardPieceNumber = i + 40,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        BoardPieceColor = Brushes.Transparent,
                        Type = Data.BetType.High

                    };
                    specialBoardPiece.Height = 80;
                    CompleteBoard.Add(specialBoardPiece);
                }
            }
        }
        private void FillSpecialBetBoardColumnTwo()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    List<int> numbers = new List<int>();
                    for (int n = 1; n < 13; n++)
                    {
                        numbers.Add(n);
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "1st 12",
                        BoardPieceNumber = i + 46,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        BoardPieceColor = Brushes.Transparent,
                        Type = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    CompleteBoard.Add(specialBoardPiece);
                }
                else if (i == 1)
                {
                    List<int> numbers = new List<int>();
                    for (int n = 13; n < 25; n++)
                    {
                        numbers.Add(n);
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "2nd 12",
                        BoardPieceNumber = i + 46,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        BoardPieceColor = Brushes.Transparent,
                        Type = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    CompleteBoard.Add(specialBoardPiece);
                }
                else
                {
                    List<int> numbers = new List<int>();
                    for(int n = 25; n< 37; n++)
                    {
                        numbers.Add(n);
                    }
                    BoardPiece specialBoardPiece = new BoardPiece
                    {
                        BoardPieceLabel = "3rd 12",
                        BoardPieceNumber = i + 46,
                        Numbers = numbers,
                        BoardPieceFontSize = 15,
                        BoardPieceColor = Brushes.Transparent,
                        Type = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    CompleteBoard.Add(specialBoardPiece);
                }
                
            }
        }

        private void FillBottomBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                List<int> numbers = new List<int>();
                if (i == 0)
                {
                    for (int n = 1; n <= 34; n += 3)
                    {

                        numbers.Add(n);
                    }
                       
                }
                else if (i == 1)
                {
                    for (int n = 2; n <= 35; n += 3)
                    {

                        numbers.Add(n);
                    }

                }
                else
                {
                    for (int n = 3; n <= 36; n += 3)
                    {

                        numbers.Add(n);
                    }

                }
                BoardPiece specialBoardPiece = new BoardPiece
                {
                    BoardPieceLabel = "2 to 1",
                    BoardPieceNumber = i + 37,
                    Numbers = numbers,
                    BoardPieceFontSize = 15,
                    BoardPieceColor = Brushes.Transparent,
                    Type = Data.BetType.Column
                    
                };
                specialBoardPiece.Width = 50;
                CompleteBoard.Add(specialBoardPiece);
            }

        }
        public void CreateBet(PlaceBet placeBet)
        {
            if (!ExistingBet(placeBet.Id) && placeBet.Amount != 0)//If theres no existing bet of the same id number
            {
                if (player.Pot >= placeBet.Amount)//Checks the player can afford the bet
                {


                    List<int> numbers = CompleteBoard[placeBet.Id].Numbers;
                    Bet bet = new Bet()
                    {
                        Numbers = numbers,
                        Id = CompleteBoard[placeBet.Id].BoardPieceNumber,
                        Amount = placeBet.Amount,
                        Type = CompleteBoard[placeBet.Id].Type
                    };
                    bets.Add(bet);
                    player.Pot -= bet.Amount;
                    CompleteBoard[placeBet.Id].BoardPieceColor = Brushes.Yellow;
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
                Input[bet.Id].Amount = 0;

            }
            CompleteBoard.Clear();
            FillBoard();
            CurrentBet.Clear();
            bets.Clear();
        }
       
        private void FillBoard()
        {
            for (int i = 0; i < 37; i++)
            {
                List<int> numbers = new List<int>();
                numbers.Add(i);
                if (i == 0)
                {
                    
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Green,
                        BoardPieceLabel = "0",
                        Numbers = numbers,
                        BoardPieceNumber = 0
                    };

                    boardPiece.Width = 150;
                    CompleteBoard.Add(boardPiece);

                }
                else if (i == 11 || i == 13 || i == 15 || i == 17 || i == 29 || i == 31 || i == 33 || i == 35)
                {
                    
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Black,
                        BoardPieceLabel = i.ToString(),
                        Numbers = numbers,
                        BoardPieceNumber = i
                    };

                    CompleteBoard.Add(boardPiece);
                }
                else if (i == 12 || i == 14 || i == 16 || i == 18 || i == 30 || i == 32 || i == 34 || i == 36)
                {
                  
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Red,
                        BoardPieceLabel = i.ToString(),
                        Numbers = numbers,
                        BoardPieceNumber = i
                    };

                    CompleteBoard.Add(boardPiece);
                }
                else if (i % 2 == 0)
                {
                    
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Black,
                        BoardPieceLabel = i.ToString(),
                        Numbers = numbers,
                        BoardPieceNumber = i
                    };

                    CompleteBoard.Add(boardPiece);
                }
                else
                {
                    
                    BoardPiece boardPiece = new BoardPiece
                    {
                        BoardPieceColor = Brushes.Red,
                        BoardPieceLabel = i.ToString(),
                        Numbers = numbers,
                        BoardPieceNumber = i
                    };
                    CompleteBoard.Add(boardPiece);
                }
            }
            Board = new ObservableCollection<BoardPiece>(CompleteBoard.Skip(0).Take(37));
            FillBottomBoard();
            FillSpecialBetBoardColumnOne();
            FillSpecialBetBoardColumnTwo();
            BoardBottom = new ObservableCollection<BoardPiece>(CompleteBoard.Skip(37).Take(3));
            SpecialBetBoardColumnOne = new ObservableCollection<BoardPiece>(CompleteBoard.Skip(40).Take(6));
            SpecialBetBoardColumnTwo = new ObservableCollection<BoardPiece>(CompleteBoard.Skip(46).Take(3));
        }

        private void FillBetInput()//Creates inputboxes for every boardpiece
        {
            for (int i = 0; i < CompleteBoard.Count; i++)
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
