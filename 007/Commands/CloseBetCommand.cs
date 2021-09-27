using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    class CloseBetCommand : ICommand
    {
        private readonly GameViewModel gameViewModel;
        public CloseBetCommand(GameViewModel gameViewModel)
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

            

        }
    }
}
