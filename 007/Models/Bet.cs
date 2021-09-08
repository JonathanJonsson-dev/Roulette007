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

        public int Amount { get; set; }

        public List<BoardPiece> Numbers { get; set; } = new List<BoardPiece>();
        
    }
}
