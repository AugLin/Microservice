using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Repositories
{
    public interface IRepositoryAsync<T>
    {
        Task<int> InsertAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
