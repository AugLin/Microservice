using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class CategoryVariation
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string VariationName { get; set; }

        public IEnumerable<VariationValue> VariationValues { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
