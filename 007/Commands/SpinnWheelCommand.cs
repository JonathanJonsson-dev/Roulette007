using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    
    class SpinnWheelCommand : ICommand
    {
        private readonly SpinningWheelViewModel spinningWheelViewModel;
        private WheelViewModel wheelViewModel;

        public SpinnWheelCommand(SpinningWheelViewModel spinnWheelViewModel)
        {
            this.spinningWheelViewModel = spinnWheelViewModel;
        }

        public SpinnWheelCommand(WheelViewModel wheelViewModel)
        {
            this.wheelViewModel = wheelViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            spinningWheelViewModel.SpinnWheel();
        }
    }
}
