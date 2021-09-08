using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class Player
    {
        #region Properties
        public string NickName { get; set; } // Player's nick name 
        public double AccountBalance { get; set; } //Player's deposits plus wins less losses
        //public double BetAmount { get; set; } //Amount player bets
        #endregion

        #region Constructor
        public Player()
        {

        }
        #endregion

    }
}
