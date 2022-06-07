using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class PlaylistArtistController : Controller
    {
        private readonly IPlaylistArtistBL _playlistArtistBL;
        private readonly IPlaylistBL _playlistBL;
        private readonly IArtistBL _artistBL;
        public PlaylistArtistController(IPlaylistArtistBL playlistArtistBL, IPlaylistBL playlistBL, IArtistBL artistBL)
        {
            _playlistArtistBL = playlistArtistBL;
            _playlistBL = playlistBL;
            _artistBL = artistBL;
        }

        public IActionResult Index()
        {
            List<PlaylistArtist> playlistArtists = _playlistArtistBL.Read();

            return View(playlistArtists);
        }

        public IActionResult Create()
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.LastName + " " + item.FirstName });

            return View();
        }

        [HttpPost]
        public IActionResult Create(PlaylistArtist playlistArtist)
        {
            if (ModelState.IsValid)
            {
                _playlistArtistBL.Create(playlistArtist);
            }
            else
                return View();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int playlist_artist_id)
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.Artists = _artistBL.Read().Select(item => new SelectListItem { Value = item.ArtistId.ToString(), Text = item.LastName + " " + item.FirstName });

            PlaylistArtist playlistArtist = _playlistArtistBL.Read(playlist_artist_id);

            return View(playlistArtist);
        }

        [HttpPost]
        public IActionResult Edit(PlaylistArtist playlistArtist)
        {
            if (ModelState.IsValid)
            {
                _playlistArtistBL.Update(playlistArtist);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int playlist_artist_id)
        {
            _playlistArtistBL.Delete(playlist_artist_id);

            return RedirectToAction("Index");
        }
    }
}
