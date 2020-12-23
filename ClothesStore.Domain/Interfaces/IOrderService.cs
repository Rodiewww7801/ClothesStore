using ClothesStore.Data.Entities.OrderAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDetails order);
    }
}
