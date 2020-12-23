using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothesStore.Domain;
using ClothesStore.Data.Entities;
using ClothesStore.Domain.Interfaces;
using ClothesStore.Data.Entities.OrderAggrigate;

namespace ClothesStore.Web.Models
{
    public class CartViewModel
    {
       // public ICartService Cart { get; set; }
        //Product
        public Dictionary<int, Product> Products { get; set; }
        public Order Order { get; set; }
        public decimal TotalPrice { get; set; }
        public string ReturnUrl { get; set; }
        public bool Error { get; set; }
    }
}