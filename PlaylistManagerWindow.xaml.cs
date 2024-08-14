using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Music_Player
{
    /// <summary>
    /// Interaction logic for PlaylistManagerWindow.xaml
    /// </summary>
    public partial class PlaylistManagerWindow : Window
    {
        public ObservableCollection<Playlist> Playlists { get; set; }
        public Playlist SelectedPlaylist { get; private set; }
        public PlaylistManagerWindow(ObservableCollection<Playlist> existingPlaylists)
        {
            InitializeComponent();
            Playlists = existingPlaylists;
            PlaylistsListBox.ItemsSource = Playlists; // Bind to the playlist collection

            PlaylistsListBox.SelectionChanged += PlaylistsListBox_SelectionChanged; // Handle selection change
        }



        private void PlaylistsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPlaylist = PlaylistsListBox.SelectedItem as Playlist; // Store the selected playlist

            //remove these later
            if (SelectedPlaylist != null)
            {
                Console.WriteLine($"Selected Playlist: {SelectedPlaylist.Name}"); // Debug print
            }
            else
            {
                Console.WriteLine("No playlist selected."); // Debug if none is selected
            }
        }

        private void AddPlaylist_Click(object sender, RoutedEventArgs e) //used LINQ
        {
            var playlistName = NewPlaylistNameTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(playlistName))
            {
                // Use LINQ to check if the playlist with this name exists
                bool playlistExists = Playlists.Any(p => p.Name.Equals(playlistName, StringComparison.OrdinalIgnoreCase));

                if (!playlistExists)
                {
                    Playlists.Add(new Playlist(playlistName)); // Add a new playlist if it doesn't exist
                    NewPlaylistNameTextBox.Clear(); // Clear the text box
                }
                else
                {
                    MessageBox.Show("A playlist with this name already exists.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid playlist name.");
            }
        }

        private void DeletePlaylist_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlaylist = PlaylistsListBox.SelectedItem as Playlist;

            if (selectedPlaylist != null)
            {
                Playlists.Remove(selectedPlaylist); // Remove the selected playlist
            }
            else
            {
                MessageBox.Show("Please select a playlist to delete.");
            }
        }

    }
}
