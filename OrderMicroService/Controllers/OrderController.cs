using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using System.Collections.Specialized;

namespace OrderMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepositoryAsync _orderRepository;
        public OrderController(IOrderRepositoryAsync repository)
        {
            _orderRepository = repository;
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderRepository.GetAllAsync());
        }

        [HttpPost]
        [Route("SaveOrder")]
        public async Task<IActionResult> SaveOrder(Order order)
        {
            return Ok(await _orderRepository.InsertAsync(order));
        }

        [HttpGet]
        [Route("CheckOrderHistory/{id}")]
        public async Task<IActionResult> CheckOrderHistory(int id)
        {
            return Ok(await _orderRepository.GetByIdAsync(id));
        }

        [HttpGet]
        [Route("CheckOrderStatus/{id}")]
        public async Task<IActionResult> CheckOrderStatus(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return Ok(order.OrderStatus);
        }

        [HttpPut]
        [Route("CancelOrder/{id}")]
        public async Task<IActionResult> Cancelorder(int id)
        {
            return Ok(await _orderRepository.DeleteAsync(id));
        }

        [HttpPost]
        [Route("OrderCompleted/{id}")]
        public async Task<IActionResult> OrderCompleted(int id)
        {
            return Ok(await _orderRepository.CompleteOrder(id));
        }

        [HttpPut]
        [Route("UpdateOrder/{order}")]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            return Ok(await _orderRepository.UpdateAsync(order));
        }
    }
}
