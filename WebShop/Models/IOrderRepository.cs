using System;
namespace WebShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
