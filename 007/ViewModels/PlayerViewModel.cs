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
    public class PlayerViewModel : BaseViewModel
    {


        public ObservableCollection<Marker> Markers { get; set; } = new ObservableCollection<Marker>();
        public string Name { get; set; } = "";
        public int Pot { get; set; } = 1000;

        public ObservableCollection<Bet> Bets { get; set; } = new ObservableCollection<Bet>();

        public RelayCommand SetNameCommand { get; }
        public ICommand ResetGameCommand { get; }

        public PlayerViewModel()
        {
            SetNameCommand = new RelayCommand(x => IsSetButtonEnabled(), x => SetPlayerName());
            ResetGameCommand = new ResetGameCommand(this);
            GetStarterMarkers();
        }
        
        private void GetStarterMarkers()
        {
            
            Marker marker = new Marker { 
                 
                Value = 100 };
            Markers.Add(marker);
        }

        public void SetPlayerName() 
        {
            MessageBox.Show($"Welcome {Name}! To begin playing, please place your first bet and when you're ready, spin the wheel. Good luck!");

        }

        public bool IsSetButtonEnabled()
        {

            return Name.Length > 0;

        }

        public void ResetGame()
        {
            
            Pot = 1000;
        }


    }
}