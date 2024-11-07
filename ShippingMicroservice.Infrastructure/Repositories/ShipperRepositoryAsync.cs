using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Repositories;
using ShippingMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShipperRepositoryAsync : BaseRepositoryAsync<Shipper>, IShipperRepositoryAsync
    {
        private readonly ShipperDbContext context;
        public ShipperRepositoryAsync(ShipperDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shipper>> GetShipperByRegions(int id)
        {
            return await context.ShipperRegion
                            .Where(sr => sr.RegionId == id)
                            .Select(sr => sr.Shipper)
                            .ToListAsync();
        }
    }
}
