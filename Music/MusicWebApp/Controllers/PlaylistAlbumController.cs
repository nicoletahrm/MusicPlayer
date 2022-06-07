using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class PlaylistAlbumController : Controller
    {
        private readonly IPlaylistAlbumBL _playlistAlbumBL;
        private readonly IPlaylistBL _playlistBL;
        private readonly IAlbumBL _albumBL;
        public PlaylistAlbumController(IPlaylistAlbumBL playlistAlbumBL, IPlaylistBL playlistBL, IAlbumBL albumBL)
        {
            _playlistAlbumBL = playlistAlbumBL;
            _playlistBL = playlistBL;
            _albumBL = albumBL;
        }

        public IActionResult Index()
        {
            List<PlaylistAlbum> playlistAlbums = _playlistAlbumBL.Read();

            return View(playlistAlbums);
        }

        public IActionResult Create()
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title });

            return View();
        }

        [HttpPost]
        public IActionResult Create(PlaylistAlbum playlistAlbum)
        {
            if (ModelState.IsValid)
            {
                _playlistAlbumBL.Create(playlistAlbum);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int playlist_album_id)
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.Albums = _albumBL.Read().Select(item => new SelectListItem { Value = item.AlbumId.ToString(), Text = item.Title });

            PlaylistAlbum playlistAlbum = _playlistAlbumBL.Read(playlist_album_id);

            return View(playlistAlbum);
        }

        [HttpPost]
        public IActionResult Edit(PlaylistAlbum playlistAlbum)
        {
            if (ModelState.IsValid)
            {
                _playlistAlbumBL.Update(playlistAlbum);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int playlist_album_id)
        {
            _playlistAlbumBL.Delete(playlist_album_id);

            return RedirectToAction("Index");
        }
    }
}
