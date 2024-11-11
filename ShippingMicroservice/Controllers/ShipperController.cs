using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Repositories;
using System.Text;

namespace ShippingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperRepositoryAsync repository;
        private readonly IShippingDetailRepositoryAsync detailRepository;
        public ShipperController(IShipperRepositoryAsync repository, IShippingDetailRepositoryAsync shippingRepo)
        {
            this.repository = repository;
            detailRepository = shippingRepo;
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
        public async Task<IActionResult> UpdateShipper(ShippingDetail shipper)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55444/api/");
            var content = new StringContent(JsonConvert.SerializeObject(shipper), Encoding.UTF8, "application/json");
            var shipperResponse = await client.PutAsync("Shipper", content);

            if (!shipperResponse.IsSuccessStatusCode)
            {
                return StatusCode((int)shipperResponse.StatusCode, "Failed to update Shipper.");
            }

            var orderClient = new HttpClient();
            orderClient.BaseAddress = new Uri("http://localhost:55555/api/");

            var orderContent = new StringContent(JsonConvert.SerializeObject(shipper), Encoding.UTF8, "application/json");
            var orderResponse = await orderClient.PutAsync("Order/UpdateShippingStatus", orderContent);

            if (!orderResponse.IsSuccessStatusCode)
            {
                return StatusCode((int)orderResponse.StatusCode, "Failed to update Order with shipping status.");
            }

            await detailRepository.UpdateAsync(shipper);
            return Ok("Shipper and Order updated successfully.");
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
