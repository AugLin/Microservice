using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicationCore.Entities
{
    public class CustomerReview
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public string ApproveStatus { get; set; }
    }
}
