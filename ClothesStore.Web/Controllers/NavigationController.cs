using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesStore.Data.Repositories;

namespace ClothesStore.Web.Controllers
{
    public class NavigationController : Controller
    {
        IProductRepository _repository;
        public NavigationController(IProductRepository repository)
        {
            _repository = repository;
        }


        // GET: Navigation

        public PartialViewResult Menu()
        {
            return PartialView(_repository.AllCategories());
        }
    }
}