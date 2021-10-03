using _007.Commands;
using _007.Data;
using _007.Models;
using _007.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
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
        public int NextPowerUp { get; set; } = 3;
        public string BonusRatioMessage { get; set; } = "";
        //public string Name { get; set; } = "";
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; Player.Name = value; }
        }
        private int pot;

        public int Pot
        {
            get { return pot; }
            set { pot = value; Player.Pot = value; }
        }

        //public int Pot { get; set; } = 10000;

        public ObservableCollection<Bet> Bets { get; set; } = new ObservableCollection<Bet>();
        public ICommand SpinWheelCommand { get; }

        public RelayCommand SetNameCommand { get; }
        public GameViewModel(GameView gameView)
        {
            this.gameView = gameView;
            BoardViewModel = new BoardViewModel();

            WheelViewModel = new WheelViewModel(this);

            Player = new PlayerViewModel(this);

            GameEngine = new GameEngine(this);
            SetNameCommand = new RelayCommand(x => IsSetButtonEnabled(), x => SetPlayerName());


            SpinWheelCommand = new SpinWheelCommand(this.WheelViewModel);
            Name = "";
            Pot = 10000;
            LoadHighscore();
        }

        private void LoadHighscore()
        {

            var jsonString = System.IO.File.ReadAllText(@"C:\Users\jonss\source\repos\007\007\bin\Debug\netcoreapp3.1\highscores.json");
            var result = JsonConvert.DeserializeObject<List<Highscore>>(jsonString);

            foreach (var item in result)
            {
                HighscorePiece highscorePiece = new HighscorePiece { PlayerName = item.PlayerName, Score = item.Score };
                Highscores.Add(highscorePiece);
            }
        }

        public void SetPlayerName()
        {
            string message = "To begin playing, please place your first bet and when you're ready, spin the wheel. \n \n \t Good luck!";
            string title = $"Welcome {Name}!";

            UserMessenger messenger = new UserMessenger(message, title);
            messenger.Show();
        }

        public bool IsSetButtonEnabled() // method checking if a name has been entered
        {

            return Name.Length > 0;

        }
    }
}
