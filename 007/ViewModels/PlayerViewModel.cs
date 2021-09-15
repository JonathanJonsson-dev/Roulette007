using _007.Commands;
using _007.Models;
using _007.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class PlayerViewModel : GameViewModel
    {
       

        //public class Player(string name, int pot)
        //{
        //    Name = name;
        //    Pot = pot;
        //}
       
        public string Name 
        { 
            get { return Name; } 
            set { Name = value; } 
        }
        public int Pot { get; set; } = 1000;



        public ICommand SetNameCommand { get; }
        public ICommand ResetGameCommand { get; }

        public PlayerViewModel()
        {
            SetNameCommand = new SetNameCommand(this);
            SetNameCommand = new ResetGameCommand(this);
        }



        public void SetPlayerName() 
        {

            // smart kod som visar spelaren och döljer textboxen samt set-knappen när man klickar på set-knappen
            

            MessageBox.Show($"Welcome {Name}! To begin playing, please place your first bet and when you're ready, spin the wheel. Good luck!");


        }

        public void EnableSetButton()
        {

            // kod som enablar set-knappen om namnet i textboxen är en character eller längre.
            //disablar om man raderar det man skrivit så boxen är tom igen

            //{
            //    if (Name.Length > 0)
            //    {
            //        btnSet.IsEnabled = true;
            //    }

            //    else
            //    {
            //        btnSet.IsEnabled = false;
            //    }

        }

        public void ResetGame()
        {
            //kod som enablar set button och sätter pot till 100 igen
            Pot = 1000;
        }


    }
}