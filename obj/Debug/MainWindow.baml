   M S B A M L   `   `   `  ����  Music_Player    Music_Player.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ���#222222  � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   o� $��0��6   ���#222222.@�5      m� $
��Home��6   
�������6%   m� 5      -   5        $��	Playlists��5      
�������6=   m� 5      $��Library��6   
�������6(   5      �� 5   
   $��1��6   $��0��6"   ���#2b2b2b$��10,10,10,10q�6G   .+�5      �� -   5        $��PlaylistTitle��5      $��Playlist��6-   
�������$��18(�6P   $
��Bold"�6^   $��10q�6p   �� 5       -   5        $��PlaylistSongsListBox��5       ���#2b2b2b$��10,10,10,10q�6�   ��5!      �� 5"      .R�5#      �� 
���������6$   �� *Title+6;   5%      5'      �� 5*      -   5        $��Add Song to Playlist��5*      $��10q�6T   �� 5+      -   5        $��Remove Song from Playlist��5+      $��10q�6^   5,      �� 5/   
   $��1��6   $��1��6"   ���#2b2b2b$��10,10,10,10q�6G   .+�51      �� $��Library/Main Section��6   
�������$��18(�6G   $
��Bold"�6U   �� 52      -   5        $��SongListBox��52      $��10,10,10,10q�6Z   ���#2b2b2b$
��Auto=�6�   ��53      �� 54      .R�55      �� 
���������6$   �� *Title+6;   57      59      �� 5;      -   5        $��	Add Songs��5;      $��10q�6I   5<      �� 5A   
   $��1��6   $��2��6"   ���#2b2b2b$��10,10,10,10q�6G   .+�5C      �� $��Now Playing��6   
�������$��18(�6?   $
��Bold"�6M   �� 5D      -   5        $��AlbumArtImage��5D      $��Uniform=�6)   $��Stretch=�5E      $��Stretch=�5F      $��10q�6,   �� 5H      -	   5        $��NowPlayingTitle��5H      $��No song playing��6/   
�������$��18(�6Y   $
��Bold"�6g   $��10q�6y   �� 5I      -
   5        $��NowPlayingAuthor��5I      $��No Author Available��60   
�������$��18(�6^   $
��Bold"�6l   $��10q�6~   5J      �� 5L   
   $��2��6   $��0��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�5M      �� -   5        $
��Play��5M      5N      �� 5O      -   5        $��Pause��5O      6%   � 5P      -   5         �Name$ SongProgressBar��5P       � Minimum$ 0Q�5Q       � Maximum$	 100Q�5R       � Value$ 0Q�5S      $	��400��5T      $��20��5U      5Y      5[      5\      