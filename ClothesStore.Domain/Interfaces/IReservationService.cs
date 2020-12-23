using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Data.Entities.ReservationAggregate;
using ClothesStore.Data.Entities.OrderAggrigate;

namespace ClothesStore.Domain.Interfaces
{
    public interface IReservationService
    {
        Reservation Reserve(Order order);
        void RemoveReservation(int reservationId);
        void ReservationChecker();
        bool IsActive(int reservationId);

    }
}
