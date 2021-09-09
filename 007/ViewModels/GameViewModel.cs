using _007.Commands;
using _007.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public BoardViewModel BoardViewModel { get; set; } = new BoardViewModel();
       
        public ICommand PickBetCommand { get; }
        public ICommand PlaceBetCommand { get; }
        public ICommand StartGameCommand { get; }
        public GameViewModel()
        {
            PickBetCommand = new PickBetCommand(this);
            PlaceBetCommand = new PlaceBetCommand(this);
            StartGameCommand = new StartGameCommand(this);
        }

    }
}
