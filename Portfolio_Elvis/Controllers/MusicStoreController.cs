using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Elvis.Models;

namespace Portfolio_Elvis.Controllers
{
    public class MusicStoreController : Controller
    {
        private readonly MusicStoreContext _context;

        public MusicStoreController(MusicStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }

        public ActionResult Details(int id)
        {
            var album = new Album { Title = "Album " + id };
            return View(album);
        }
    }
}