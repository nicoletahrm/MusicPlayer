using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicTypeController : ControllerBase
    {
        private readonly IMusicTypeBL _musicTypeBL;
        public MusicTypeController(IMusicTypeBL musicTypeBL)
        {
            _musicTypeBL = musicTypeBL;
        }

        [HttpGet] //read
        public List<MusicType> Get()
        {
            return _musicTypeBL.Read();
        }

        [HttpPost] //create
        public void Post(MusicType musicType)
        {
            _musicTypeBL.Create(musicType);
        }

        [HttpPut] //update
        public void Update(MusicType musicType)
        {
            _musicTypeBL.Update(musicType);
        }

        [HttpDelete] //delete
        public void Delete(int music_type_id)
        {
            _musicTypeBL.Delete(music_type_id);
        }
    }
}
