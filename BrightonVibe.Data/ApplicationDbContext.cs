using Microsoft.EntityFrameworkCore;
using BrightonVibe.Data.Entities;

namespace BrightonVibe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<VenueEntity> Venues { get; set; }
    }
}