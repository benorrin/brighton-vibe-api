using System.Diagnostics;
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

        public DbSet<AccountEntity> Accounts => Set<AccountEntity>();
        public DbSet<VenueEntity> Venues => Set<VenueEntity>();
        public DbSet<VenueImageEntity> VenueImages => Set<VenueImageEntity>();
        public DbSet<VenueOpeningHour> VenueOpeningHours => Set<VenueOpeningHour>();
    }
}