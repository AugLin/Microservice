using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Repositories
{
    public interface IProductVariationRepository : IRepositoryAsync<ProductVariationValues>
    {

    }
}
