using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IMusicTypeBL _musicTypeBL;
        private readonly IArtistBL _artistBL;
        public StatisticsController(IMusicTypeBL musicTypeBL, IArtistBL artistBL)
        {
            _musicTypeBL = musicTypeBL;
            _artistBL = artistBL;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectGenre()
        {
            List<MusicType> musicTypes = _musicTypeBL.Read();

            return View(musicTypes);
        }

        public IActionResult MostLikedPerGenre(string genre)
        {
            List<Song> mostLikedSongs = _musicTypeBL.MostLikedSongs(genre);

            return View(mostLikedSongs);
        }

        public IActionResult TopGenre()
        {
            List<MusicType> topGenre = _musicTypeBL.TopGenre();

            return View(topGenre);
        }

        public IActionResult TopArtists()
        {
            List<Artist> topArtists = _artistBL.TopArtists();

            return View(topArtists);
        }
    }
}
