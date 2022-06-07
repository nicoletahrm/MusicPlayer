using BusinessLogic.Abstract;
using DoamainModels;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongBL _songBL;
        private readonly IPlaylistBL _playlistBL;
        private readonly IPlaylistSongBL _playlistSongBL;
        public SongController(ISongBL songBL, IPlaylistBL playlistBL, IPlaylistSongBL playlistSongBL)
        {
            _songBL = songBL;
            _playlistBL = playlistBL;
            _playlistSongBL = playlistSongBL;
        }

        public IActionResult Index()
        {
            List<Song> songs = _songBL.Read();

            return View(songs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Song song)
        {
            if (ModelState.IsValid)
            {
                _songBL.Create(song);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int song_id)
        {
            Song song = _songBL.Read(song_id);

            return View(song);
        }

        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (ModelState.IsValid)
            {
                _songBL.Update(song);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int song_id)
        {
            _songBL.Delete(song_id);

            return RedirectToAction("Index");
        }

        public IActionResult AddSongToPlaylist(int song_id)
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.SongId = song_id;

            return View();
        }

        [HttpPost]
        public IActionResult AddSongToPlaylist(PlaylistSong playlistSong)
        {
            if (ModelState.IsValid)
            {
                _playlistSongBL.Create(playlistSong);
            }

            return RedirectToAction("Index", "PlaylistSong");
        }

        public IActionResult AddLike(int song_id)
        {
            _songBL.AddLike(song_id);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveSongFromPlaylist(int song_id)
        {
            _playlistSongBL.DeleteSongFromPlaylist(song_id);
           
            return RedirectToAction("Index", "PlaylistSongs");
        }

    }
}
