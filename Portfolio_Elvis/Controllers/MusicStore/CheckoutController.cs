using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Elvis.Models;
using Portfolio_Elvis.Models.MusicStore;

namespace Portfolio_Elvis.Controllers.MusicStore
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly MusicStoreContext _context;
        const string PromoCode = "FREE";

        public CheckoutController(MusicStoreContext context)
        {
            _context = context;
        }

        //
        // GET: /Checkout/AddressAndPayment
        // Display a form to allow the user to enter their information.
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        // Validate the input and process the order
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModelAsync(order);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }

                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    //Save Order
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    //Process the order
                    ShoppingCart cart = new ShoppingCart(_context);
                    cart.GetCart(this.HttpContext);

                    cart.CreateOrder(order);
                    return RedirectToAction("Complete",
                    new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        // Check to validate that the order does indeed belong to the logged-in user 
        // Before showing the order number as a confirmation.
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = _context.Orders.Any(
            o => o.OrderId == id &&
            o.Username == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}