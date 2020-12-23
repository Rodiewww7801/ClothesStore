using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesStore.Data.Entities;
using ClothesStore.Data.Entities.OrderAggrigate;
using ClothesStore.Data.Repositories;
using ClothesStore.Domain;
using ClothesStore.Web.Models;
using ClothesStore.Domain.Interfaces;

namespace ClothesStore.Web.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _productRepository;
        private ICartService _cartService;
        private ICartProvider _cartProvider;

        public CartController(
            IProductRepository productRepository,
            ICartService cartService, 
            ICartProvider cartProvider)
        {
            _productRepository = productRepository;
            _cartService = cartService;
            _cartProvider = cartProvider;
        }

        public RedirectToRouteResult AddToCart( int productID, string returnUrl)
        {
            Product product = _productRepository.GetProduct(productID);

            if(product != null && product.QuantityInStock > 0)
            {
                 _cartService.GetItem(product.Id, 1);
            }
            else
            {
                ModelState.AddModelError("OutOfStock", $"{product.Name} out of stock. Available in stock:{product.QuantityInStock}"); 
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCard( int productId, string returnUrl)
        {
            Product product = _productRepository.GetProduct(productId);
            if(product != null)
            {
                _cartService.RemoveOrderItem( productId);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult CartInfo(string returnUrl)
        {
            return PartialView(new CartViewModel
            {
                TotalPrice = _cartService.TotalPrice(),
                Products = _productRepository.Products().ToDictionary(x => x.Id),
                Order = _cartProvider.GetCart(),
                ReturnUrl = returnUrl
            });
        }


        public ViewResult Index( string returnUrl)
        {
            var cart = _cartProvider.GetCart();
            if (cart.OrderItems.Count() == 0)
            {
                ModelState.AddModelError("Count", "Your cart is empty");
               
            }
            foreach(var item in cart.OrderItems)
            {
               var product = _productRepository.GetProduct(item.ProductId);
                if (item.Quantity > product.QuantityInStock)
                {
                    ModelState.AddModelError("OutOfStock", $"{product.Name} out of stock. Available in stock:{product.QuantityInStock}");
                }
            }
            var errorList = ModelState.ToList();
            return View(new CartViewModel
            {
                TotalPrice = _cartService.TotalPrice(),
                Products = _productRepository.Products().ToDictionary(x => x.Id),
                Order = cart,
                ReturnUrl = returnUrl,
                Error = ModelState.IsValid
            }) ;
        }
    }
}