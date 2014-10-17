using System;
using ShortBus;
using Web.Models.Commands;

namespace Web.Models.CommandHandlers
{
    public class PlacesOrder : ICommandHandler<PlaceOrder>
    {
        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Places an order...");
        }
    }
}