using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionService.ApplicationCore.Entities;
using PromotionService.ApplicationCore.Repositories;

namespace PromotionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionSalesRepositoryAsync repository;

        public PromotionController(IPromotionSalesRepositoryAsync repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPromotions()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewPromotion(PromotionSales promotion)
        {
            return Ok(await repository.InsertAsync(promotion));
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
