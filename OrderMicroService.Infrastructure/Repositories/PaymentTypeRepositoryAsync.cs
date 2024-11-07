using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Infrastructure.Repositories
{
    public class PaymentTypeRepositoryAsync : BaseRepositoryAsync<PaymentType>, IPaymentTypeRepositoryAsync
    {
        public PaymentTypeRepositoryAsync(OrderDbContext context) : base(context)
        {
        }
    }
}
