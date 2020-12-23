using ClothesStore.Data.Entities.OrderAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain.Interfaces
{
    public interface ICartProvider
    {
        Order GetCart();
    }
}
