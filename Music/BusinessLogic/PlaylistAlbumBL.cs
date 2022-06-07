using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlaylistAlbumBL : IPlaylistAlbumBL
    {
        private readonly IPlaylistAlbumDataAccess _playlistAlbumDataAccess;

        public PlaylistAlbumBL(IPlaylistAlbumDataAccess playlistAlbumDataAccess)
        {
            _playlistAlbumDataAccess = playlistAlbumDataAccess ?? throw new ArgumentNullException("IPlaylistAlbumDataAccess canot be null");
        }

        public void Create(PlaylistAlbum playlistAlbum)
        {
            _playlistAlbumDataAccess.Create(playlistAlbum);
        }

        public List<PlaylistAlbum> Read()
        {
            return _playlistAlbumDataAccess.Read();
        }

        public PlaylistAlbum Read(int playlist_album_id)
        {
            return _playlistAlbumDataAccess.Read(playlist_album_id);
        }

        public void Update(PlaylistAlbum playlistAlbum)
        {
            _playlistAlbumDataAccess.Update(playlistAlbum);
        }

        public void Delete(int playlist_album_id)
        {
            _playlistAlbumDataAccess.Delete(playlist_album_id);
        }
    }
}
