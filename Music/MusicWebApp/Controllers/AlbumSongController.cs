using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class AlbumSongController : Controller
    {
        private readonly IAlbumSongBL _albumSongBL;
        private readonly IAlbumBL _albumBL;
        private readonly ISongBL _songBL;

        public AlbumSongController(IAlbumSongBL albumSongBL, IAlbumBL albumBL, ISongBL songBL)
        {
            _albumSongBL = albumSongBL;
            _albumBL = albumBL;
            _songBL = songBL;
        }

        public IActionResult Index()
        {
            List<AlbumSong> artists = _albumSongBL.Read();

            return View(artists);
        }

        public IActionResult Create()
        {
            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title });

            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });

            return View();
        }

        [HttpPost]
        public IActionResult Create(AlbumSong albumSong)
        {
            if (ModelState.IsValid)
            {
                _albumSongBL.Create(albumSong);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int album_song_id)
        {
            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title });

            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });

            AlbumSong albumSong = _albumSongBL.Read(album_song_id);

            return View(albumSong);
        }

        [HttpPost]
        public IActionResult Edit(AlbumSong albumSong)
        {
            if (ModelState.IsValid)
            {
                _albumSongBL.Update(albumSong);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int album_song_id)
        {
            _albumSongBL.Delete(album_song_id);

            return RedirectToAction("Index");
        }
    }
}
