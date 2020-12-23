using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Data.Entities.OrderAggrigate;

namespace ClothesStore.Data.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int orderId);
        void Create(Order order);
        void Update(Order order);

    }
}
