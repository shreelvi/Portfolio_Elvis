using Portfolio_Elvis.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Elvis.Models
{
    /// <summary>
    /// Created by:shreelvi
    /// Date created: 05/14/2019
    /// OrderDetail model for music store shopping
    /// </summary>
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Album Album { get; set; }
        public virtual Order Order { get; set; }
    }
}
