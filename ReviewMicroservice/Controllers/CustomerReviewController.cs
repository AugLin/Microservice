using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ReviewMicroservice.ApplicationCore.Entities;
using ReviewMicroservice.ApplicationCore.Repositories;

namespace ReviewMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerRepositoryAsync repository;
        public CustomerReviewController(ICustomerRepositoryAsync repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReview()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewReview(CustomerReview review)
        {
            return Ok(await repository.InsertAsync(review));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(CustomerReview review)
        {
            return Ok(await repository.UpdateAsync(review));
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            return Ok(await repository.DeleteAsync(id));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            return Ok(await repository.GetByIdAsync(id));
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetReviewsByUserId(int id)
        {
            return Ok(await repository.GetReviewsByCustomerId(id));
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<IActionResult> GetReviewsByProductId(int id)
        {
            return Ok(await repository.GetReviewsByProductId(id));
        }

        [HttpGet]
        [Route("year/{year}")]
        public async Task<IActionResult> GetReviewsByYear(string year)
        {
            return Ok(await repository.GetReviewsByYear(year));
        }

        [HttpPut]
        [Route("approve/{id}")]
        public async Task<IActionResult> ApproveReview(int id)
        {
            return Ok(await repository.ApproveReview(id));
        }

        [HttpPut]
        [Route("deny/{id}")]
        public async Task<IActionResult> DenyReview(int id)
        {
            return Ok(await repository.DenyReview(id));
        }
    }
}
