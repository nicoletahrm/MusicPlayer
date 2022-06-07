using BusinessLogic.Abstract;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ArtistBL : IArtistBL
    {
        private readonly IArtistDataAccess _artistDataAccess;

        public ArtistBL(IArtistDataAccess artistDataAccess)
        {
            _artistDataAccess = artistDataAccess ?? throw new ArgumentNullException("IArtistDataAccess canot be null");
        }

        public void Create(Artist artist)
        {
            _artistDataAccess.Create(artist);
        }

        public List<Artist> Read()
        {
            return _artistDataAccess.Read();
        }

        public Artist Read(int artist_id)
        {
            return _artistDataAccess.Read(artist_id);
        }

        public void Update(Artist artist)
        {
            _artistDataAccess.Update(artist);
        }

        public void Delete(int artist_id)
        {
            _artistDataAccess.Delete(artist_id);
        }

        public List<Artist> TopArtists()
        {
            return _artistDataAccess.TopArtists();
        }
    }
}
