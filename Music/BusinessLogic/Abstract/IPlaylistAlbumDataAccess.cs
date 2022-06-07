using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistAlbumDataAccess
    {
        void Create(PlaylistAlbum playlistAlbum);
        List<PlaylistAlbum> Read();
        PlaylistAlbum Read(int playlist_album_id);
        void Update(PlaylistAlbum playlistAlbum);
        void Delete(int playlist_album_id);
    }
}
