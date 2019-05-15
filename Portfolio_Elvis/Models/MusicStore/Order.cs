using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Elvis.Models.MusicStore
{
    /// <summary>
    /// Created by:shreelvi
    /// Date created: 05/14/2019
    /// Order model for music store shopping
    /// This class tracks summary and delivery information for an order
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
