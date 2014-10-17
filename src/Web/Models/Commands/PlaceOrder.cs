using System;
using ShortBus;

namespace Web.Models.Commands
{
    public class PlaceOrder : ICommand
    {
        public Order Order { get; set; }
        public Guid UserId { get; set; }
    }
}