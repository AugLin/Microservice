using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;

namespace OrderMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentTypeRepositoryAsync _paymentRepository;
        public PaymentController(IPaymentTypeRepositoryAsync repository)
        {
            _paymentRepository = repository;
        }

        [HttpGet]
        [Route("GetPaymentByCustomerId/{id}")]
        public async Task<IActionResult> GetPaymentByCustomerId(int id)
        {
            return Ok(await _paymentRepository.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("SavePayment/{payment}")]
        public async Task<IActionResult> SavePayment(PaymentType payment)
        {
            return Ok(await _paymentRepository.InsertAsync(payment));
        }

        [HttpDelete]
        [Route("DeletePayment/{payment}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            return Ok(await _paymentRepository.DeleteAsync(id));
        }

        [HttpPut]
        [Route("UpdatePayment/{payment}")]
        public async Task<IActionResult> UpdatePayment(PaymentType payment)
        {
            return Ok(await _paymentRepository.UpdateAsync(payment));
        }
    }
}
