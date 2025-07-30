using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Nexus.NPS.Application.Services;
using Nexus.NPS.Domain.DTOs;
using Nexus.NPS.Infra;
using Nexus.NPS.Infra.Entities;

namespace Nexus.NPS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly NpsDbContext _database;
        private readonly DashboardServices _dashboardServices;

        public DashboardController(ILogger<DashboardController> logger, NpsDbContext database, DashboardServices dashboardServices)
        {
            _logger = logger;
            _database = database;
            _dashboardServices = dashboardServices;
        }

        [HttpGet("FindProductRatings")]
        public async Task<IActionResult> GetRatingByProductId(int productId)
        {
            try
            {
                var product = await _dashboardServices.GetRatingByProductId(productId);
                return Ok(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
