using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesStore.Domain.Interfaces;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Repositories;
using ClothesStore.Data.Entities.ReservationAggregate;

namespace ClothesStore.Web.Controllers
{
	public class OrderController : Controller
	{
		private IOrderService _orderService;
		private IReservationService _reservationService;
		private ICartProvider _cartProvider;
		private IReservationRepository _reservationRepository;
		private IProductRepository _productRepository;
		public OrderController(
			IOrderService orderService,
			IReservationService reservationService,
			ICartProvider cartProvider,
			IReservationRepository reservationRepository,
			IProductRepository productRepository)
		{
			_orderService = orderService;
			_reservationService = reservationService;
			_cartProvider = cartProvider;
			_reservationRepository = reservationRepository;
			_productRepository = productRepository;

		}

		
		public RedirectToRouteResult Reservation()
        {
			var cart = _cartProvider.GetCart();
			foreach(var item in cart.OrderItems)
            {
				if(item.Quantity > _productRepository.GetProduct(item.ProductId).QuantityInStock)
                {
					throw new Exception($"Item \"{item.ProductId}\" was reserved");
                }
            }
			_reservationService.Reserve(_cartProvider.GetCart());
			_cartProvider.GetCart().OrderItems.Clear();
			return RedirectToAction("Checkout");
        }


        public ActionResult Checkout()
        {
			return View(new OrderDetails());
        }

        [HttpPost]
        public ActionResult Checkout(OrderDetails details)
		{
			var cart = _cartProvider.GetCart();
			var reservation = _reservationRepository.Get(cart.ReservationId);

			if (ModelState.IsValid)
			{
				if (_reservationService.IsActive(reservation.Id))
				{
					_orderService.CreateOrder(details);
					reservation.OrderId = cart.Id;
					_reservationRepository.Update(reservation);

					return View("Complete");
				}
                else {
					_reservationService.RemoveReservation(cart.ReservationId);
					throw new TimeoutException("Time Out");
				}

			}

			else
			{
				return View(details);
			}
		}

		

		// GET: Order
		public ActionResult Index()
		{
			return View();
		}
	}
}