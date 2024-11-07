using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        // Navigation property for the related Order
        public Order Order { get; set; }
    }
}
