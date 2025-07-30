using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.NPS.Domain.DTOs;
using Nexus.NPS.Infra;

namespace Nexus.NPS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly NpsDbContext _database;

        public UserController(ILogger<UserController> logger, NpsDbContext database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var user = await _database.Users.FirstOrDefaultAsync(user => user.UserName == dto.UserName);

                if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                {
                    return Unauthorized("Invalid Credentials");
                }

                return Ok(new { userId = user.Id });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}