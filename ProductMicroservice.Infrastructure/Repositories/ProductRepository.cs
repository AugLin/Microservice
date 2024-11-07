using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ProductDbContext context;
        public ProductRepository(ProductDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(int id)
        {
            return await context.Product.Where(x => x.Category.id == id).ToListAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await context.Product.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
