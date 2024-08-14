using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    public class SongEqualityComparer : IEqualityComparer<Song>
    {
        public bool Equals(Song x, Song y)
        {
            return x.FullPath == y.FullPath; // Compare based on the FullPath
        }

        public int GetHashCode(Song obj)
        {
            return obj.FullPath.GetHashCode(); // Use the hash code of the FullPath
        }
    }
}
