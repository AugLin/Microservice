using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }


        public ShoppingCart ShoppingCart { get; set; }
    }
}
