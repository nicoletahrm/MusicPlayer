using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlaylistBL : IPlaylistBL
    {
        private readonly IPlaylistDataAccess _playlistDataAccess;

        public PlaylistBL(IPlaylistDataAccess playlistDataAccess)
        {
            _playlistDataAccess = playlistDataAccess ?? throw new ArgumentNullException("IPlaylistDataAccess canot be null");
        }

        public void Create(Playlist playlist)
        {
            _playlistDataAccess.Create(playlist);
        }

        public List<Playlist> Read()
        {
            return _playlistDataAccess.Read();
        }

        public Playlist Read(int playlist_id)
        {
            return _playlistDataAccess.Read(playlist_id);
        }

        public void Update(Playlist playlist)
        {
            _playlistDataAccess.Update(playlist);
        }

        public void Delete(int playlist_id)
        {
            _playlistDataAccess.Delete(playlist_id);
        }

        public List<Song> PlaylistSongs(int playlist_id)
        {
            return _playlistDataAccess.PlaylistSongs(playlist_id);
        }
    }
}
