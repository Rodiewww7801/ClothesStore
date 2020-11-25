using ClothesStore.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.EF
{
    public class StoreContext: DbContext
    {
       public  DbSet<Product> Products { get; set; }
    }
}
