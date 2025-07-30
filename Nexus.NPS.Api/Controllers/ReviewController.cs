using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.NPS.Application.Services;
using Nexus.NPS.Domain.DTOs;
using Nexus.NPS.Infra;

namespace Nexus.NPS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly NpsDbContext _database;
        private readonly ReviewServices _reviewServices;

        public ReviewController(ILogger<ReviewController> logger, NpsDbContext database, ReviewServices reviewServices)
        {
            _logger = logger;
            _database = database;
            _reviewServices = reviewServices;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _database.Products.OrderBy(x => x.Id).ToListAsync() ?? [];
                return Ok(products);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> SaveReview(ReviewDTO dto)
        {
            try
            {
                var success = await _reviewServices.CreateOrUpdate(dto);

                if (success) return Ok(new { success = true });

                return BadRequest(new { success = false, message = "Something Went Wrong!" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
