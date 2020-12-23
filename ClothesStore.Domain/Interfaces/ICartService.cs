using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Entities;
using System.Web;

namespace ClothesStore.Domain.Interfaces
{
    public interface ICartService
    {
        OrderItem GetItem( int productId, int quantity);
        void RemoveOrderItem( int productId);
        decimal TotalPrice();
        void ClearCart();
        IEnumerable<OrderItem> GetOrderItems();
    }
}
