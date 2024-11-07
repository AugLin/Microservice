using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface ICustomerRepositoryAsync:IRepositoryAsync<Customer>
    {
        public Task<Address> GetCustomerAddressByUserId(int userId);
        public Task<int> SaveCustomerAddress(Address address, int id);
    }
}
