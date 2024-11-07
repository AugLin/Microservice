using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options): base(options)
        {
            
        }

        public DbSet<CustomerReview> CustomerReview { get; set; }
    }
}
