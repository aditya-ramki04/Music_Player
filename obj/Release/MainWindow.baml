   M S B A M L   `   `   `  ����   Music_Player    Music_Player.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ���#222222  � Title$  
MainWindow��$	��450��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $��20 � � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�o� $��0�����#222222.@�m� $
��Home��
�������m� -   $��	Playlists��
�������m� $��Library��
��������� $��1��$��0�����#2b2b2b$��10,10,10,10q�.+��� -   $��PlaylistTitle��$��Playlist��
�������$��18(�$
��Bold"�$��10q��� -   $��PlaylistSongsListBox�����#2b2b2b$��10,10,10,10q����� .R��� 
����������� *Title+�� -   $��Add Song to Playlist��$��10q��� -   $��Remove Song from Playlist��$��10q��� $��1��$��1�����#2b2b2b$��10,10,10,10q�.+��� $��Library/Main Section��
�������$��18(�$
��Bold"��� -   $��SongListBox��$��10,10,10,10q����#2b2b2b$
��Auto=����� .R��� 
����������� *Title+�� -   $��	Add Songs��$��10q��� $��1��$��2�����#2b2b2b$��10,10,10,10q�.+��� $��Now Playing��
�������$��18(�$
��Bold"��� -   $��AlbumArtImage��$��Uniform=�$��Stretch=�$��Stretch=�$��10q��� -	   $��NowPlayingTitle��$��No song playing��
�������$��18(�$
��Bold"�$��10q��� -
   $��NowPlayingAuthor��$��No Author Available��
�������$��18(�$
��Bold"�$��10q��� $��2��$��0��$��3�� �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $
��Play���� -   $��Pause��� -    �Name$ SongProgressBar�� � Minimum$ 0Q� � Maximum$	 100Q� � Value$ 0Q�$	��400��$��20��