using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Music_Player
{
    public class Song
    {
        public string Title { get; set; }
        public string FullPath { get; set; }

        public BitmapImage AlbumArt { get; set; } // Album art as a BitmapImage

        public string Author { get; set; }

        public Song(string title, string fullPath, System.Windows.Media.Imaging.BitmapImage albumArt, string author)
        {
            Title = title;
            FullPath = fullPath;
            AlbumArt = albumArt;
            Author = author;
        }

    }
}
