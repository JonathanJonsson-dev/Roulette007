﻿using _007.Commands;
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

        public BoardViewModel BoardViewModel { get; set; }
        
        public PlayerViewModel Player { get; set; } = new PlayerViewModel();
       
        public WheelViewModel Wheel { get; set; }
        
        public GameEngine GameEngine { get; set; } = new GameEngine();
        
        public ICommand PickBetCommand { get; }
        public ICommand PlaceBetCommand { get; }
        public ICommand CloseBetCommand { get; }
        public ICommand StartGameCommand { get; }
        
        public GameViewModel()
        {
            PickBetCommand = new PickBetCommand(this);
            PlaceBetCommand = new PlaceBetCommand(this);
            CloseBetCommand = new CloseBetCommand(this);
            StartGameCommand = new StartGameCommand(Wheel,this);
            BoardViewModel = new BoardViewModel(this.Player,this.GameEngine);
            Wheel = new WheelViewModel(this);

        }

        

    }
}
