using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumBL _albumBL;
        private readonly IArtistBL _artistBL;
        private readonly IPlaylistBL _playlistBL;
        private readonly IPlaylistSongBL _playlistSongBL;
        private readonly IPlaylistAlbumBL _playlistAlbumBL;

        public AlbumController(IAlbumBL albumBL, IArtistBL artistBL, IPlaylistBL playlistBL, IPlaylistAlbumBL playlistAlbumBL, IPlaylistSongBL playlistSongBL)
        {
            _albumBL = albumBL;
            _artistBL = artistBL;
            _playlistBL = playlistBL;
            _playlistAlbumBL = playlistAlbumBL;
            _playlistSongBL = playlistSongBL;
        }
        public IActionResult Index()
        {
            List<Album> albums = _albumBL.Read();

            return View(albums);
        }
        public IActionResult Create()
        {
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.LastName + " " + item.FirstName });

            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid) // ModelState = starea modelului la un moment dat (momentul actual)
            {
               
                _albumBL.Create(album); // salvez albumul in baza de date

            }
            
            else
                return View();

            return RedirectToAction("Index"); // redirectionez catre Index
        }
        public IActionResult Edit(int album_id)
        {
            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.LastName + " " + item.FirstName });

            Album album = _albumBL.Read(album_id);

            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _albumBL.Update(album);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int album_id)
        {
            _albumBL.Delete(album_id);

            return RedirectToAction("Index");
        }

        public IActionResult AddAlbumToPlaylist(int album_id)
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.AlbumId = album_id;

            return View();
        }

        [HttpPost]
        public IActionResult AddAlbumToPlaylist(PlaylistAlbum playlistAlbum)
        {
            if (ModelState.IsValid)
            {
                _playlistAlbumBL.Create(playlistAlbum);
                _playlistSongBL.AddAlbumSongs(playlistAlbum.AlbumId, playlistAlbum.PlaylistId);
            }

            return RedirectToAction("Index", "PlaylistAlbum");
        }
    }
}
