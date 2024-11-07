using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<int> InsertAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
