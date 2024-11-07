using PromotionService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionService.ApplicationCore.Repositories
{
    public interface IPromotionSalesRepositoryAsync : IRepositoryAsync<PromotionSales>
    {
        public Task<IEnumerable<PromotionSales>> GetPromotionsByProductName(string name);
        public Task<IEnumerable<PromotionSales>> GetActivePromotions();
    }
}
