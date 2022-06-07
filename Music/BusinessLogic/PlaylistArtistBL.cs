using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PlaylistArtistBL : IPlaylistArtistBL
    {
        private readonly IPlaylistArtistDataAccess _playlistArtistDataAccess;

        public PlaylistArtistBL(IPlaylistArtistDataAccess playlistArtistDataAccess)
        {
            _playlistArtistDataAccess = playlistArtistDataAccess ?? throw new ArgumentNullException("IPlaylistArtistDataAccess canot be null");
        }

        public void Create(PlaylistArtist playlistArtist)
        {
            _playlistArtistDataAccess.Create(playlistArtist);
        }

        public List<PlaylistArtist> Read()
        {
            return _playlistArtistDataAccess.Read();
        }

        public PlaylistArtist Read(int playlist_artist_id)
        {
            return _playlistArtistDataAccess.Read(playlist_artist_id);
        }

        public void Update(PlaylistArtist playlistArtist)
        {
            _playlistArtistDataAccess.Update(playlistArtist);
        }

        public void Delete(int playlist_artist_id)
        {
            _playlistArtistDataAccess.Delete(playlist_artist_id);
        }

    }
}
