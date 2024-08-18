using AutoMapper;
using BrightonVibe.Data.Entities;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Enums;
using BrightonVibe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrightonVibe.Data.Repositories;

public class VenueRepository : IVenueRepository
{
    private readonly ApplicationDbContext _context;

    public VenueRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Venue?> GetVenueByIdAsync(Guid id)
    {
        var venueEntity = await _context.Venues.FindAsync(id);
        
        if (venueEntity is null)
        {
            return null;
        }
        
        var venue = new Venue
        {
            Id = venueEntity.Id,
            PhoneNumber = venueEntity.PhoneNumber,
            EmailAddress = venueEntity.EmailAddress,
            Website = venueEntity.Website,
            Instagram = venueEntity.Instagram,
            Facebook = venueEntity.Facebook
        };

        return venue;
    }

    public async Task<IEnumerable<Venue>> GetAllVenuesAsync()
    {
        var venueEntities = await _context.Venues.ToListAsync();

        return venueEntities.Select(venueEntity => new Venue
        {
            Id = venueEntity.Id,
            PhoneNumber = venueEntity.PhoneNumber,
            EmailAddress = venueEntity.EmailAddress,
            Website = venueEntity.Website,
            Instagram = venueEntity.Instagram,
            Facebook = venueEntity.Facebook
        });
    }

    public async Task<IEnumerable<Venue>> GetVenuesByTypeAsync(VenueCategory category)
    {
        var venueEntities = await _context
            .Venues
            .Where(venue => venue.Category == category)
            .ToListAsync();
        
        return venueEntities.Select(venueEntity => new Venue
        {
            Id = venueEntity.Id,
            PhoneNumber = venueEntity.PhoneNumber,
            EmailAddress = venueEntity.EmailAddress,
            Website = venueEntity.Website,
            Instagram = venueEntity.Instagram,
            Facebook = venueEntity.Facebook
        });
    }
}