using _007.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        //private PlayerViewModel player = new Player();
        public PlayerViewModel PlayerVM { get; set; }

        public GameViewModel()
        {
            //PlayerVM = new PlayerViewModel();
        }
    }
}
