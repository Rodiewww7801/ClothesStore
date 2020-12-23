using ClothesStore.Data.Entities;
using ClothesStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.EF.Repositories
{
    public class ProductRepository : IProductRepository
    {
        StoreContext ctx = new StoreContext();
        public IEnumerable<Product> Products()
        {
            return (IEnumerable<Product>)ctx.Products;
        }

        public IEnumerable<Product> SelectedCategory(string category)
        {
            return ctx.Products.Where(x => x.Category == category).ToList();
        }

        public IEnumerable<string> AllCategories()
        {
            return ctx.Products.Select(x => x.Category).Distinct().OrderBy(x => x).ToList();
        }

        public Product GetProduct(int id)
        {
            return ctx.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public void DeleteProductQuantity(int id, int quantity)
        {
            Product product = GetProduct(id);
            ctx.Products.Attach(product);
            product.QuantityInStock -= quantity;
            ctx.Entry(product).Property(q => q.QuantityInStock).IsModified = true;
            ctx.SaveChanges();
        }

        public void AddProductQuantity(int id, int quantity)
        {
            Product product = GetProduct(id);
            ctx.Products.Attach(product);
            product.QuantityInStock += quantity;
            ctx.Entry(product).Property(q => q.QuantityInStock).IsModified = true;
            ctx.SaveChanges();
        }
    }
}
