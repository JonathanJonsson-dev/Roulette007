using _007.ViewModels;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class DisplaySetNameCommand : ICommand // gives a pop-up where the player enters their name
    {
        private readonly GameViewModel gameViewModel;
        public DisplaySetNameCommand(GameViewModel gameViewModel) // gives a pop-up where the player enters their name
        {
            this.gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ShowControl();
        }

        public void ShowControl()
        {
            SetPlayerNameView setPlayerNameView = new SetPlayerNameView(gameViewModel);
            setPlayerNameView.Show();
            setPlayerNameView.Topmost = true;
        }

    }
}
