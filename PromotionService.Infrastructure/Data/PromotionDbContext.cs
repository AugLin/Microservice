using Microsoft.EntityFrameworkCore;
using PromotionService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionService.Infrastructure.Data
{
    public class PromotionDbContext : DbContext
    {
        public PromotionDbContext(DbContextOptions<PromotionDbContext> options) : base(options)
        {

        }

        public DbSet<PromotionSales> PromotionSale { get; set; }
        public DbSet<PromotionDetails> PromotionDetails { get; set; }
    }
}
