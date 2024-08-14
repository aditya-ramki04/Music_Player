using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using System.Windows.Media.Imaging;
using System.IO;

namespace Music_Player
{
    internal class AlbumArtExtractor
    {
        public static BitmapImage GetAlbumArt(string mp3FilePath)
        {
            var file = TagLib.File.Create(mp3FilePath);

            if (file.Tag.Pictures.Length > 0)
            {
                var picture = file.Tag.Pictures[0];
                var imageStream = new MemoryStream(picture.Data.Data);
                var bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.StreamSource = imageStream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                return bitmap; // Returns BitmapImage to use in WPF
            }

            return null; // No album art found
        }

        public static string GetArtistName(string mp3FilePath)
        {
            var file = TagLib.File.Create(mp3FilePath);

            if (!string.IsNullOrEmpty(file.Tag.FirstPerformer)) // Extract the first artist name
            {
                return file.Tag.FirstPerformer; // Returns the artist's name
            }

            return "Unknown Artist"; // Default if no artist name is found
        }
    }
}
