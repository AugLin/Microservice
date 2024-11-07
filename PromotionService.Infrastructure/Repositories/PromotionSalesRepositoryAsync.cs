using Microsoft.EntityFrameworkCore;
using PromotionService.ApplicationCore.Entities;
using PromotionService.ApplicationCore.Repositories;
using PromotionService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionService.Infrastructure.Repositories
{
    public class PromotionSalesRepositoryAsync : BaseRepositoryAssync<PromotionSales>, IPromotionSalesRepositoryAsync
    {
        private readonly PromotionDbContext context;
        public PromotionSalesRepositoryAsync(PromotionDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PromotionSales>> GetActivePromotions()
        {
            return await context.PromotionSale.Where(ps => ps.StartDate <= DateTime.Now && ps.EndDate >= DateTime.Now).ToListAsync();
        }

        public async Task<IEnumerable<PromotionSales>> GetPromotionsByProductName(string name)
        {
            return await context.PromotionDetails.Where(pd => pd.ProductCategoryName == name).Select(pd => pd.PromotionSales).ToListAsync();
        }
    }
}
