using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Infrastructure.Repositories
{
    public class ShoppingCartItemRepositoryAsync : BaseRepositoryAsync<ShoppingCartItem>, IShoppingCartItemRepositoryAsync
    {
        public ShoppingCartItemRepositoryAsync(OrderDbContext context) : base(context)
        {
        }
    }
}
