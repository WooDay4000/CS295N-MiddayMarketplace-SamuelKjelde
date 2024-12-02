using MiddayMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace MiddayMarketplace.Data
{
    public class ApplicationDbContext : DbContext
    {
        // constructor just calls the base class constructor
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // one DbSet for each domain model class
        public DbSet<MarketItem> MarketItems { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
