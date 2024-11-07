using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int PaymentMethodId { get; set; }

        public string PaymentName { get; set; }

        public string ShippingAddress { get; set; }

        public string ShippingMethod { get; set; }

        public decimal BillAmount { get; set; }

        public string OrderStatus { get; set; }

        // Navigation property for the OrderDetails
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
