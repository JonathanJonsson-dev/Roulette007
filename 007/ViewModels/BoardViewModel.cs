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
        public ObservableCollection<SpecialBoardPiece> BoardBottom { get; set; } = new ObservableCollection<SpecialBoardPiece>();
        public ObservableCollection<SpecialBoardPiece> LeftBoard { get; set; } = new ObservableCollection<SpecialBoardPiece>();
        public ObservableCollection<SpecialBoardPiece> Test { get; set; } = new ObservableCollection<SpecialBoardPiece>();
        public BoardViewModel()
        {
            FillBoard();
            FillBottomBoard();
            FillLeftBoard();
            FillTest();
        }

        private void FillTest()
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "1 to 18",
                        BetType = Data.BetType.OneToEighteen

                    };
                    specialBoardPiece.Height = 80;
                    Test.Add(specialBoardPiece);
                }
                else if (i == 1)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "Even",
                        BetType = Data.BetType.Even

                    };
                    specialBoardPiece.Height = 80;
                    Test.Add(specialBoardPiece);
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
                    Test.Add(specialBoardPiece);
                }
                else
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "asdasd",
                        BetType = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 80;
                    Test.Add(specialBoardPiece);
                }
            }
        }
        private void FillLeftBoard()
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
                    LeftBoard.Add(specialBoardPiece);
                }
                else if (i == 1)
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "2nd 12",
                        BetType = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    LeftBoard.Add(specialBoardPiece);
                }
                else
                {
                    SpecialBoardPiece specialBoardPiece = new SpecialBoardPiece
                    {
                        BoardPieceLabel = "3rd 12",
                        BetType = Data.BetType.Dozen

                    };
                    specialBoardPiece.Height = 160;
                    LeftBoard.Add(specialBoardPiece);
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
    }
}
