using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAlbumSongDataAccess
    {
        void Create(AlbumSong album);
        List<AlbumSong> Read();
        AlbumSong Read(int album_song_id);
        void Update(AlbumSong albumsSong);
        void Delete(int album_song_id);
    }
}
