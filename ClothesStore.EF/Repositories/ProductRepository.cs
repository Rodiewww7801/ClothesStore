using ClothesStore.Data;
using ClothesStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.EF.Repositories
{
    public class ProductRepository: IProductRepository
    {
        StoreContext ctx = new StoreContext();
        public IEnumerable<Product> Products()
        {
            return ctx.Products;
        }
    }
}
