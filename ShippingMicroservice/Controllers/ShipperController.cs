using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Repositories;

namespace ShippingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperRepositoryAsync repository;
        public ShipperController(IShipperRepositoryAsync repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("Shipper")]
        public async Task<IActionResult> GetAllShipper()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpPost]
        [Route("Shipper")]
        public async Task<IActionResult> PutShipper(Shipper shipper)
        {
            return Ok(await repository.InsertAsync(shipper));
        }

        [HttpPut]
        [Route("Shipper")]
        public async Task<IActionResult> UpdateShipper(Shipper shipper)
        {
            return Ok(await repository.UpdateAsync(shipper));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetShipperByID(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            return Ok(await repository.DeleteAsync(id));
        }

        [HttpGet]
        [Route("region/{region}")]
        public async Task<IActionResult> GetShipperByRegions(int region)
        {
            return Ok(await repository.GetShipperByRegions(region));
        }
    }
}
