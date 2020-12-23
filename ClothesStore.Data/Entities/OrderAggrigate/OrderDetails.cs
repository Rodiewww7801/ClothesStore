using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClothesStore.Data.Entities.OrderAggrigate
{

    public class OrderDetails
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
