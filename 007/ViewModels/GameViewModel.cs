using _007.Commands;
using _007.Data;
using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;



namespace _007.ViewModels
{

    public class GameViewModel : BaseViewModel
    {
        public SoundSettingsViewModel SoundSettingsView { get; set; } = new SoundSettingsViewModel();
        public ObservableCollection<HighscorePiece> Highscores { get; set; } = new ObservableCollection<HighscorePiece>();

        public GameView gameView;
        
        public BoardViewModel BoardViewModel { get; set; }
        public WheelViewModel WheelViewModel { get; set; }
        public PlayerViewModel Player { get; set; } 
		public GameEngine GameEngine { get; set; }
        public int Round { get; set; } = 1;
        public int NextPowerUp { get; set; } = 1;
        public ICommand PickBetCommand { get; }
        public ICommand PlaceBetCommand { get; }
        public ICommand CloseBetCommand { get; }
		public ICommand SpinWheelCommand { get; }
        
        public GameViewModel(GameView gameView)
        {
            this.gameView = gameView;
            BoardViewModel = new BoardViewModel(this.Player, this.GameEngine);

            WheelViewModel = new WheelViewModel(this);

            Player = new PlayerViewModel(this);

            GameEngine = new GameEngine(this);

            SpinWheelCommand = new SpinWheelCommand(this.WheelViewModel);
        }
    }
}
