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
    public class OrderRepositoryAsync : BaseRepositoryAsync<Order>, IOrderRepositoryAsync
    {
        private readonly OrderDbContext context;
        public OrderRepositoryAsync(OrderDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> CompleteOrder(int id)
        {
            var order = await context.Set<Order>().FindAsync(id);
            order.OrderStatus = "Completed";
            return await context.SaveChangesAsync();
        }
    }
}
