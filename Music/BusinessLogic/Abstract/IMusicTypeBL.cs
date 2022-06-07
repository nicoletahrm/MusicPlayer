using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IMusicTypeBL
    {
        void Create(MusicType musicType);
        List<MusicType> Read();
        MusicType Read(int music_type_id);
        void Update(MusicType musicType);
        void Delete(int music_type_id);
        List<Song> MostLikedSongs(string genre);
        List<MusicType> TopGenre();
    }
}
