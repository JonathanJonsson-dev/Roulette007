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
        public int Pot { get; set; } = 10000;

        public ObservableCollection<Bet> Bets { get; set; } = new ObservableCollection<Bet>();

        private GameViewModel gameViewModel;
        public RelayCommand SetNameCommand { get; }
        public ICommand ResetGameCommand { get; }
        public ShowRulesCommand ShowRulesCommand { get; }
        public ShowInstructionsCommand ShowInstructionsCommand { get; }

        public PlayerViewModel(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
            SetNameCommand = new RelayCommand(x => IsSetButtonEnabled(), x => SetPlayerName());
            ResetGameCommand = new ResetGameCommand(this);
            ShowRulesCommand = new ShowRulesCommand(this);
            ShowInstructionsCommand = new ShowInstructionsCommand(this);
            GetStarterMarkers();
        }

        private void GetStarterMarkers()
        {

            Marker marker = new Marker
            {
                Value = 100
            };
            Markers.Add(marker);
        }

        public void SetPlayerName() 
        {
            MessageBox.Show($"Welcome {Name}! To begin playing, please place your first bet and when you're ready, spin the wheel. \n \nGood luck!");

        }

        public bool IsSetButtonEnabled() // method checking if a name has been entered
        {

            return Name.Length > 0;

        }

        public void ResetGame() // method resetting pot to 1000 and markers back to starting point
        {
            
            Pot = 1000;
            foreach (var bet in Bets)
            {
                gameViewModel.gameView.board.Children.Remove(bet.Mark);
            }
            Bets.Clear();
        }

        public void ShowInstructions() // method displaying a message box with basic instructions on how to play the game.
        {
            string title = "Instructions";
            string message = "To place a bet, drag selected marker onto the desired field. " +
                $"This can be done multiple times as long as there are money left in your pot. " +
                $"When you are happy with your bets, spin the wheel. " +
                $"If your pot runs out of money, you can always restart the game. \n \nGood luck!";
            
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowRules() // method displaying a message box with basic rules and odds of each bet.
        {
            string title = "Rules";
            string message = "A European, or single-zero, roulette wheel has 37 numbers in total, 0-36. For each spin of the wheel, the following bets can be placed: " +
                "\n \n ¤  ’Straight up’ betting on one number (including 0) pays 35 to 1. " +
                "\n ¤  ’Split’ betting on two numbers pays 17 to 1. " +
                "\n ¤  ‘Basket’ betting on 0,1,2 or 0,2,3 pays 11 to 1. " +
                "\n ¤  ‘Street’ betting on three numbers horizontal pays 11 to 1. " +
                "\n ¤  ‘Corner’ betting on four adjoining numbers in a block pays 8 to 1." +
                "\n ¤  ‘Six Line’ betting on 6 numbers from two adjoining streets pays 5 to 1." +
                "\n ¤  ‘1st Column’ betting on first column pays 2 to 1. " +
                "\n ¤  ‘2nd Column’ betting on second column pays 2 to 1. " +
                "\n ¤  ‘3rd Column’ betting on third column pays 2 to 1. " +
                "\n ¤  ‘1st Dozen’ betting on numbers 1 through 12 pays 2 to 1." +
                "\n ¤  ‘2nd Dozen’ betting on numbers 13 through 24 pays 2 to 1." +
                "\n ¤  ‘3rd Dozen’ betting on numbers 25 through 26 pays 2 to 1." +
                "\n ¤  Color betting (red or black) pays 1 to 1. " +
                "\n ¤  Even or odd betting pays 1 to 1. " +
                "\n ¤  High or low bets (1 through 18 or 19 through 36) pay 1 to 1.";

           MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        

    }
}