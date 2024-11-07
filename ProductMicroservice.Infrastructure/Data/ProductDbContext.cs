using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<CategoryVariation> CategoryVariation { get; set; }
        public DbSet<VariationValue> VariationValue { get; set; }
        public DbSet<ProductVariationValues> ProductVariationValue { get; set; }
    }
}
