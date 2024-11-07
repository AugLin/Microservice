using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Repositories
{
    public interface ICategoryRepository: IRepositoryAsync<ProductCategory>
    {
        public Task<IEnumerable<ProductCategory>> GetCategoryByParentCategoryId(int id);
    }
}
