using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionService.ApplicationCore.Entities
{
    public class PromotionSales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<PromotionDetails> promotionDetails { get; set; }
    }
}
