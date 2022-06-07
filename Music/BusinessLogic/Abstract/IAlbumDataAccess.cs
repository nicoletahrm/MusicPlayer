using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAlbumDataAccess
    {
        void Create(Album album);
        List<Album> Read();
        Album Read(int album_id);
        void Update(Album album);
        void Delete(int album_id);
    }
}
