using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumSongController : Controller
    {
        private readonly IAlbumSongBL _albumSongBL;
        public AlbumSongController(IAlbumSongBL albumSongBL)
        {
            _albumSongBL = albumSongBL;
        }

        [HttpGet]
        public List<AlbumSong> Get()
        {
            return _albumSongBL.Read();
        }

        [HttpPost]
        public void Post(AlbumSong albumSong)
        {
            _albumSongBL.Create(albumSong);
        }

        [HttpPut]
        public void Update(AlbumSong albumSong)
        {
            _albumSongBL.Update(albumSong);
        }

        [HttpDelete]
        public void Delete(int album_song_id)
        {
            _albumSongBL.Delete(album_song_id);
        }
    }
}
