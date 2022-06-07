using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IArtistSongDataAccess
    {
        void Create(ArtistSong artistSong);
        List<ArtistSong> Read();
        ArtistSong Read(int artist_song_id);
        void Update(ArtistSong artistSong);
        void Delete(int artist_song_id);
    }
}
