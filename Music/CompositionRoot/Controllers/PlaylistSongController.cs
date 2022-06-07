using BusinessLogic.Abstract;
using DoamainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistSongController : Controller
    {
        private readonly IPlaylistSongBL _playlistSongBL;
        public PlaylistSongController(IPlaylistSongBL playlistSongBL)
        {
            _playlistSongBL = playlistSongBL;
        }

        [HttpGet]
        public List<PlaylistSong> Get()
        {
            return _playlistSongBL.Read();
        }

        [HttpPost]
        public void Post(PlaylistSong playlistSong)
        {
            _playlistSongBL.Create(playlistSong);
        }

        [HttpPut]
        public void Update(PlaylistSong playlistSong)
        {
            _playlistSongBL.Update(playlistSong);
        }

        [HttpDelete]
        public void Delete(int playlist_song_id)
        {
            _playlistSongBL.Delete(playlist_song_id);
        }
    }
}
