using _007.Commands;
using _007.Models;
using _007.Views;
using Microsoft.VisualBasic;
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

        public string Name { get; set; }

        public int Pot { get; set; }

        private readonly GameViewModel gameViewModel;
       
        public ICommand ResetGameCommand { get; }
        public ICommand ShowRulesCommand { get; }
        public ICommand DisplaySetNameCommand { get; }
        
        public ShowInstructionsCommand ShowInstructionsCommand { get; }
        
        

        public PlayerViewModel(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
            ResetGameCommand = new ResetGameCommand(this);
            ShowInstructionsCommand = new ShowInstructionsCommand(this);
            ShowRulesCommand = new ShowRulesCommand(this);
            DisplaySetNameCommand = new DisplaySetNameCommand(gameViewModel);
            
        }

        public void ResetGame() // method resetting pot to 1000 and markers back to starting point
        {
            
            gameViewModel.Name = "";
            gameViewModel.Pot = 10000;
            foreach (var bet in gameViewModel.Bets)
                
            {
                gameViewModel.gameView.board.Children.Remove(bet.Mark);
            }
            gameViewModel.Bets.Clear();
            
            gameViewModel.WheelViewModel = new WheelViewModel(gameViewModel);
            gameViewModel.Round = 1;
            gameViewModel.NextPowerUp = 5;
        }

        public void ShowInstructions() // method displaying a message box with basic instructions on how to play the game.
        {
            string title = "Instructions";
            string message = "To place a bet, drag selected marker onto the desired field. " +
                $"This can be done multiple times as long as there is money left in your pot. " +
                $"\n\n When you are happy with your bets, spin the wheel. " +
                $"If your pot runs out of money, you can always restart the game. \n \n \t Good luck!";

            UserMessenger messenger = new UserMessenger(message, title);
            messenger.Show();
        }

        public void ShowRules() // method displaying a message box with basic rules and odds of each bet.
        {
            string title = "Rules";
            string message = "A European, or single-zero, roulette wheel has 37 numbers in total, 0-36. For each spin of the wheel, the following bets can be placed: " +
                "\n \n ¤  ’Straight up’   35:1" +
                "\n      -  betting on one number (including 0). " +
                "\n ¤  ’Split’   17:1" +
                "\n      -  betting on two numbers." +
                "\n ¤  ‘Basket’   11:1" +
                "\n      -  betting on 0,1,2 or 0,2,3. " +
                "\n ¤  ‘Street’   11:1" +
                "\n      -  betting on three numbers horizontal. " +
                "\n ¤  ‘Corner’   8:1" +
                "\n      -  betting on four adjoining numbers in a block." +
                "\n ¤  ‘Six Line’   5:1" +
                "\n      -  betting on 6 adjoining numbers from two streets." +
                "\n ¤  ‘Column’   2:1" +
                "\n      -  betting on first, second or third column." +
                "\n ¤  ‘Dozen’   2:1" +
                "\n      -  betting on first, second or third dozen" +
                "\n ¤  Color   1:1" +
                "\n      -  betting on red or black." +
                "\n ¤  Even or odd   1:1" +
                "\n      -  betting on even or odd number. " +
                "\n ¤  High or low    1:1" +
                "\n      -  betting on 1 through 18 or 19 through 36." +
                "\n \n \t Good luck!";

            UserMessenger messenger = new UserMessenger(message, title);
            messenger.Show();
        }
    }
}