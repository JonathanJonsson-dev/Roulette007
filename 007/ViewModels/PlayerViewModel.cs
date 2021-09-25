using _007.Commands;
using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {


        public ObservableCollection<Marker> Markers { get; set; } = new ObservableCollection<Marker>();
        public string Name { get; set; } = "";
        public int Pot { get; set; } = 1000;

        public ObservableCollection<Bet> Bets { get; set; } = new ObservableCollection<Bet>();

        public RelayCommand SetNameCommand { get; }
        public ICommand ResetGameCommand { get; }
        public ShowRulesCommand ShowRulesCommand { get; }
        public ShowInstructionsCommand ShowInstructionsCommand { get; }
        public ICommand ShowSetNameUCCommand { get; }

        public PlayerViewModel()
        {
            SetNameCommand = new RelayCommand(x => IsSetButtonEnabled(), x => SetPlayerName());
            ResetGameCommand = new ResetGameCommand(this);
            ShowRulesCommand = new ShowRulesCommand(this);
            ShowInstructionsCommand = new ShowInstructionsCommand(this);
            GetStarterMarkers();
            ShowSetNameUCCommand = new ShowDisplayNameWinCommand();
        }
        
        private void GetStarterMarkers()
        {
            
            Marker marker = new Marker { 
                 
                Value = 100 };
            Markers.Add(marker);
        }

        public void SetPlayerName() 
        {
            MessageBox.Show($"Welcome {Name}! To begin playing, please place your first bet and when you're ready, spin the wheel. Good luck!");

        }

        public bool IsSetButtonEnabled()
        {

            return Name.Length > 0;

        }

        public void ResetGame()
        {
            
            Pot = 1000;
        }

        public void ShowInstructions()
        {
            MessageBox.Show($"To place a bet, drag selected marker onto the desired field. " +
                $"This can be done multiple times as long as there are money left in your pot. " +
                $"When you are happy with your bets, spin the wheel. " +
                $"If your pot runs out of money, you can always restart the game. Good luck!");
        }

        public void ShowRules()
        {
            MessageBox.Show($"Instructions here");
        }
    }
}