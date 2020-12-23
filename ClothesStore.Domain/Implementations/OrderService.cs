using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Domain.Interfaces;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Repositories;

namespace ClothesStore.Domain.Implementations
{
    public class OrderService: IOrderService
    {
        private IOrderRepository _orderRepository;
        private ICartProvider _cartProvider;
        public OrderService(
            IOrderRepository orderRepository, 
            ICartProvider cartProvider)
        {
            _orderRepository = orderRepository;
            _cartProvider = cartProvider;

        }
        public void CreateOrder(OrderDetails orderDetails)
        {
            var order = _cartProvider.GetCart();
            order.OrderDate = DateTime.Now;
            order.Status = OrderStatusEnum.Paid_up;
            order.OrderDetails = orderDetails;
            _orderRepository.Create(order);
        }

       
    }
}
