using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _007.ViewModels
{
    public class BoardViewModel
    {
        #region Variables
        private Board board;
        #endregion
        #region properties
        public ObservableCollection<BoardPiece> RouletteBoard { get; set; }

        
        #endregion

        public BoardViewModel()
        {
            RouletteBoard = new ObservableCollection<BoardPiece>();
            board = new Board();
            FillBoard();
        }

        private void FillBoard()
        {

            var piece = new BoardPiece();

            foreach (int i in board.boardNumbers)
            {
                if(i % 2 == 1) //checks if odd number
                {
                    piece.Number = i;
                    piece.IsRedNumber = true;
                }
                else
                {
                    piece.Number = i;
                }

                RouletteBoard.Add(piece);
            }
        }

    }
}
