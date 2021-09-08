using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
            for (int i = 0; i < 36; i++)
            {
                var piece = new BoardPiece();
                Board.Add(piece);
            }
        }
    }
}
