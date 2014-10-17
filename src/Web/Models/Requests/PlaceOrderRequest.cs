using System;

namespace Web.Models.Requests
{
    public class PlaceOrderRequest
    {
        public Guid UserId { get; set; }

        public Order Order { get; set; }
    }
}