using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    internal class SongRepository
    {
        private string musicFolderPath = @"musicfiles";
        public string[] GetSongs()
        {
            string[] music = Directory.GetFiles(musicFolderPath, "*.mp3");
            foreach (string song in music)
            {
                Console.WriteLine(song);
            }
            return music;
        }


    }
}
