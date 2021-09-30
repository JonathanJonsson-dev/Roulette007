using _007.Data;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007.Models
{
    public class Bet
    {
        public BetType Type { get; set; }

        public int Value { get; set; }

        public Marker Mark { get; set; }

        public int Odds { get; set; } =  35;

        public List<int> Numbers { get; set; } = new List<int>();
        public override string ToString()
        {
            return $"Betting on: {this.Type} for {this.Value}\n \t Odds: {this.Odds}\n";
        }

    }
}
