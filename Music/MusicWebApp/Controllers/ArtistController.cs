using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistBL _artistBL;
        private readonly IPlaylistBL _playlistBL;
        private readonly IPlaylistSongBL _playlistSongBL;
        private readonly IPlaylistArtistBL _playlistArtistBL;
        public ArtistController(IArtistBL artistBL, IPlaylistBL playlistB, IPlaylistArtistBL playlistArtistBL, IPlaylistSongBL playlistSongBL)
        {
            _artistBL = artistBL;
            _playlistBL = playlistB;
            _playlistArtistBL = playlistArtistBL;
            _playlistSongBL = playlistSongBL;
        }

        public IActionResult Index() // lista artistilor
        {
            List<Artist> artists = _artistBL.Read();

            return View(artists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // create
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid) // ModelState = starea modelului la un moment dat (momentul actual)
            {
                _artistBL.Create(artist); // salvez artistul in baza de date
            }
            else 
                return View();

            return RedirectToAction("Index"); // redirectionez catre Index
        }

        public IActionResult Edit(int artist_id) // edit
        {
            Artist artist = _artistBL.Read(artist_id);

            return View(artist);
        }

        [HttpPost] // save edit
        public IActionResult Edit(Artist artist)
        {
            if(ModelState.IsValid)
            {
                _artistBL.Update(artist);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int artist_id) // delete
        {
            _artistBL.Delete(artist_id);

            return RedirectToAction("Index");
        }
        public IActionResult Details(int artist_id)
        {
            Artist artist = _artistBL.Read(artist_id);

            return View(artist);
        }

        public IActionResult AddArtistToPlaylist(int artist_id)
        {
            ViewBag.Playlists = _playlistBL.Read().Select(item => new SelectListItem { Value = item.PlaylistId.ToString(), Text = item.Title });

            ViewBag.ArtistId = artist_id;

            return View();
        }

        [HttpPost]
        public IActionResult AddArtistToPlaylist(PlaylistArtist playlistArtist)
        {
            if (ModelState.IsValid)
            {
                _playlistArtistBL.Create(playlistArtist);
                _playlistSongBL.AddArtistSongs(playlistArtist.ArtistId, playlistArtist.PlaylistId);
            }

            return RedirectToAction("Index", "PlaylistArtist");
        }
    }
}
