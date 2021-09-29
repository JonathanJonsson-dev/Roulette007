﻿using _007.ViewModels;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class DisplaySetNameCommand : ICommand
    {
        private readonly PlayerViewModel playerViewModel;
        public DisplaySetNameCommand(PlayerViewModel playerViewModel) // gives a pop-up where the player enters their name
        {
            this.playerViewModel = playerViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ShowControl();
        }

        public void ShowControl()
        {
            SetPlayerNameView setPlayerNameView = new SetPlayerNameView(playerViewModel);
            setPlayerNameView.Show();
            setPlayerNameView.Focus();
        }

    }
}