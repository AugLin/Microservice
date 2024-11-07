using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly OrderDbContext _context;
        public CustomerRepositoryAsync(OrderDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Address> GetCustomerAddressByUserId(int userId)
        {
            var userAddress = await _context.UserAddress.Where(ua => ua.CustomerId == userId).FirstOrDefaultAsync();
            if (userAddress == null)
            {
                throw new Exception("Customer Not Found");
            }
            var address = await _context.Address.Where(a => a.Id == userAddress.AddressId).FirstOrDefaultAsync();

            return address;
        }

        public async Task<int> SaveCustomerAddress(Address address, int id)
        {
            // Get Customer Info
            var customer = await _context.Set<Customer>().FindAsync(id);
            if (customer == null)
            {
                throw new Exception("No Customer Found");
            }
            // Create Address
            await _context.Set<Address>().AddAsync(address);
            await _context.SaveChangesAsync();

            // Getting primary Key addressID
            var userAddress = new UserAddress();
            userAddress.CustomerId = id;
            userAddress.AddressId = address.Id;
            userAddress.IsDefaultAddress = true;

            await _context.Set<UserAddress>().AddAsync(userAddress);
            return await _context.SaveChangesAsync();
        }
    }
}
