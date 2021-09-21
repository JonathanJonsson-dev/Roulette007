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
     
        public WheelViewModel WheelViewModel { get; set; }

        public PlayerViewModel Player { get; set; } 
		
        public GameEngine GameEngine { get; set; } 
        
        public ICommand PickBetCommand { get; }
        public ICommand PlaceBetCommand { get; }
        public ICommand CloseBetCommand { get; }
       
		public ICommand SpinWheelCommand { get; }


        
        public GameViewModel()
        {
            BoardViewModel = new BoardViewModel(this.Player, this.GameEngine);

            WheelViewModel = new WheelViewModel();

            Player = new PlayerViewModel();

            GameEngine = new GameEngine(this);

            PickBetCommand = new PickBetCommand(this);
			
            PlaceBetCommand = new PlaceBetCommand(this);
			
            CloseBetCommand = new CloseBetCommand(this);
            
            SpinWheelCommand = new SpinWheelCommand(this.WheelViewModel);
        }



    }
}
