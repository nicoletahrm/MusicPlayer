using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistSongController : ControllerBase
    {
        private readonly IArtistSongBL _artistSongBL;
        public ArtistSongController(IArtistSongBL artistSongBL)
        {
            _artistSongBL = artistSongBL;
        }

        [HttpGet] //read
        public List<ArtistSong> Get()
        {
            return _artistSongBL.Read();
        }

        [HttpPost] //create
        public void Post(ArtistSong artistSong)
        {
            _artistSongBL.Create(artistSong);
        }

        [HttpPut] //update
        public void Update(ArtistSong artistSong)
        {
            _artistSongBL.Update(artistSong);
        }

        [HttpDelete] //delete
        public void Delete(int artist_song_id)
        {
            _artistSongBL.Delete(artist_song_id);
        }
    }
}
