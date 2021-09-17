using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class PickBetCommand : ICommand
    {
        private readonly GameViewModel gameViewModel;
        public PickBetCommand(GameViewModel gameViewModel)
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

            gameViewModel.BoardViewModel.ShowBet(gameViewModel.BoardViewModel.CompleteBoard[(int)parameter]);

        }
    }
}
