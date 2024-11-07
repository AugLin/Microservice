using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Order>
    {
        public Task<int> CompleteOrder(int id);
    }
}
