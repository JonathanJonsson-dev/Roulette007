using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _007.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        #region Properties
        //Player collection as property
        public ObservableCollection<Player> Players { get; set; } = new ObservableCollection<Player>();
        #endregion

        #region Variables
        //Player object
        private Player player = new Player();
        #endregion

        #region Contructor
        public PlayerViewModel(string name, double deposit)
        {
            FillPlayers(name, deposit);
        }

        //public PlayerViewModel( double bet)
        //{
        //    FillPlayers(bet);
        //}

        #endregion

        #region Methods
        //private void FillPlayers(double bet)
        //{
        //    player.BetAmount = bet;
        //}
        private void FillPlayers(string name, double deposit)
        {
            if (player != null)
            {
                player.NickName = name;
                player.AccountBalance = deposit;
            }

            Players.Add(player);
        }
        #endregion
    }
}
