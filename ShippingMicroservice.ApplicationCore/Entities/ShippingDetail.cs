using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class ShippingDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShipperId { get; set; }
        public string ShippingStatus { get; set; }
        public string TrackingNumber { get; set; }

        public Shipper shipper { get; set; }
    }
}
