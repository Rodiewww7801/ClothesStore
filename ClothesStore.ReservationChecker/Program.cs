using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Domain.

namespace ClothesStore.ReservationChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            while (true)
            {
                var reservation_list = _reservationRepository.GetAll();
                foreach (var reserv in reservation_list)
                {
                    if (DateTime.Now > reserv.End && reserv.OrderId == null)
                    {
                            foreach (var item in reserv.ReservedItems)
                            {
                                _productRepository.AddProductQuantity(item.ProductId, item.ReservedQuantity);
                            }
                            reserv.End = DateTime.Now;
                            _reservationRepository.Remove(reserv);
                    }
                }
            }
        }
    }
}
