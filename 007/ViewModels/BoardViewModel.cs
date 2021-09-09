using _007.Models;
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
        public List<PlaceBet> Input { get; set; } = new List<PlaceBet>();
        public int LastWinningNumber { get; set; }

        public GameEngine gameEngine = new GameEngine();
        
        public Player Player { get; set; } = new Player();


        public List<Bet> bets { get; set; } = new List<Bet>();


        public BoardViewModel()
        {
            FillBoard();
            FillBetInput();
        }
        public void CreateBet(PlaceBet placeBet)
        {
            if (!ExistingBet(placeBet.Id))
            {
                List<int> numbers = CreateListOfBetNumbers(placeBet.Id);
                Bet bet = new Bet()
                {
                    Numbers = numbers,
                    Id = Board[placeBet.Id].BoardPieceNumber,
                    Amount = placeBet.Amount
                };
                bets.Add(bet);
                
                Board[placeBet.Id].BoardPieceColor = Brushes.Yellow;
            }
            else
            {
                foreach (var bet in bets)
                {
                    if(bet.Id == placeBet.Id)
                    {
                        bet.Amount = placeBet.Amount;
                    }
                }
            }
            CurrentBet.Clear();

        }
        public void ShowBet(BoardPiece piece)
        {
            CurrentBet.Clear();
            CurrentBet.Add(Input[piece.BoardPieceNumber]);
        }
        private List<int> CreateListOfBetNumbers(int id)
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
        private bool ExistingBet(int id)
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
        public void StartRound()
        {
            LastWinningNumber = gameEngine.GenerateWinningNumber();
            Payout();
        }
        public void Payout()
        {
            foreach (var bet in bets)
            {
                Player.Pot += gameEngine.GetPayout(bet);
            }
            ResetRound();
        }
        private void ResetRound()
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

        private void FillBetInput()
        {
            for (int i = 0; i < 37; i++)
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
