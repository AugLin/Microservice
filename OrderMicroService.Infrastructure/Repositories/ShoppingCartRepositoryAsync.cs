using Microsoft.EntityFrameworkCore;
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
    public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCartRepositoryAsync>, IShoppingCartRepositoryAsync
    {
        private readonly OrderDbContext context;
        public ShoppingCartRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartByCustomerId(int id)
        {
            return await context.ShoppingCart.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public Task<int> InsertAsync(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ShoppingCart>> IRepositoryAsync<ShoppingCart>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<ShoppingCart> IRepositoryAsync<ShoppingCart>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
