using _007.ViewModels;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _007.Commands
{
    public class DisplaySetNameCommand : ICommand
    {

        private SetPlayerNameView setPlayerNameView;
        private PlayerView playerView;
        public event EventHandler CanExecuteChanged;


        public DisplaySetNameCommand(SetPlayerNameView setPlayerNameView)
        {
            this.setPlayerNameView = setPlayerNameView;
        }

        public DisplaySetNameCommand(PlayerView playerView)
        {
            this.playerView = playerView;
        }


        //public DisplaySetNameCommand() // gives a pop-up where the player enters their name
        //{

        //}

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
            SetPlayerNameView setPlayerNameView = new SetPlayerNameView();
            setPlayerNameView.Show();
            setPlayerNameView.Topmost = true;
        }

    }
}
