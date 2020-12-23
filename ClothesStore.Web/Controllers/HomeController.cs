using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesStore.Web.Models;
using ClothesStore.Data.Repositories;
using ClothesStore.Data;
using ClothesStore.Domain.Interfaces;

namespace ClothesStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repository;
        private IReservationService _reservationService;
        public HomeController(IProductRepository repository, IReservationService reservationService)
        {
            _repository = repository;
            _reservationService = reservationService;
        }

        public ViewResult List()
        {
            _reservationService.ReservationChecker();
            return View(_repository.Products());
        }
        public ViewResult CategoryList(string category)
        {
            _reservationService.ReservationChecker();
            ProductListViewModel model = new ProductListViewModel
            {
                Products = _repository.SelectedCategory(category),
                SelectedCategory = category
            };
            
            return View(model);
        }
    }
}