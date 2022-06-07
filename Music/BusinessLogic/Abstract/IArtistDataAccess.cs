using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IArtistDataAccess
    {
        void Create(Artist artist);
        List<Artist> Read();
        Artist Read(int artist_id);
        void Update(Artist artist);
        void Delete(int artist_id);
        List<Artist> TopArtists();
    }
}
