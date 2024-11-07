using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationRepository repository;

        public CategoryVariationController(ICategoryVariationRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(CategoryVariation categoryVariation)
        {
            return Ok(await repository.InsertAsync(categoryVariation));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet]
        [Route("GetCategoryVariationById")]
        public async Task<IActionResult> GetCategoryVariationById(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }

        [HttpGet]
        [Route("GetCategoryVariationByCategoryId")]
        public async Task<IActionResult> GetCategoryVariationByCategoryId(int id)
        {
            return Ok(await repository.GetCategoryVariationByCategoryId(id));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await repository.DeleteAsync(id));
        }
    }
}
