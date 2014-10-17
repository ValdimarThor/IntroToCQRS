using System;

namespace Core.Orders.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime PlacedOn { get; set; }
        public double Total { get; set; }
    }
}
