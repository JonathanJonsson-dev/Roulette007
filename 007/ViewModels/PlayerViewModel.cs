using _007.Commands;
using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {

     
        public string Name { get; set; } = "Player";
        public int Pot { get; set; } = 1000;
        

        
        public ICommand SetNameCommand { get; }

        public PlayerViewModel()
        {
            SetNameCommand = new SetNameCommand(this);
        }
       

        //public string PlayerName
        //{
        //    get { return PlayerName; }
        //    set { PlayerName = value; }
        //}

    }
}