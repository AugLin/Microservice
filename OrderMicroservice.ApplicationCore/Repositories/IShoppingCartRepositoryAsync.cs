using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IShoppingCartRepositoryAsync:IRepositoryAsync<ShoppingCart>
    {
        public Task<ShoppingCart> GetShoppingCartByCustomerId(int id);
    }
}
