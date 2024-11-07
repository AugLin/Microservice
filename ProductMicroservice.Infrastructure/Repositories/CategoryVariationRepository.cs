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
    public class CategoryVariationRepository : BaseRepository<CategoryVariation>, ICategoryVariationRepository
    {
        private readonly ProductDbContext context;
        public CategoryVariationRepository(ProductDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryVariation>> GetCategoryVariationByCategoryId(int id)
        {
            return await context.CategoryVariation.Where(x => x.CategoryId == id).ToListAsync();
        }
    }
}
