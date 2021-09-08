using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        public ObservableCollection<BoardPiece> Board { get; set; } = new ObservableCollection<BoardPiece>();

        public PlayerViewModel()
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
                    Board.Add(boardPiece);
                }
                else if (i % 2 > 0)
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
