﻿using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using BrightonVibe.Data.Entities;
using BrightonVibe.Domain.Enums;
using VenueCategory = BrightonVibe.Domain.Entities.VenueCategory; // Ensure this namespace is included for VenueCategory

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
        public DbSet<VenueCategory> VenueCategories => Set<VenueCategory>();
        public DbSet<VenueImageEntity> VenueImages => Set<VenueImageEntity>();
        public DbSet<VenueOpeningHour> VenueOpeningHours => Set<VenueOpeningHour>();
    }
}