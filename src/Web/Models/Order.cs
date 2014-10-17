using Web.Models.Requests;

namespace Web.Models
{
    public class Order
    {
        public OrderHeader Header { get; set; }
        public OrderItem[] Items { get; set; }
    }
}