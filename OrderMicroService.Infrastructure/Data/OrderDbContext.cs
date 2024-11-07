using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Infrastructure.Data
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options): base(options)
        {
            
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
    }
}
