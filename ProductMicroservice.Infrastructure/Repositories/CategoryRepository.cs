using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<ProductCategory>, ICategoryRepository
    {
        private readonly ProductDbContext context;
        public CategoryRepository(ProductDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoryByParentCategoryId(int id)
        {
            var products = await context.ProductCategory.Where(x => x.ParentCategoryId == id).ToListAsync();
            return products;
        }
    }
}
