using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class ResetGameCommand : ICommand
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
            //smart kod här som plockar in metoden för att starta om spelet.

        }




    }
}
