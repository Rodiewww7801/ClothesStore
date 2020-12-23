using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothesStore.Data;
using ClothesStore.Data.Entities;
using ClothesStore.Data.Entities.OrderAggrigate;

namespace ClothesStore.Web.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products;
        public string SelectedCategory;
    }
}