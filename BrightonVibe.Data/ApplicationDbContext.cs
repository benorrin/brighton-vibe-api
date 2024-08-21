using System;
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

        // Account entities
        public DbSet<AccountEntity> Accounts => Set<AccountEntity>();
        
        // Venue entities
        public DbSet<VenueEntity> Venues => Set<VenueEntity>();
        public DbSet<VenueTypeEntity> VenueCategories => Set<VenueTypeEntity>();
        public DbSet<VenueImageEntity> VenueImages => Set<VenueImageEntity>();
        public DbSet<VenueOpeningHourEntity> VenueOpeningHours => Set<VenueOpeningHourEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VenueOpeningHourEntity>()
                .Property(v => v.OpeningTime)
                .HasColumnType("time without time zone");

            modelBuilder.Entity<VenueOpeningHourEntity>()
                .Property(v => v.ClosingTime)
                .HasColumnType("time without time zone");
            
        }
    }
}