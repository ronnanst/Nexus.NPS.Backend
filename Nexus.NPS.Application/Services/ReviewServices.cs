using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nexus.NPS.Domain.DTOs;
using Nexus.NPS.Infra;
using Nexus.NPS.Infra.Entities;

namespace Nexus.NPS.Application.Services
{
    public class ReviewServices
    {
        private readonly NpsDbContext _database;

        public ReviewServices(ILogger<ReviewServices> logger, NpsDbContext database)
        {
            _database = database;
        }

        public async Task<bool> CreateOrUpdate(ReviewDTO dto)
        {
            if (!(dto.ProductId >= 0) || (dto.Score < 0 || dto.Score > 5)) return false;

            var existsRating = await _database.Ratings.Where(registry => registry.UserId == dto.UserId)
                .Where(registry => registry.ProductId == dto.ProductId)
                .FirstOrDefaultAsync();

            if (existsRating != null )
            {
                existsRating.Score = dto.Score;
                await _database.SaveChangesAsync();
            }
            else
            {
                var newRating = new Rating()
                {
                    UserId = dto.UserId,
                    ProductId = dto.ProductId,
                    Score = dto.Score,
                    Comment = dto.Comment,
                    CreatedAt = DateTime.UtcNow
                };
                _database.Ratings.Add(newRating);
                await _database.SaveChangesAsync();
            }

            return true;
        }
    }
}