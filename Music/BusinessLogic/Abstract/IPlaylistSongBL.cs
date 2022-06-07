using DoamainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistSongBL
    {
        void Create(PlaylistSong playlist);
        List<PlaylistSong> Read();
        PlaylistSong Read(int playlist_song_id);
        void Update(PlaylistSong playlistSong);
        void Delete(int playlist_song_id);
        void AddArtistSongs(int artist_id, int playlist_id);
        void AddAlbumSongs(int album_id, int playlist_id);
        void DeleteSongFromPlaylist(int song_id);
    }
}
