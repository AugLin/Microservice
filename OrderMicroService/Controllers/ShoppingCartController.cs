using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;

namespace OrderMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepositoryAsync shoppingCartRepository;

        public ShoppingCartController(IShoppingCartRepositoryAsync repository)
        {
            shoppingCartRepository = repository;
        }

        [HttpGet]
        [Route("GetShoppingCardByCustomerId/{id}")]
        public async Task<IActionResult> GetShoppingCardByCustomerId(int id)
        {
            var result = await shoppingCartRepository.GetShoppingCartByCustomerId(id);
            if (result == null)
            {
                throw new Exception("No Shopping Cart found with assiciated id");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveShoppingCart/{shoppingCart}")]
        public async Task<IActionResult> SaveShoppingCart(ShoppingCart shoppingCart)
        {
            return Ok(await shoppingCartRepository.UpdateAsync(shoppingCart));
        }

        [HttpGet]
        [Route("DeleteShoppingCart/{id}")]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            return Ok(await shoppingCartRepository.DeleteAsync(id));

        }
    }
}
