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
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}
