using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;

namespace OrderMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepositoryAsync repository;

        public CustomerController(ICustomerRepositoryAsync repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetCustomerAddressByCustomerId")]
        public async Task<IActionResult> GetCustomerAddressByCustomerId(int id)
        {
            return Ok(await repository.GetCustomerAddressByUserId(id));
        }

        [HttpPost]
        [Route("SaveCustomerAddress")]
        public async Task<IActionResult> SaveCustomerAddress(Address address, int id)
        {

            return Ok(await repository.SaveCustomerAddress(address, id));
        }
        [HttpPost]
        [Route("SaveNewCustomer/{customer}")]
        public async Task<IActionResult> SaveCustomerAddress(Customer customer)
        {

            return Ok(await repository.InsertAsync(customer));
        }

    }
}
