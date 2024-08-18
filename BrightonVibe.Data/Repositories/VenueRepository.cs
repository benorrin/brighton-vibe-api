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

    public async Task<Venue?> GetVenueBySlugAsync(string venueSlug)
    {
        var venueEntity = await _context
            .Venues
            .SingleOrDefaultAsync(venue => venue.Slug == venueSlug);
        
        if (venueEntity is null)
        {
            return null;
        }
        
        var venue = new Venue
        {
            Id = venueEntity.Id,
            Name = venueEntity.Name,
            Category = venueEntity.Category,
            Summary = venueEntity.Summary,
            Description = venueEntity.Description,
            Address = venueEntity.Address,
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
            Name = venueEntity.Name,
            Category = venueEntity.Category,
            Summary = venueEntity.Summary,
            Description = venueEntity.Description,
            Address = venueEntity.Address,
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
            Name = venueEntity.Name,
            Category = venueEntity.Category,
            Summary = venueEntity.Summary,
            Description = venueEntity.Description,
            Address = venueEntity.Address,
            PhoneNumber = venueEntity.PhoneNumber,
            EmailAddress = venueEntity.EmailAddress,
            Website = venueEntity.Website,
            Instagram = venueEntity.Instagram,
            Facebook = venueEntity.Facebook
        });
    }
}