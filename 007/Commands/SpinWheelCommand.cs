﻿using _007.ViewModels;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{

    class SpinWheelCommand : ICommand
    {

        private readonly WheelViewModel wheelViewModel;
        private readonly WheelView wheelView;

        public SpinWheelCommand(WheelViewModel wheelViewModel)
        {
            this.wheelViewModel = wheelViewModel;
        }

        public SpinWheelCommand(WheelView wheelView)
        {
            this.wheelView = wheelView;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            wheelViewModel.SpinWheelGetAngle(wheelView);
        }
    }
}
