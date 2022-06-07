using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class ArtistSongController : Controller
    {
        private readonly IArtistSongBL _artistSongBL;
        private readonly IArtistBL _artistBL;
        private readonly ISongBL _songBL;
        public ArtistSongController(IArtistSongBL artistSongBL, IArtistBL artistBL, ISongBL songBL)
        {
            _artistSongBL = artistSongBL;
            _artistBL = artistBL;
            _songBL = songBL;
        }

        public IActionResult Index()
        {
            List<ArtistSong> artistSongs = _artistSongBL.Read();

            return View(artistSongs);
        }

        public IActionResult Create()
        {
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.LastName + " " + item.FirstName });

            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });

            return View();
        }

        [HttpPost]
        public IActionResult Create(ArtistSong artistSong)
        {
            if (ModelState.IsValid)
            {
                _artistSongBL.Create(artistSong);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int artist_song_id)
        {
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.LastName + " " + item.FirstName });

            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });

            ArtistSong artistSong = _artistSongBL.Read(artist_song_id);

            return View(artistSong);
        }

        [HttpPost]
        public IActionResult Edit(ArtistSong artistSong)
        {
            if (ModelState.IsValid)
            {
                _artistSongBL.Update(artistSong);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int artist_song_id)
        {
            _artistSongBL.Delete(artist_song_id);

            return RedirectToAction("Index");
        }
    }
}
