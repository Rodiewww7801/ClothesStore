using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Data.Entities.ReservationAggregate;

namespace ClothesStore.Data.Repositories
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        void Remove(Reservation reservation);
        Reservation Get(int id);
        List<Reservation> GetAll();


    }
}
