using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ReviewMicroservice.ApplicationCore.Entities;
using ReviewMicroservice.ApplicationCore.Repositories;
using ReviewMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<CustomerReview>, ICustomerRepositoryAsync
    {
        private readonly ReviewDbContext context;
        public CustomerRepositoryAsync(ReviewDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> ApproveReview(int id)
        {
            var review = await context.Set<CustomerReview>().FindAsync(id);
            review.ApproveStatus = "Approved";
            return await context.SaveChangesAsync();
        }

        public async Task<int> DenyReview(int id)
        {
            var review = await context.Set<CustomerReview>().FindAsync(id);
            review.ApproveStatus = "Deny";
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerReview>> GetReviewsByCustomerId(int id)
        {
            return await context.CustomerReview.Where(x => x.CustomerId == id).ToListAsync();
        }

        public async Task<IEnumerable<CustomerReview>> GetReviewsByProductId(int id)
        {
            return await context.CustomerReview.Where(x => x.ProductId == id).ToListAsync();
        }

        public async Task<IEnumerable<CustomerReview>> GetReviewsByYear(string year)
        {
            if (int.TryParse(year, out int reviewYear))
            {
                return await context.CustomerReview
                    .Where(x => x.ReviewDate.Year == reviewYear)
                    .ToListAsync();
            }

            return Enumerable.Empty<CustomerReview>();
        }
    }
}
