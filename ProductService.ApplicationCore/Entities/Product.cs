using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }
        public string SKU { get; set; }

        //Navi Attribute
        public ProductCategory Category { get; set; }
        public IEnumerable<ProductVariationValues> productVariationValues { get; set; }
        public IEnumerable<CategoryVariation> CategoryVariations { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
