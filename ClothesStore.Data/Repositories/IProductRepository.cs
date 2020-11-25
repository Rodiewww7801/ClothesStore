using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products();
    }
}
