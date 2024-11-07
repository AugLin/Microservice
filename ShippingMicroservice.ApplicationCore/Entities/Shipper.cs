using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmailId { get; set; }
        public string Phone { get; set; }
        public string contactPerson { get; set; }

        public IEnumerable<ShipperRegion> ShipperRegion { get; set; }
    }
}
