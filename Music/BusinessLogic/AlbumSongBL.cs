using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AlbumSongBL : IAlbumSongBL
    {
        private readonly IAlbumSongDataAccess _albumSongDataAccess;

        public AlbumSongBL(IAlbumSongDataAccess albumSongDataAccess)
        {
            _albumSongDataAccess = albumSongDataAccess ?? throw new ArgumentNullException("IAlbumSongDataAccess canot be null");
        }

        public void Create(AlbumSong albumSong)
        {
            _albumSongDataAccess.Create(albumSong);
        }

        public List<AlbumSong> Read()
        {
            return _albumSongDataAccess.Read();
        }

        public AlbumSong Read(int album_song_id)
        {
            return _albumSongDataAccess.Read(album_song_id);
        }

        public void Update(AlbumSong albumSong)
        {
            _albumSongDataAccess.Update(albumSong);
        }

        public void Delete(int album_song_id)
        {
            _albumSongDataAccess.Delete(album_song_id);
        }
    }
}
