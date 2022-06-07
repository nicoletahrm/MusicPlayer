using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISongBL
    {
        void Create(Song song);
        List<Song> Read();
        Song Read(int song_id);
        void Update(Song song);
        void Delete(int song_id);
        void AddLike(int song_id);
    }
}
