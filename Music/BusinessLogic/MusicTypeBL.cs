using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MusicTypeBL : IMusicTypeBL
    {
        private readonly IMusicTypeDataAccess _musicTypeDataAccess;

        public MusicTypeBL(IMusicTypeDataAccess musicTypeDataAccess)
        {
            _musicTypeDataAccess = musicTypeDataAccess ?? throw new ArgumentNullException("IMusicTypeDataAccess canot be null");
        }

        public void Create(MusicType musicType)
        {
            _musicTypeDataAccess.Create(musicType);
        }

        public List<MusicType> Read()
        {
            return _musicTypeDataAccess.Read();
        }

        public MusicType Read(int music_type_id)
        {
            return _musicTypeDataAccess.Read(music_type_id);
        }

        public void Update(MusicType musicType)
        {
            _musicTypeDataAccess.Update(musicType);
        }

        public void Delete(int music_type_id)
        {
            _musicTypeDataAccess.Delete(music_type_id);
        }

        public List<Song> MostLikedSongs(string genre)
        {
            return _musicTypeDataAccess.MostLikedSongs(genre);
        }

        public List<MusicType> TopGenre()
        {
            return _musicTypeDataAccess.TopGenre();
        }
    }
}
