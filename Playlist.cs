using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    public class Playlist
    {
        public string Name { get; set; } // Playlist name
        public ObservableCollection<Song> Songs { get; set; } // Collection of songs in the playlist

        public Playlist(string name)
        {
            Name = name;
            Songs = new ObservableCollection<Song>(); // Observable collection for binding
        }
    }
}
