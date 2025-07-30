using Microsoft.EntityFrameworkCore;
using Nexus.NPS.Infra.Entities;

namespace Nexus.NPS.Infra
{
	public class NpsDbContext : DbContext
	{
		public NpsDbContext(DbContextOptions<NpsDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}