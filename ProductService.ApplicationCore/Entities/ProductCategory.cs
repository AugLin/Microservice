using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class ProductCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ParentCategoryId { get; set; }

        //Navi Attribute
        public IEnumerable<Product> Products { get; set; }
    }
}
