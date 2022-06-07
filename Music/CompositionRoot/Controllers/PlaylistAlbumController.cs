using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistAlbumController : Controller
    {
        private readonly IPlaylistAlbumBL _playlistAlbumBL;
        public PlaylistAlbumController(IPlaylistAlbumBL playlistAlbumBL)
        {
            _playlistAlbumBL = playlistAlbumBL;
        }

        [HttpGet]
        public List<PlaylistAlbum> Get()
        {
            return _playlistAlbumBL.Read();
        }

        [HttpPost]
        public void Post(PlaylistAlbum playlistAlbum)
        {
            _playlistAlbumBL.Create(playlistAlbum);
        }

        [HttpPut]
        public void Update(PlaylistAlbum playlistAlbum)
        {
            _playlistAlbumBL.Update(playlistAlbum);
        }

        [HttpDelete]
        public void Delete(int playlist_album_id)
        {
            _playlistAlbumBL.Delete(playlist_album_id);
        }
    }
}
