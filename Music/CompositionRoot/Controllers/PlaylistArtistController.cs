using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistArtistController : Controller
    {
        private readonly IPlaylistArtistBL _playlistArtistBL;
        public PlaylistArtistController(IPlaylistArtistBL playlistArtistBL)
        {
            _playlistArtistBL = playlistArtistBL;
        }

        [HttpGet]
        public List<PlaylistArtist> Get()
        {
            return _playlistArtistBL.Read();
        }

        [HttpPost]
        public void Post(PlaylistArtist playlistArtist)
        {
            _playlistArtistBL.Create(playlistArtist);
        }

        [HttpPut]
        public void Update(PlaylistArtist playlistArtist)
        {
            _playlistArtistBL.Update(playlistArtist);
        }

        [HttpDelete]
        public void Delete(int playlist_aritst_id)
        {
            _playlistArtistBL.Delete(playlist_aritst_id);
        }
    }
}
