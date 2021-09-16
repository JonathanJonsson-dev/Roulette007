using _007.Commands;
using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {



        public string Name { get; set; } = "";
        public int Pot { get; set; } = 1000;



        public RelayCommand SetNameCommand { get; }
        public ICommand ResetGameCommand { get; }

        public PlayerViewModel()
        {
            SetNameCommand = new RelayCommand(x => IsSetButtonEnabled(), x => SetPlayerName());
            ResetGameCommand = new ResetGameCommand(this);
        }



        public void SetPlayerName() 
        {


            MessageBox.Show($"Welcome {Name}! To begin playing, please place your first bet and when you're ready, spin the wheel. Good luck!");


        }

        public bool IsSetButtonEnabled()
        {

            return Name.Length > 0;

        }

        public void ResetGame()
        {
            
            Pot = 1000;
        }


    }
}