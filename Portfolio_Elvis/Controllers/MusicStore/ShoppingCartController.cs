using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Elvis.Models;
using Portfolio_Elvis.Models.MusicStore;
using Portfolio_Elvis.Models.MusicStore.ViewModels;
using System.Text.Encodings.Web;


namespace Portfolio_Elvis.Controllers.MusicStore
{
    /// <summary>
    /// Created by: shreelvi
    /// Date created: 05/14/2019
    /// Shopping Cart controller is used for adding items to a cart, 
    /// removing items from the cart, and viewing items in the cart
    /// Reference: https://web.csulb.edu/~pnguyen/cecs475/labs/mvc-music-store-tutorial-v30.pdf
    /// Understood and used code from the reference 
    /// </summary>
    public class ShoppingCartController : Controller
    {
        private readonly MusicStoreContext _context;

        public ShoppingCartController(MusicStoreContext context)
        {
            _context = context;
        }

        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(_context);
            cart = cart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            //Manually fills the album and its information of shopping cart items
            for(int i = 0; i < viewModel.CartItems.Count; i++)
            {

                var aID = viewModel.CartItems[0].AlbumId;
                var album = _context.Albums.Find(aID);
                viewModel.CartItems[i].Album = album; //adds the album object to viewmodel cartitems

                var genre = _context.Genres.Find(album.GenreId);
                viewModel.CartItems[i].Album.Genre = genre;
                var artist = _context.Artists.Find(album.ArtistId);
                viewModel.CartItems[i].Album.Artist = artist;

            }
            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedAlbum = _context.Albums
            .Single(album => album.AlbumId == id);
            // Add it to the shopping cart
            ShoppingCart cart = new ShoppingCart(_context);
            cart = cart.GetCart(HttpContext);
            var a = addedAlbum.AlbumId;
            cart.AddToCart(addedAlbum);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            ShoppingCart cart = new ShoppingCart(_context);
            cart = cart.GetCart(HttpContext);
            // Get the name of the album to display confirmation
            string albumName = _context.Carts
            .Single(item => item.RecordId == id).Album.Title;
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = HtmlEncoder.Default.Encode(albumName) +
                          " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        public ActionResult CartSummary()
        {
            ShoppingCart cart = new ShoppingCart(_context);
            cart = cart.GetCart(HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}
