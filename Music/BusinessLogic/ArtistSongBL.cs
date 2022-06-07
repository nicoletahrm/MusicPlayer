using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ArtistSongBL : IArtistSongBL
    {
        private readonly IArtistSongDataAccess _artistSongDataAccess;

        public ArtistSongBL(IArtistSongDataAccess artistSongDataAccess)
        {
            _artistSongDataAccess = artistSongDataAccess ?? throw new ArgumentNullException("IArtistSongDataAccess canot be null");
        }

        public void Create(ArtistSong artistSong)
        {
            _artistSongDataAccess.Create(artistSong);
        }

        public List<ArtistSong> Read()
        {
            return _artistSongDataAccess.Read();
        }

        public ArtistSong Read(int artist_song_id)
        {
            return _artistSongDataAccess.Read(artist_song_id);
        }

        public void Update(ArtistSong artistSong)
        {
            _artistSongDataAccess.Update(artistSong);
        }

        public void Delete(int artist_song_id)
        {
            _artistSongDataAccess.Delete(artist_song_id);
        }
    }
}
