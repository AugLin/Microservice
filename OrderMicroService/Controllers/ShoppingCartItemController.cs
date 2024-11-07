using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Repositories;

namespace OrderMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemRepositoryAsync repository;

        public ShoppingCartItemController(IShoppingCartItemRepositoryAsync repository)
        {
            this.repository = repository;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCartItemById(int id)
        {
            return Ok(await repository.DeleteAsync(id));
        }
    }
}
