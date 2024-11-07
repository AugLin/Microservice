using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Repositories
{
    public interface IProductRepository : IRepositoryAsync<Product>
    {
        public Task<IEnumerable<Product>> GetProductByCategoryId(int id);
        public Task<Product> GetProductByName(string name);
    }
}
