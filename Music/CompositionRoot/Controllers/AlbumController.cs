using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumBL _albumBL;
        public AlbumController(IAlbumBL albumBL)
        {
            _albumBL = albumBL;
        }

        [HttpGet] //read
        public List<Album> Get()
        {
            return _albumBL.Read();
        }

        [HttpPost] //create
        public void Post(Album album)
        {
            _albumBL.Create(album);
        }

        [HttpPut] //update
        public void Update(Album album)
        {
            _albumBL.Update(album);
        }

        [HttpDelete] //delete
        public void Delete(int album_id)
        {
            _albumBL.Delete(album_id);
        }
    }

}
