using System;
using System.Collections.Generic;
using System.Linq;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Repositories;

namespace ClothesStore.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        StoreContext ctx = new StoreContext();
        public IEnumerable<Order> GetAllOrders()
        {
            return ctx.Orders;
        }

        public Order GetOrder (int orderId)
        {
            return ctx.Orders.Include("OrderItem").Include("OrderDetails").First(x => x.Id == orderId);
        }

        public void Create(Order order)
        {
            ctx.Orders.Add(order);
            ctx.SaveChanges();
        }

        public void Update(Order order)
        {
            ctx.Orders.Attach(order);
            ctx.Entry(order).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public IEnumerable<OrderItem> GetOrderItems(Order order)
        {
            return ctx.Orders.Include("OrderItem").First(x => x.Id == order.Id).OrderItems;
        }

        

    }
}
