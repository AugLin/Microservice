using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository repository;

        public CategoryController(ICategoryRepository repository)
        {
            this.repository = repository;
        }


        [HttpPost]
        [Route("SaveCategory")]
        public async Task<IActionResult> SaveCategory(ProductCategory category)
        {
            return Ok(await repository.InsertAsync(category));
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await repository.DeleteAsync(id));
        }

        [HttpGet]
        [Route("GetCategoryByParentCategoryId")]
        public async Task<IActionResult> GetCategoryByParentCategoryId(int id)
        {
            return Ok(await repository.GetCategoryByParentCategoryId(id));
        }
    }
}
