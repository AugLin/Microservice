using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class ShipperDbContext : DbContext
    {
        public ShipperDbContext(DbContextOptions<ShipperDbContext> options) : base(options)
        {

        }

        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<ShipperRegion> ShipperRegion { get; set; }
    }
}
