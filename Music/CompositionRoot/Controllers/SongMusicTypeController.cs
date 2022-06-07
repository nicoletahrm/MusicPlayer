using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongMusicTypeController : Controller
    {
       
        private readonly ISongMusicTypeBL _songMusicTypeBL;
        public SongMusicTypeController(ISongMusicTypeBL songMusicTypeBL)
        {
            _songMusicTypeBL = songMusicTypeBL;
        }

        [HttpGet] //read
        public List<SongMusicType> Get()
        {
            return _songMusicTypeBL.Read();
        }

        [HttpPost] //create
        public void Post(SongMusicType songMusicType)
        {
            _songMusicTypeBL.Create(songMusicType);
        }

        [HttpPut] //update
        public void Update(SongMusicType songMusicType)
        {
            _songMusicTypeBL.Update(songMusicType);
        }

        [HttpDelete] //delete
        public void Delete(int song_music_type_id)
        {
            _songMusicTypeBL.Delete(song_music_type_id);
        }
    }
}
