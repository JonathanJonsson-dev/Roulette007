using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class ShowRulesCommand : ICommand // shows messagebox with rules when player presses rules button
    {
        private PlayerViewModel playerViewModel;
        public event EventHandler CanExecuteChanged;


        public ShowRulesCommand(PlayerViewModel playerViewModel)
        {
            this.playerViewModel = playerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            playerViewModel.ShowRules();

        }


    }
}
