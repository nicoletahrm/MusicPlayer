using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MusicWebApp.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistBL _playlistBL;
        private readonly ISongBL _songBL;
        private readonly IPlaylistSongBL _playlistSongBL;
        public PlaylistController(IPlaylistBL playlistBL, ISongBL songB, IPlaylistSongBL playlistSongBL)
        {
            _playlistBL = playlistBL;
            _songBL = songB;
            _playlistSongBL = playlistSongBL;
        }

        public IActionResult Index()
        {
            List<Playlist> playlists = _playlistBL.Read();

            return View(playlists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _playlistBL.Create(playlist);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int playlist_id)
        {
            Playlist playlist = _playlistBL.Read(playlist_id);

            return View(playlist);
        }

        [HttpPost]
        public IActionResult Edit(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _playlistBL.Update(playlist);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int playlist_id)
        {
            _playlistBL.Delete(playlist_id);

            return RedirectToAction("Index");
        }

        public IActionResult PlaylistSongs(int playlist_id)
        {
            ViewBag.PlaylistId = playlist_id;

            List<Song> songs = _playlistBL.PlaylistSongs(playlist_id);

            return View(songs);
        }

        public IActionResult AddLike(int song_id, int playlist_id)
        {
            _songBL.AddLike(song_id);

            return RedirectToAction("PlaylistSongs", new { playlist_id = playlist_id });
        }

        public IActionResult RemoveSongFromPlaylist(int song_id, int playlist_id)
        {
            _playlistSongBL.DeleteSongFromPlaylist(song_id);

            return RedirectToAction("PlaylistSongs", new { playlist_id = playlist_id });
        }
    }
}
