using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        public ObservableCollection<BoardPiece> Board { get; set; }
        public List<BoardPiece> CompleteBoard { get; set; } = new List<BoardPiece>();
        
        public ObservableCollection<BoardPiece> BoardBottom { get; set; } 
        public ObservableCollection<BoardPiece> SpecialBetBoardColumnTwo { get; set; } 
        public ObservableCollection<BoardPiece> SpecialBetBoardColumnOne { get; set; } 
        
      
        public int LastWinningNumber { get; set; }

        private GameEngine gameEngine;

        private PlayerViewModel player;
        
        public List<Bet> bets { get; set; } = new List<Bet>();

        public BoardViewModel(PlayerViewModel player, GameEngine gameEngine)
        {
            this.player = player;
            this.gameEngine = gameEngine;
            FillBoard();
        }

        private void FillSpecialBetBoardColumnOne()
        {
            for (int i = 0; i < 6; i++)
            {
                List<int> numbers = new List<int>();
                string label = "";
                SolidColorBrush color = Brushes.Transparent;
                //Generete bettingnumbers that is stored in each boardpiece
                if (i == 0)
                {
                    
                    for (int n = 1; n < 19; n++)
                    {
                        numbers.Add(n);
                    }
                    label = "1 to 18";
                   
                }
                else if (i == 1)
                {
                    
                    for (int n = 1; n < 37; n++)
                    {
                        if (n % 2 == 0)
                        {
                            numbers.Add(n);
                        }
                        
                        
                    }
                    label = "Even";

                }
                else if (i == 2)
                {
                   
                  
                    foreach (var piece in Board)
                    {
                        if(piece.BoardPieceColor == Brushes.Red)
                        {
                            numbers.Add(piece.BoardPieceNumber);
                        }
                    }
                    color = Brushes.Red;
                    
                }
                else if (i == 3)
                {
                    
                    foreach (var piece in Board)
                    {
                        if (piece.BoardPieceColor == Brushes.Black)
                        {
                            numbers.Add(piece.BoardPieceNumber);
                        }
                    }
                    color = Brushes.Black;
                }
                else if (i == 4)
                {
                   
                    for (int n = 1; n < 37; n++)
                    {
                        if (n % 2 != 0)
                        {
                            numbers.Add(n);
                        }

                    }
                    label = "Odd";
                  
                }
                else
                {
                    
                    for (int n = 19; n < 37; n++)
                    {
                       
                            numbers.Add(n);
                        
                        
                    }
                    label = "19 to 36";
                   
                }
                BoardPiece specialBoardPiece = new BoardPiece
                {
                    BoardPieceLabel = label,
                    BoardPieceNumber = i + 40,
                    Numbers = numbers,
                    BoardPieceFontSize = 15,
                    BoardPieceColor = color,
                    Type = Data.BetType.Low

                };
                specialBoardPiece.Height = 100;
                specialBoardPiece.Width = 75;
                CompleteBoard.Add(specialBoardPiece);
            }
        }
        private void FillSpecialBetBoardColumnTwo()
        {
            for (int i = 0; i < 3; i++)
            {
                List<int> numbers = new List<int>();
                string label = "";
                SolidColorBrush color = Brushes.Transparent;
                //Generete bettingnumbers that is stored in each boardpiece
                if (i == 0)
                {
                   
                    for (int n = 1; n < 13; n++)
                    {
                        numbers.Add(n);
                    }
                    label = "1st 12";
                }
                else if (i == 1)
                {
                    
                    for (int n = 13; n < 25; n++)
                    {
                        numbers.Add(n);
                    }
                    label = "2nd 12";
                }
                else
                {
                    
                    for(int n = 25; n< 37; n++)
                    {
                        numbers.Add(n);
                    }
                    label = "3rd 12";
                }
                BoardPiece specialBoardPiece = new BoardPiece
                {
                    BoardPieceLabel = label,
                    BoardPieceNumber = i + 46,
                    Numbers = numbers,
                    BoardPieceFontSize = 15,
                    BoardPieceColor = color,
                    Type = Data.BetType.Dozen

                };
                specialBoardPiece.Height = 200;
                specialBoardPiece.Width = 60;
                CompleteBoard.Add(specialBoardPiece);

            }
        }

        private void FillBottomBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                List<int> numbers = new List<int>();
                //Generete bettingnumbers that is stored in each boardpiece
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
        public void CreateBet()
        {
            

        }
        
   
        public void StartRound(int winnningNumber)//Starts the game temporary placement
        {
            
            Payout();
        }
        public void Payout()//Sends all bets made to gameEnigne for payout
        {

            int totalPayout = 0;            
            PlaySound(totalPayout);

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

       

        private void PlaySound(int totalPayout)
        {
            if (totalPayout > 0)
            {
                SoundPlayer sound = new SoundPlayer(Properties.Resources.WinningSound1);
                sound.Play();
            }
            else
            {
                SoundPlayer sound = new SoundPlayer(Properties.Resources.LosingSound);
                sound.Play();
            }
            
        }

    }
}
