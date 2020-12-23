using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Entities;
using ClothesStore.Data.Repositories;
using ClothesStore.Domain.Interfaces;
using System.Web;

namespace ClothesStore.Domain
{
    public class CartService: ICartService
    {
        private IProductRepository _productRepository;
        private ICartProvider _cartProvider;
        public CartService(IProductRepository productRepository, ICartProvider cartProvider)
        {
            _productRepository = productRepository;
            _cartProvider = cartProvider;
        }


        public OrderItem GetItem( int productId, int quantity)
        {
            var order =_cartProvider.GetCart();
            OrderItem item = order.OrderItems.FirstOrDefault(x => x.ProductId == productId);
            if(item == null)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = productId,
                    Quantity = quantity
                }) ;
            }
            else
            {
                order.OrderItems.Where(x => x.ProductId == productId).FirstOrDefault().Quantity += quantity;
            }
            return item;
           
        }
        public void RemoveOrderItem( int productId)
        {
            var order = _cartProvider.GetCart();   
           order.OrderItems.RemoveAll(x => x.ProductId == productId);
        }

        public decimal TotalPrice()
        {
            var order = _cartProvider.GetCart();
            decimal price = 0;
            foreach(var item in order.OrderItems)
            {
                var product = _productRepository.GetProduct(item.ProductId);
                price = product.Price * item.Quantity;
            }
            return price;
        }

        public void ClearCart()
        {
     
            _cartProvider.GetCart().OrderItems.Clear();
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            var order = _cartProvider.GetCart();
            return order.OrderItems;
        }
    }
}
