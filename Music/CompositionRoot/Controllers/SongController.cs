using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongBL _songBL;
        public SongController(ISongBL songBL)
        {
            _songBL = songBL;
        }

        [HttpGet] //read
        public List<Song> Get()
        {
            return _songBL.Read();
        }

        [HttpPost] //create
        public void Post(Song song)
        {
            _songBL.Create(song);
        }

        [HttpPut] //update
        public void Update(Song song)
        {
            _songBL.Update(song);
        }

        [HttpDelete] //delete
        public void Delete(int song_id)
        {
            _songBL.Delete(song_id);
        }
    }
}
