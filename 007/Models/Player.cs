using _007.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class Player : PlayerViewModel
    {
        public int Pot { get; set; } = 1000;
    public class Player
    {
        public double StackAmount { get; set; } = 1000; //den fasta summa spelaren har att tillgå när spelet startar.


        public string PlayerName
        {
            get { return PlayerName; }
            set { PlayerName = value; }
        }

        public Player(string playerName, double stackAmount)
        {
            PlayerName = playerName;
            StackAmount = stackAmount;
        }

        public Player()
        {
        }
    }
}
