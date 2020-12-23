using System;
using System.Collections.Generic;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Entities.ReservationAggregate;
using ClothesStore.Domain.Interfaces;
using ClothesStore.Data.Repositories;

namespace ClothesStore.Domain.Implementations
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;
        private IProductRepository _productRepository;

        public ReservationService(
            IReservationRepository reservationRepository, 
            IProductRepository productRepository)
        {
            _reservationRepository = reservationRepository;
            _productRepository = productRepository;
        }
        public bool IsActive(int reservationId)
        {
            var reservation = _reservationRepository.Get(reservationId);
            return  reservation.Start < DateTime.Now && reservation.End > DateTime.Now;
        }

        public void ReservationChecker()
        {
            var reservation_list = _reservationRepository.GetAll();
            foreach (var reserv in reservation_list)
            {
                if(DateTime.Now > reserv.End && reserv.OrderId == null)
                {
                    RemoveReservation(reserv.Id);
                }
            }
        }

        public void RemoveReservation(int reservationId)
        {
            var reservation = _reservationRepository.Get(reservationId);
            foreach(var item  in reservation.ReservedItems)
            {
                _productRepository.AddProductQuantity(item.ProductId, item.ReservedQuantity);
            }
            reservation.End = DateTime.Now;
            _reservationRepository.Remove(reservation);
        }

        public Reservation Reserve(Order order)
        {
            

            foreach (var item in order.OrderItems)
            {
                ReservationChecker();
                if (item.Quantity > _productRepository.GetProduct(item.ProductId).QuantityInStock && item.Quantity <= 0)
                {
                    throw new NotImplementedException();
                }
            }
            var createReserve = new Reservation()
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddMinutes(5),
                ReservedItems = new List<ReservedItem>()
            };

            foreach (var item in order.OrderItems)
            {
                ReservedItem reservedItem = new ReservedItem()
                {
                    ProductId = item.ProductId,
                    ReservedQuantity = item.Quantity,
                    Reservation = createReserve,
                    ReservationId = createReserve.Id,
                };

                createReserve.ReservedItems.Add(reservedItem);
                _productRepository.DeleteProductQuantity(item.ProductId, item.Quantity);
            }
            _reservationRepository.Create(createReserve);
            order.ReservationId = createReserve.Id;
            
            return createReserve;
        }
    }
}
