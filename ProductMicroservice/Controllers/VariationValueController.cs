using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueRepository repository;

        public VariationValueController(IVariationValueRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(VariationValue variationValue)
        {
            return Ok(await repository.InsertAsync(variationValue));
        }

        [HttpGet]
        [Route("GetVariationid")]
        public async Task<IActionResult> GetVariationId(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }
    }
}
