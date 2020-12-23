using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Data.Entities.ReservationAggregate
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<ReservedItem> ReservedItems { get; set; }
        public int? OrderId { get; set; }
    }
}
