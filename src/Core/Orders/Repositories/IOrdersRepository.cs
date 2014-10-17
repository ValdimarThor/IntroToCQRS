using Core.Orders.Models;

namespace Core.Orders.Repositories
{
    public interface IOrdersRepository
    {
        void InsertOrder(Order order);
    }
}
