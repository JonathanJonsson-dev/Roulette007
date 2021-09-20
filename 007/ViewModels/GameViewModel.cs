using _007.Commands;
using _007.Data;
using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public BoardViewModel BoardViewModel { get; set; }

        public WheelView WheelView { get; set; } = new WheelView();
        
       
        public PlayerViewModel PlayerViewModel { get; set; } = new PlayerViewModel();
        public Player Player { get; set; } = new Player();

        public WheelViewModel WheelViewModel { get; set; } = new WheelViewModel();
        
        public GameEngine GameEngine { get; set; } = new GameEngine();
        
        public ICommand PickBetCommand { get; }
        public ICommand PlaceBetCommand { get; }
        public ICommand CloseBetCommand { get; }
        public ICommand StartGameCommand { get; }
        public ICommand SpinWheelCommand { get; }
        
        public GameViewModel()
        {
            PickBetCommand = new PickBetCommand(this);
            PlaceBetCommand = new PlaceBetCommand(this);
            CloseBetCommand = new CloseBetCommand(this);
            StartGameCommand = new StartGameCommand(this);
            BoardViewModel = new BoardViewModel(this.Player,this.GameEngine);
            SpinWheelCommand = new SpinWheelCommand(this.WheelViewModel);
            //SpinWheelCommand = new SpinWheelCommand(this.WheelView, this.WheelViewModel);
        }



    }
}
