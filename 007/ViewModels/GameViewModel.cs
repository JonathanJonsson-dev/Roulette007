using _007.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public BoardViewModel BoardViewModel { get; set; } = new BoardViewModel();
        
        public PlayerViewModel PlayerViewModel { get; set; } = new PlayerViewModel();

        public WheelViewModel Wheel { get; set; } = new WheelViewModel();
        
    }
}
