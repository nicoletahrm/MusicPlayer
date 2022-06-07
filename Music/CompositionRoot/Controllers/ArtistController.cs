using BusinessLogic;
using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistBL _artistBL;
        public ArtistController(IArtistBL artistBL)
        {
            _artistBL = artistBL;
        }

        [HttpGet] //read
        public List<Artist> Get()
        {
            return _artistBL.Read();
        }

        

        [HttpPost] //create
        public void Post(Artist artist)
        {
            _artistBL.Create(artist);
        }

        [HttpPut] //update
        public void Update(Artist artist)
        {
            _artistBL.Update(artist);
        }

        [HttpDelete] //delete
        public void Delete(int artist_id)
        {
            _artistBL.Delete(artist_id);
        }
    }
}
