using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SongBL : ISongBL
    {
        private readonly ISongDataAccess _songDataAccess;

        public SongBL(ISongDataAccess songDataAccess)
        {
            _songDataAccess = songDataAccess ?? throw new ArgumentNullException("ISongDataAccess canot be null");
        }

        public void Create(Song song)
        {
            _songDataAccess.Create(song);
        }

        public List<Song> Read()
        {
            return _songDataAccess.Read();
        }

        public Song Read(int song_id)
        {
            return _songDataAccess.Read(song_id);
        }

        public void Update(Song song)
        {
            _songDataAccess.Update(song);
        }

        public void Delete(int song_id)
        {
            _songDataAccess.Delete(song_id);
        }

        public void AddLike(int song_id)
        {
            _songDataAccess.AddLike(song_id);
        }
    }
}
