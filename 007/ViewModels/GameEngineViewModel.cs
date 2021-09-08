using System;
using System.Collections.Generic;
using System.Text;
using _007.Models;

namespace _007.ViewModels
{
    public class GameEngineViewModel
    {
        private readonly GameEngine gameEngine;

        public int WinningNumber { get; set; } = -1;

        public GameEngineViewModel()
        {
            gameEngine = new GameEngine();

            WinningNumber = gameEngine.GetRandomNumber();
        }
    }
}
