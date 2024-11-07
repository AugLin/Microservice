using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionService.ApplicationCore.Entities
{
    public class PromotionDetails
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

        public PromotionSales PromotionSales { get; set; }
    }
}
