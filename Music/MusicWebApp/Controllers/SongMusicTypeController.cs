using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApp.Controllers
{
    public class SongMusicTypeController : Controller
    {
        private readonly ISongMusicTypeBL _songMusicTypeBL;
        private readonly ISongBL _songBL;
        private readonly IMusicTypeBL _musicTypeBL;
        public SongMusicTypeController(ISongMusicTypeBL songMusicTypeBL, ISongBL songBL, IMusicTypeBL musicTypeBL)
        {
            _songMusicTypeBL = songMusicTypeBL;
            _songBL = songBL;
            _musicTypeBL = musicTypeBL;
        }

        public IActionResult Index()
        {
            List<SongMusicType> songMusiTypes = _songMusicTypeBL.Read();
 
            return View(songMusiTypes);
        }

        public IActionResult Create()
        {
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });

            ViewBag.MusicTypes = _musicTypeBL.Read().Select(item => new SelectListItem { Value = item.MusicTypeId.ToString(), Text = item.Genre });

            return View();
        }

        [HttpPost]
        public IActionResult Create(SongMusicType songMusicType)
        {
            if (ModelState.IsValid)
            {
                _songMusicTypeBL.Create(songMusicType);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int song_music_type_id)
        {
            ViewBag.Songs = _songBL.Read().Select(item => new SelectListItem { Value = item.SongId.ToString(), Text = item.Title });

            ViewBag.MusicTypes = _musicTypeBL.Read().Select(item => new SelectListItem { Value = item.MusicTypeId.ToString(), Text = item.Genre });

            SongMusicType songMusicType = _songMusicTypeBL.Read(song_music_type_id);

            return View(songMusicType);
        }

        [HttpPost]
        public IActionResult Edit(SongMusicType songMusicType)
        {
            if (ModelState.IsValid)
            {
                _songMusicTypeBL.Update(songMusicType);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int song_music_type_id)
        {
            _songMusicTypeBL.Delete(song_music_type_id);

            return RedirectToAction("Index");
        }
    }
}
