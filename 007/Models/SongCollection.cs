﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Resources;

namespace _007.Models
{
    public class SongCollection
    {
        
        public List<Song> songs = new List<Song>
            {   new Song(){ Filepath = new Uri(@"Resources\MemoirOfSummer.mp3", UriKind.Relative)},
                new Song(){ Filepath = new Uri(@"Resources\Songs\GlideWithMe.mp3", UriKind.Relative)},
                new Song(){ Filepath = new Uri(@"Resources\Songs\PathwayToHaven.mp3", UriKind.Relative)}
            };

        public SongCollection()
        {
        }
    }
}
