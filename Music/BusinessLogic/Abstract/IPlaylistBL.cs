using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPlaylistBL
    {
        void Create(Playlist playlist);
        List<Playlist> Read();
        Playlist Read(int playlist_id);
        void Update(Playlist playlist);
        void Delete(int playlist_id);
        List<Song> PlaylistSongs(int playlist_id);
    }
}
