﻿using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {

        public Player Player { get; set; } = new Player();
    }


}
}
