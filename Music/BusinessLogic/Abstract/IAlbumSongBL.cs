using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAlbumSongBL
    {
        void Create(AlbumSong album);
        List<AlbumSong> Read();
        AlbumSong Read(int album_song_id);
        void Update(AlbumSong albumSong);
        void Delete(int album_song_id);
    }
}
