using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Elvis.Models.MusicStore.ViewModels
{
    /// <summary>
    /// Created by: shreelvi
    /// Date created: 05/14/2019
    /// Viewmodel to display information to the shopping cart view
    /// </summary>
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
