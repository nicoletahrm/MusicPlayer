using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SongMusicTypeBL : ISongMusicTypeBL
    {
        private readonly ISongMusicTypeDataAccess _songMusicTypeDataAccess;

        public SongMusicTypeBL(ISongMusicTypeDataAccess songMusicTypeDataAccess)
        {
            _songMusicTypeDataAccess = songMusicTypeDataAccess ?? throw new ArgumentNullException("ISongMusicTypeDataAccess canot be null");
        }

        public void Create(SongMusicType songMusicType)
        {
            _songMusicTypeDataAccess.Create(songMusicType);
        }

        public List<SongMusicType> Read()
        {
            return _songMusicTypeDataAccess.Read();
        }

        public SongMusicType Read(int song_music_type_id)
        {
            return _songMusicTypeDataAccess.Read(song_music_type_id);
        }

        public void Update(SongMusicType songMusicType)
        {
            _songMusicTypeDataAccess.Update(songMusicType);
        }

        public void Delete(int song_music_type_id)
        {
            _songMusicTypeDataAccess.Delete(song_music_type_id);
        }
    }
}
