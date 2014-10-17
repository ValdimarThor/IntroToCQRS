namespace Web.Models.Requests
{
    public class OrderHeader
    {
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
    }
}