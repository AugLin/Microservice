using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using PromotionService.ApplicationCore.Entities;
using PromotionService.ApplicationCore.Repositories;
using System.Text;
using System.Text.Json;

namespace PromotionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionSalesRepositoryAsync repository;
        QueueService queueService;
        public PromotionController(IPromotionSalesRepositoryAsync repository, IConfiguration configuration)
        {
            this.repository = repository;
            queueService = new QueueService(configuration);
        }

        [HttpGet]
        public async Task<IActionResult> GetPromotions()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewPromotion(PromotionSales promotion)
        {
            await repository.InsertAsync(promotion);
            await queueService.SendMessageAsync<PromotionSales>(promotion, "OrderQueue");

            return Ok("Log send to the eventBus");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPromotionByID(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> DeletePromotionById(int id)
        {
            return Ok(await repository.DeleteAsync(id));
        }

        [HttpGet]
        [Route("GetPromotionByProductName")]
        public async Task<IActionResult> GetPromotionByProductName(string name)
        {
            return Ok(await repository.GetPromotionsByProductName(name));
        }

        [HttpGet]
        [Route("ActivePromotions")]
        public async Task<IActionResult> GetActivePromotions()
        {
            return Ok(await repository.GetActivePromotions());
        }
    }
}
