using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class ProductVariationValues
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int VariationValueId { get; set; }

        public Product Product { get; set; }
        public VariationValue VariationValue { get; set; }
    }
}
