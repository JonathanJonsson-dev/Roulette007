using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using _007.Views;

namespace _007.Commands
{
    class ShowDisplayNameWinCommand : ICommand
    {
        //private readonly PlayerViewModel playerViewModel;
        //private readonly int amount;
        public ShowDisplayNameWinCommand()
        {
            //playerViewModel = _playerViewModel;
            //amount = _amount;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //playerViewModel.MakeDeposit(amount);
            ShowControl();

        }

        /// <summary>
        /// Shows the display name window
        /// </summary>
        /// <returns></returns>
        public void ShowControl()
        {
            //return (UserControl)XamlReader.Load(new FileStream(@"../../../Views/PlayerName.xaml", FileMode.Open));
            DisplayName displayName = new DisplayName();
            displayName.Show();
        }
    }
}
