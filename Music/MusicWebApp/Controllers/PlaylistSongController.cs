using BusinessLogic.Abstract;
using DoamainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class PlaylistSongController : Controller
    {
        private readonly IPlaylistSongBL _playlistSongBL;
        private readonly IPlaylistBL _playlistBL;
        private readonly ISongBL _songBL;
        public PlaylistSongController(IPlaylistSongBL playlistSongBL, IPlaylistBL playlistB, ISongBL songBL)
        {
            _playlistSongBL = playlistSongBL;
            _playlistBL = playlistB;
            _songBL = songBL;
        }

        public IActionResult Index()
        {
            List<PlaylistSong> playlistSongs = _playlistSongBL.Read();

            return View(playlistSongs);
        }

        public IActionResult Create()
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });

            return View();
        }

        [HttpPost]
        public IActionResult Create(PlaylistSong playlistSong)
        {
            if (ModelState.IsValid)
            {
                _playlistSongBL.Create(playlistSong);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int playlist_song_id)
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });


            PlaylistSong playlistSong = _playlistSongBL.Read(playlist_song_id);

            return View(playlistSong);
        }

        [HttpPost]
        public IActionResult Edit(PlaylistSong PlaylistSong)
        {
            if (ModelState.IsValid)
            {
                _playlistSongBL.Update(PlaylistSong);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int playlist_song_id)
        {
            _playlistSongBL.Delete(playlist_song_id);

            return RedirectToAction("Index");
        }
    }
}
