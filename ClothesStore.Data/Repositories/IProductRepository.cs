using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesStore.Data.Entities;

namespace ClothesStore.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products();
        IEnumerable<Product> SelectedCategory(string category);
        IEnumerable<string> AllCategories();
        void DeleteProductQuantity(int id, int quantity);
        void AddProductQuantity(int id, int quantity);
        Product GetProduct(int id);
    }
}
