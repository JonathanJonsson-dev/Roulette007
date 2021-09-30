﻿using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class SetNameCommand : ICommand // sets name and shows welcome message
    {
        private PlayerViewModel playerViewModel;
        public event EventHandler CanExecuteChanged;
        

        public SetNameCommand(PlayerViewModel playerViewModel)
        {
            this.playerViewModel = playerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {



        }


       

    }
}

