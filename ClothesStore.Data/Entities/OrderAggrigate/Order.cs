using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Data.Entities.OrderAggrigate
{
    public enum OrderStatusEnum { Active = 1, Paid_up = 2 }
    public class Order
    {
        public int Id { get; set; }
        public OrderStatusEnum Status { get; set; }
        public DateTime OrderDate { get; set; }
        public int ReservationId { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
