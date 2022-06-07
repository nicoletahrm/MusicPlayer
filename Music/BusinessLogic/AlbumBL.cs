using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AlbumBL : IAlbumBL
    {
        private readonly IAlbumDataAccess _albumDataAccess;

        public AlbumBL(IAlbumDataAccess albumDataAccess)
        {
            _albumDataAccess = albumDataAccess ?? throw new ArgumentNullException("IAlbumDataAccess canot be null");
        }

        public void Create(Album album)
        {
            _albumDataAccess.Create(album);
        }

        public List<Album> Read()
        {
            return _albumDataAccess.Read();
        }

        public Album Read(int album_id)
        {
            return _albumDataAccess.Read(album_id);
        }

        public void Update(Album album)
        {
            _albumDataAccess.Update(album);
        }

        public void Delete(int album_id)
        {
            _albumDataAccess.Delete(album_id);
        }
    }
}
