using System;
using System.Collections.Generic;
using System.Text;

namespace _007.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; set; } = new GameViewModel(null);        

    }
}
