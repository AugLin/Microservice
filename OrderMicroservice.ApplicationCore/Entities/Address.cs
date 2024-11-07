using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        // Navigation property for related UserAddresses
        public IEnumerable<UserAddress> UserAddresses { get; set; }
    }
}
