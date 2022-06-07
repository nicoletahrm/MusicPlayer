using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistBL _playlistBL;
        public PlaylistController(IPlaylistBL playlistBL)
        {
            _playlistBL = playlistBL;
        }

        [HttpGet]
        public List<Playlist> Get()
        {
            return _playlistBL.Read();
        }

        [HttpPost] 
        public void Post(Playlist playlist)
        {
            _playlistBL.Create(playlist);
        }

        [HttpPut]
        public void Update(Playlist playlist)
        {
            _playlistBL.Update(playlist);
        }

        [HttpDelete]
        public void Delete(int playlist_id)
        {
            _playlistBL.Delete(playlist_id);
        }
    }
}
