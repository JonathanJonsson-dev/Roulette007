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

        public BoardViewModel()
        {
            FillBoard();
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
