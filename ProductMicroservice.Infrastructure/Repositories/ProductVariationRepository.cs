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
    public class ProductVariationRepository : BaseRepository<ProductVariationValues>, IProductVariationRepository
    {
        public ProductVariationRepository(ProductDbContext context) : base(context)
        {
        }
    }
}
