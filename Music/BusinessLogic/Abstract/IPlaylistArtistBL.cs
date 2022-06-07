using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistArtistBL
    {
        void Create(PlaylistArtist playlistArtist);
        List<PlaylistArtist> Read();
        PlaylistArtist Read(int playlist_artist_id);
        void Update(PlaylistArtist playlistArtist);
        void Delete(int playlist_artist_id);
    }
}
