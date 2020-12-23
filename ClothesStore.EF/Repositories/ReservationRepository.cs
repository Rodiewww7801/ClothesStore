using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Data.Repositories;
using ClothesStore.Data.Entities.ReservationAggregate;
using System.Data.Entity;

namespace ClothesStore.EF.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        StoreContext ctx = new StoreContext();


        public void Create(Reservation reservation)
        {
            ctx.Reservations.Add(reservation);
            ctx.SaveChanges();
        }

        public Reservation Get(int id)
        {
            return ctx.Reservations.Include(b => b.ReservedItems).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Reservation> GetAll()
        {
            return ctx.Reservations.Include(b => b.ReservedItems).ToList();
        }


        public void Update(Reservation reservation)
        {
            ctx.Reservations.Attach(reservation);
            ctx.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Remove(Reservation reservation)
        {

            ctx.Reservations.Attach(reservation);
            ctx.Reservations.Remove(reservation);
            ctx.SaveChanges();
        }
    }
}
