using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace _007.ViewModels
{
    public class SoundSettingsViewModel : BaseViewModel
    {
        public int Volume { get; set; }

        MediaPlayer player = new MediaPlayer();

        public SoundSettingsViewModel()
        {
            //PlayBackgroundMusic(); //Kan ej spela upp bakgrundsmusiken i ViewModel då det blir någon konstig fördröjning av låten. 
        }

        private void PlayBackgroundMusic()
        {
            player.Open(new Uri(@"Resources\CasinoMusic.mp3", UriKind.Relative));
            player.Volume = 1.0;
            player.Play();
        }
    }
}
