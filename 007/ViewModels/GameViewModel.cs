using _007.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public PlayerViewModel Player { get; set; } = new Player();
    }
}
