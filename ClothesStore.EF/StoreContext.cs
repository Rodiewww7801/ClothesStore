using ClothesStore.Data;
using ClothesStore.Data.Entities;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Entities.ReservationAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.EF
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservedItem> ReservedItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>().HasMany(x => x.OrderItems).WithRequired(c => c.Order);
            modelBuilder.Entity<Order>().HasRequired(o => o.OrderDetails).WithRequiredPrincipal(d => d.Order);
            modelBuilder.Entity<Reservation>().HasMany( x => x.ReservedItems).WithRequired( i => i.Reservation);

        }
    }
}
