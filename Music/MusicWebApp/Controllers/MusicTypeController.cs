using BusinessLogic.Abstract;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MusicWebApp.Controllers
{
    public class MusicTypeController : Controller
    {
        private readonly IMusicTypeBL _musicTypeBL;
        public MusicTypeController(IMusicTypeBL musicTypeBL)
        {
            _musicTypeBL = musicTypeBL;
        }

        public IActionResult Index()
        {
            List<MusicType> musicTypes = _musicTypeBL.Read();

            return View(musicTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MusicType musicType)
        {
            if (ModelState.IsValid)
            {
                _musicTypeBL.Create(musicType);
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int music_type_id)
        {
            MusicType musicType = _musicTypeBL.Read(music_type_id);

            return View(musicType);
        }

        [HttpPost]
        public IActionResult Edit(MusicType musicType)
        {
            if (ModelState.IsValid)
            {
                _musicTypeBL.Update(musicType);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int music_type_id)
        {
            _musicTypeBL.Delete(music_type_id);

            return RedirectToAction("Index");
        }
    }
}
