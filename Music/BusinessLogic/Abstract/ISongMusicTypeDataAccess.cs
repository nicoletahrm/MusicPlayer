using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISongMusicTypeDataAccess
    {
        void Create(SongMusicType songMusicType);
        List<SongMusicType> Read();
        SongMusicType Read(int song_music_type_id);
        void Update(SongMusicType songMusicType);
        void Delete(int song_music_type_id);
    }
}
