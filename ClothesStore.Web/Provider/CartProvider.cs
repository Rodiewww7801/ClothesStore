using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesStore.Web.Provider
{
    public class CartProvider : ICartProvider
    {
        public Order GetCart()
        {
            HttpContext context = HttpContext.Current;


            Order order = (Order)context.Session["Cart"];
            if (order == null)
            {
                order = new Order();
                order.OrderItems = new List<OrderItem>();
                context.Session["Cart"] = order;
            }


            return order;
        } 
    }
}