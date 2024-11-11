using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using RabbitMqHelper;
using System.Collections.Specialized;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly MessageQueue _queue;
        public OrderController(IOrderRepositoryAsync repository)
        {
            _orderRepository = repository;
            _queue = new MessageQueue("amqp://guest:guest@host.docker.internal:5672", "Order MicroService");
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
            await _orderRepository.InsertAsync(order);
            return Ok(Post(order));
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

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            var str = JsonConvert.SerializeObject(order);
            _queue.AddMessageToQueueAsync(str, "OrderExchange", "OrderQueue", "custom-routing-key");
            return Ok("Message has been added to queue");
        }
    }
}
