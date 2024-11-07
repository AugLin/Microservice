using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class UserAddress
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public bool IsDefaultAddress { get; set; }

        // Navigation properties for related Customer and Address
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
