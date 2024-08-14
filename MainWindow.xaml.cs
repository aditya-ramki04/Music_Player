using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Music_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer;
        private string selectedSongFullPath; // full path to the song
        private bool isPlaying = false; // keeps track of whether the song is playing
        private bool isPaused = false; // flag to indicate if a song is paused
        private DispatcherTimer progressTimer; // Timer to update the progress bar
        private Song selectedSong; // Store the selected song


        private Playlist selectedPlaylist = null; // Instance of the playlist
        private ObservableCollection<Playlist> playlists; // Collection of playlists


        public MainWindow()
        {
            InitializeComponent();
            LoadSongs();
            mediaPlayer = new MediaPlayer();
            selectedPlaylist = new Playlist("My Playlist"); // Initialize the playlist
            playlists = new ObservableCollection<Playlist>(); // Initialize playlists

            PlaylistSongsListBox.ItemsSource = selectedPlaylist.Songs;

        }
        private void UpdatePlaylistTitle(string newTitle)
        {
            Console.WriteLine($"Updating PlaylistTitle to: {newTitle}"); // Debug print
            PlaylistTitle.Text = newTitle; // Update the TextBlock with the new title
        }

        private void PlaylistSongsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlaylistSongsListBox.SelectedItem is Song song) // Check if it's a valid Song
            {
                selectedSong = song;
                selectedSongFullPath = selectedSong.FullPath; // Get the full path

                Console.WriteLine($"Selected song path: {selectedSongFullPath}");
            }
            else
            {
                Console.WriteLine("No song selected."); // Debug output if no item is selected
            }
        }

        private void SongListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedSong = SongListBox.SelectedItem as Song; // Get the selected song
            selectedSongFullPath = selectedSong.FullPath; // get the full path of the selected song
            Console.WriteLine(selectedSongFullPath);

           
        }

        private void OpenPlaylistManager_Click(object sender, RoutedEventArgs e)
        {
            var playlistManager = new PlaylistManagerWindow(playlists);

            playlistManager.ShowDialog();

            selectedPlaylist = playlistManager.SelectedPlaylist;

            if (selectedPlaylist != null)
            {
                UpdatePlaylistTitle(selectedPlaylist.Name); // Update the TextBlock
                PlaylistSongsListBox.ItemsSource = selectedPlaylist.Songs;
            }
        }
        private void InitializeProgressTimer()
        {
            progressTimer = new DispatcherTimer();
            progressTimer.Interval = TimeSpan.FromMilliseconds(500); // Update every 500ms
            progressTimer.Tick += UpdateProgressBar;
        }

        private void UpdateProgressBar(object sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                var currentPosition = mediaPlayer.Position.TotalMilliseconds;
                var totalDuration = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;

                // Calculate progress as a percentage
                double progress = (currentPosition / totalDuration) * 100;
                SongProgressBar.Value = progress; // Update progress bar
            }
        }

        private void LoadSongs()
        {
            // Get the path to the "musicfiles" folder in the application directory
            string musicFolderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "musicfiles");

            // Ensure the folder exists; create it if not
            if (!Directory.Exists(musicFolderPath))
            {
                Directory.CreateDirectory(musicFolderPath);
            }

            // Clear the current contents of the ListBox
            SongListBox.Items.Clear();

            // Get all MP3 files from the music folder
            string[] songPaths = Directory.GetFiles(musicFolderPath, "*.mp3"); // Fetch all MP3 files

            // For each MP3 file, create a new Song object and add it to the ListBox
            foreach (string songPath in songPaths)
            {
                string[] parts = songPath.Split(new string[] { " - " }, 2, StringSplitOptions.None);
                string songTitle = System.IO.Path.GetFileNameWithoutExtension(parts[1]); // remove unwanted prefix and get title

                // Create a new Song instance
                var song = new Song(
                    title: songTitle,
                    fullPath: songPath,
                    albumArt: AlbumArtExtractor.GetAlbumArt(songPath), // Extract album art if applicable
                    author: AlbumArtExtractor.GetArtistName(songPath) // Extract the artist name if applicable
                );

                // Add the song to the ListBox
                SongListBox.Items.Add(song);
            }
        }





        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedSongFullPath))
            {
                if (isPaused)
                {
                    mediaPlayer.Play(); // resume if paused
                    progressTimer.Start(); // Start the timer to update the progress bar
                    isPaused = false; // reset paused flag
                }
                else
                {
                    // Stop current song if playing a new one
                    if (isPlaying)
                    {
                        mediaPlayer.Stop();
                    }

                    mediaPlayer.Open(new Uri(selectedSongFullPath, UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();

                    InitializeProgressTimer();
                    progressTimer.Start(); // Start the timer to update the progress bar

                    //var selectedSong = SongListBox.SelectedItem as Song;

                    if (selectedSong != null)
                    {
                        // Update the Now Playing section
                        NowPlayingTitle.Text = selectedSong.Title; // Set the song title

                        // Set the album art
                        if (selectedSong.AlbumArt != null)
                        {
                            AlbumArtImage.Source = selectedSong.AlbumArt; // Display the album art
                        }
                        else
                        {
                            AlbumArtImage.Source = null; // Clear the album art if it's not available
                        }

                        NowPlayingAuthor.Text = selectedSong.Author;
                    }

                }

                isPlaying = true; // indicate it's playing
            }
            else
            {
                MessageBox.Show("Please select a song from the list.");
            }
        }


        private void PauseSong_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                mediaPlayer.Pause(); // pause the song
                isPlaying = false; // indicate it's not playing
                isPaused = true; // set paused flag
                progressTimer.Stop();
            }
        }

        private void AddSongToPlaylist_Click(object sender, RoutedEventArgs e)
        {
            if (SongListBox.SelectedItem is Song selectedSong)
            {
                var newSong = new Song(selectedSong.Title, selectedSong.FullPath, selectedSong.AlbumArt, selectedSong.Author); // New instance

                if (!selectedPlaylist.Songs.Contains(newSong, new SongEqualityComparer())) // Avoid duplicates
                {
                    Console.WriteLine($"New song instance created: {newSong.Title} with path: {newSong.FullPath}");

                    selectedPlaylist.Songs.Add(newSong); // Add the new instance
                }
                else
                {
                    MessageBox.Show("Song is already in the playlist.");
                }
            }
            else
            {
                MessageBox.Show("Please select a song to add to the playlist.");
            }
        }


        private void RemoveSongFromPlaylist_Click(object sender, RoutedEventArgs e)
        {
            if (PlaylistSongsListBox.SelectedItem is Song selectedSong)
            {
                
                selectedPlaylist.Songs.Remove(selectedSong); // Remove the song from the playlist
            }
            else
            {
                MessageBox.Show("Please select a song to remove from the playlist.");
            }
        }

        private string GetMusicFolderPath()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"musicfiles");
        }

        private void AddSongsToLibrary_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; // Allow selecting multiple files
            openFileDialog.Filter = "MP3 Files|*.mp3"; // Filter for MP3 files

            // Get the absolute path to "musicfiles"
            string musicFolderPath = GetMusicFolderPath();

            // Set the initial directory for the OpenFileDialog
            openFileDialog.InitialDirectory = musicFolderPath; // Start from the "musicfiles" folder

            if (openFileDialog.ShowDialog() == true) // If the user selects files
            {
                // Ensure the folder exists
                if (!Directory.Exists(musicFolderPath))
                {
                    Directory.CreateDirectory(musicFolderPath); // Create the folder if it doesn't exist
                }

                foreach (string file in openFileDialog.FileNames)
                {
                    string fileName = System.IO.Path.GetFileName(file); // Get the file name
                    string targetPath = System.IO.Path.Combine(musicFolderPath, fileName); // Create the target path

                    // Copy the file to the target folder
                    File.Copy(file, targetPath, overwrite: true); // Overwrite if the file exists
                }

                // Reload the songs in the library after adding new files
                LoadSongs(); // Update the SongListBox with new files
            }
        }



    }
}
