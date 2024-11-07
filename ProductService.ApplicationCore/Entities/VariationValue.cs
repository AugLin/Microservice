using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class VariationValue
    {
        public int Id { get; set; }
        public int VariationId { get; set; }
        public decimal Value { get; set; }

        public IEnumerable<ProductVariationValues> ProductVariationValues { get; set; }
    }
}
