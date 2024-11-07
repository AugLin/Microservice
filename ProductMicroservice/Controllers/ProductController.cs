using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetListProducts")]
        public async Task<IActionResult> GetListProducts()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(Product product)
        {
            return Ok(await repository.InsertAsync(product));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Product product)
        {
            return Ok(repository.UpdateAsync(product));
        }

        //[HttpPut]
        //[Route("InActive")]
        //public Task<IActionResult> InActive()
        //{
        //    return Ok();
        //}

        [HttpGet]
        [Route("GetProductByCategoryId")]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            return Ok(await repository.GetProductByCategoryId(id));
        }

        [HttpGet]
        [Route("GetProductByName")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            return Ok(await repository.GetProductByName(name));
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await repository.DeleteAsync(id));
        }
    }
}
