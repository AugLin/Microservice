using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Repositories
{
    public interface IShipperRepositoryAsync:IRepositoryAsync<Shipper>
    {
        public Task<IEnumerable<Shipper>> GetShipperByRegions(int id);
    }
}
