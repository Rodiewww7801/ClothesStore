using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesStore.Data.Repositories;

namespace ClothesStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repository;
        public HomeController(IProductRepository repository)
        {
            _repository = repository;
        }
        public ViewResult List()
        {

            return View(_repository.Products());
        }
    }
}