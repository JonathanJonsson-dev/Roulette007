using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class ShowRulesCommand : ICommand
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
