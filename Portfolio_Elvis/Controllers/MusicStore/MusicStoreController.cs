﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var album = _context.Albums.Find(id);
            var genre = _context.Genres.Find(album.GenreId);
            album.Genre = genre;
            var artist = _context.Artists.Find(album.ArtistId);
            album.Artist = artist;

            return View(album);
        }

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = _context.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        // This action returns a list of Genres which will be displayed by the partial view
        public ActionResult GenreMenu()
        {
            var genres = _context.Genres.ToList();
            return PartialView(genres);
        }
    }
}