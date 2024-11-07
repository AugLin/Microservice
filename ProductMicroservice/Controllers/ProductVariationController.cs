using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationRepository repository;

        public ProductVariationController(IProductVariationRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(ProductVariationValues productVariation)
        {
            return Ok(await repository.InsertAsync(productVariation));
        }

        [HttpGet]
        [Route("GetProductVariation")]
        public async Task<IActionResult> GetProductVariation(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }
    }
}
