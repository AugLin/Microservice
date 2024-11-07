using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string ProfilePic { get; set; }

        public string UserId { get; set; }

        // Navigation property for related UserAddresses
        public IEnumerable<UserAddress> UserAddresses { get; set; }
    }
}
