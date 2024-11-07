using Microsoft.Identity.Client;
using ReviewMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicationCore.Repositories
{
    public interface ICustomerRepositoryAsync : IRepositoryAsync<CustomerReview>
    {
        public Task<IEnumerable<CustomerReview>> GetReviewsByCustomerId(int id);
        public Task<IEnumerable<CustomerReview>> GetReviewsByProductId(int id);
        public Task<IEnumerable<CustomerReview>> GetReviewsByYear(string year);
        public Task<int> ApproveReview(int id);
        public Task<int> DenyReview(int id);
    }
}
