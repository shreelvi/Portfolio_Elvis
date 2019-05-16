using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Elvis.Models;

namespace Portfolio_Elvis.Controllers
{
    /// <summary>
    /// Home controller for music store project
    /// Reference: https://web.csulb.edu/~pnguyen/cecs475/labs/mvc-music-store-tutorial-v30.pdf
    /// Followed tutorial to develop the project
    /// </summary>
    public class MusicStoreHomeController : Controller
    {
        private readonly MusicStoreContext _context;

        public MusicStoreHomeController(MusicStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Get most popular albums
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return _context.Albums
            .OrderByDescending(a => a.OrderDetails.Count())
            .Take(count)
            .ToList();
        }
    }
}