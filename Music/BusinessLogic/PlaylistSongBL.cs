using BusinessLogic.Abstract;
using DoamainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlaylistSongBL : IPlaylistSongBL
    {
        private readonly IPlaylistSongDataAccess _playlistSongDataAccess;

        public PlaylistSongBL(IPlaylistSongDataAccess playlistSongDataAccess)
        {
            _playlistSongDataAccess = playlistSongDataAccess ?? throw new ArgumentNullException("IPlaylistDataAccess canot be null");
        }

        public void Create(PlaylistSong playlistSong)
        {
            _playlistSongDataAccess.Create(playlistSong);
        }

        public List<PlaylistSong> Read()
        {
            return _playlistSongDataAccess.Read();
        }

        public PlaylistSong Read(int playlist_song_id)
        {
            return _playlistSongDataAccess.Read(playlist_song_id);
        }

        public void Update(PlaylistSong playlistSong)
        {
            _playlistSongDataAccess.Update(playlistSong);
        }

        public void Delete(int playlist_song_id)
        {
            _playlistSongDataAccess.Delete(playlist_song_id);
        }

        public void AddArtistSongs(int artist_id, int playlist_id)
        {
            _playlistSongDataAccess.AddArtistSongs(artist_id, playlist_id);
        }

        public void AddAlbumSongs(int album_id, int playlist_id)
        {
            _playlistSongDataAccess.AddAlbumSongs(album_id, playlist_id);
        }

        public void DeleteSongFromPlaylist(int song_id)
        {
            _playlistSongDataAccess.DeleteSongFromPlaylist(song_id);
        }
    }
}
