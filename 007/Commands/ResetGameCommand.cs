using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class ResetGameCommand : ICommand // resets game - resets pot and markers. Name stays
    {
        private PlayerViewModel playerViewModel;
        public event EventHandler CanExecuteChanged;


        public ResetGameCommand(PlayerViewModel playerViewModel)
        {
            this.playerViewModel = playerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            playerViewModel.ResetGame();

        }




    }
}
