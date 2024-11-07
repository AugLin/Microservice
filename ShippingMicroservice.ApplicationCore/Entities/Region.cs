using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ShipperRegion> ShipperRegions { get; set; }
    }
}
