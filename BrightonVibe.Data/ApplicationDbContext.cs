using System;
using Microsoft.EntityFrameworkCore;
using BrightonVibe.Data.Entities;
using VenueCategory = BrightonVibe.Domain.Entities.VenueCategory;

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
        public DbSet<VenueCategoryEntity> VenueCategories => Set<VenueCategoryEntity>();
        public DbSet<VenueImageEntity> VenueImages => Set<VenueImageEntity>();
        public DbSet<VenueOpeningHour> VenueOpeningHours => Set<VenueOpeningHour>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VenueOpeningHour>()
                .Property(v => v.OpeningTime)
                .HasColumnType("time without time zone");

            modelBuilder.Entity<VenueOpeningHour>()
                .Property(v => v.ClosingTime)
                .HasColumnType("time without time zone");
            
        }
    }
}