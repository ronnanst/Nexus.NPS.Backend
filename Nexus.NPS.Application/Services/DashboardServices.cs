using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nexus.NPS.Domain.DTOs;
using Nexus.NPS.Infra;

namespace Nexus.NPS.Application.Services
{
    public class DashboardServices
    {
        private readonly NpsDbContext _database;

        public DashboardServices(ILogger<DashboardServices> logger, NpsDbContext database)
        {
            _database = database;
        }

        public async Task<IList<RatingDTO>> GetRatingByProductId(int productId)
        {
            var product = new List<RatingDTO>();
            if (productId == 99)
            {
                var allEntities = await _database.Ratings.ToListAsync();
                foreach (var item in allEntities)
                {
                    var rating = new RatingDTO
                    {
                        UserId = item.UserId,
                        ProductId = item.ProductId,
                        Score = item.Score,
                        CreatedAt = item.CreatedAt
                    };
                    product.Add(rating);
                }
            }
            else
            {
                var productEntity = await _database.Ratings.Where(x => x.ProductId == productId).ToListAsync();
                foreach (var item in productEntity)
                {
                    var rating = new RatingDTO
                    {
                        UserId = item.UserId,
                        ProductId = item.ProductId,
                        Score = item.Score,
                        CreatedAt = item.CreatedAt
                    };
                    product.Add(rating);
                }
            }

            return product;
        }
    }
}