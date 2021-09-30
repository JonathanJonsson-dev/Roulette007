using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class ShowInstructionsCommand : ICommand
    {
        private PlayerViewModel playerViewModel;
        public event EventHandler CanExecuteChanged;


        public ShowInstructionsCommand(PlayerViewModel playerViewModel) // shows messagebox with instructions when player presses instructions button
        {
            this.playerViewModel = playerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            playerViewModel.ShowInstructions();

        }

    }
}
