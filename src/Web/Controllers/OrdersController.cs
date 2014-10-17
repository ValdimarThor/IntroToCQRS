using System;
using System.Collections.Generic;
using System.Web.Http;
using ShortBus;
using Web.Models;
using Web.Models.Commands;
using Web.Models.Requests;

namespace Web.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/orders
        public IEnumerable<string> Get()
        {
            var address = new Address(){City = "Elgin", State = "CA", Street1 = "street", Street2 = "street", ZipCode = 12345};

            PlaceOrder cmd = new PlaceOrder()
            {
                Order =
                    new Order()
                    {
                        Header = new OrderHeader() {BillingAddress = address, ShippingAddress = address},
                        Items = null
                    },            
                UserId = Guid.NewGuid()
            };

            _mediator.Send(cmd);

            return new string[] { "value1", "value2" };
        }

        // GET api/orders/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/orders
        public void Post()
        {
            
        }

        // PUT api/orders/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/orders/5
        public void Delete(int id)
        {
        }
    }
}
