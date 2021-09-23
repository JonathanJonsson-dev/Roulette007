using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _007.Models
{
    public class SongCollection
    {
        public List<Uri> songs = new List<Uri>
            {   new Uri(@"Resources\CasinoMusic.mp3", UriKind.Relative),
                new Uri(@"Resources\WinningSound2.mp3", UriKind.Relative)
            };

        public SongCollection()
        {
            //SongList = new ObservableCollection<Song>();
            //LoadSongs();
        }

        public void LoadSongs()
        {
            List<Uri> songs = new List<Uri> 
            {   new Uri(@"Resources\CasinoMusic.mp3", UriKind.Relative),
                new Uri(@"Resources\WinningSound2.mp3", UriKind.Relative)
            };

            //foreach (Uri song in songs)
            //{
            //    Song song = new Song();
            //    SongList.Add(song);
            //}
        }
    }
}
