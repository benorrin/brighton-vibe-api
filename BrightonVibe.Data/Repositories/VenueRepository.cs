using BrightonVibe.Domain.Entities;
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
        var venueEntity = await _context.Venues
            .Include(venue => venue.VenueImages)
            .Include(venue => venue.VenueOpeningHours)
            .SingleOrDefaultAsync(venue => venue.Slug == venueSlug);
    
        if (venueEntity is null)
        {
            return null;
        }
    
        var venue = new Venue
        {
            Id = venueEntity.Id,
            Slug = venueEntity.Slug,
            Name = venueEntity.Name,
            CreatedAt = venueEntity.CreatedAt,
            VenueTypeId = venueEntity.VenueTypeId,
            Summary = venueEntity.Summary,
            Description = venueEntity.Description,
            Address = venueEntity.Address,
            PhoneNumber = venueEntity.PhoneNumber,
            EmailAddress = venueEntity.EmailAddress,
            Website = venueEntity.Website,
            Instagram = venueEntity.Instagram,
            Facebook = venueEntity.Facebook,
            VenueImages = venueEntity.VenueImages.Select(image => new VenueImage
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                Featured = image.Featured,
                Description = image.Description,
                CreatedAt = image.CreatedAt
            }).ToList(),
            VenueOpeningHours = venueEntity.VenueOpeningHours.Select(openingHour => new VenueOpeningHour
            {
                Id = openingHour.Id,
                WeekDay = openingHour.WeekDay,
                OpeningTime = openingHour.OpeningTime,
                ClosingTime = openingHour.ClosingTime
            }).ToList()
        };

        return venue;
    }

    public async Task<IEnumerable<Venue>> GetAllVenuesAsync()
    {
        var venueEntities = await _context.Venues
            .Include(venue => venue.VenueImages)
            .Include(venue => venue.VenueOpeningHours)
            .ToListAsync();

        return venueEntities.Select(venueEntity => new Venue
        {
            Id = venueEntity.Id,
            Slug = venueEntity.Slug,
            Name = venueEntity.Name,
            CreatedAt = venueEntity.CreatedAt,
            VenueTypeId = venueEntity.VenueTypeId,
            Summary = venueEntity.Summary,
            Description = venueEntity.Description,
            Address = venueEntity.Address,
            PhoneNumber = venueEntity.PhoneNumber,
            EmailAddress = venueEntity.EmailAddress,
            Website = venueEntity.Website,
            Instagram = venueEntity.Instagram,
            Facebook = venueEntity.Facebook,
            VenueImages = venueEntity.VenueImages.Select(image => new VenueImage
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                Featured = image.Featured,
                Description = image.Description,
                CreatedAt = image.CreatedAt
            }).ToList(),
            VenueOpeningHours = venueEntity.VenueOpeningHours.Select(openingHour => new VenueOpeningHour
            {
                Id = openingHour.Id,
                WeekDay = openingHour.WeekDay,
                OpeningTime = openingHour.OpeningTime,
                ClosingTime = openingHour.ClosingTime
            }).ToList()
        });
    }


    public async Task<IEnumerable<Venue>> GetVenuesByTypeIdAsync(Guid venueTypeId, int? limit = null)
    {
        var venueEntities = await _context.Venues
            .Include(venue => venue.VenueImages)
            .Include(venue => venue.VenueOpeningHours)
            .Where(venue => venue.VenueTypeId == venueTypeId)
            .ToListAsync();

        if (limit.HasValue)
        {
            venueEntities = venueEntities.Take(limit.Value).ToList();
        }
    
        return venueEntities.Select(venueEntity => new Venue
        {
            Id = venueEntity.Id,
            Slug = venueEntity.Slug,
            Name = venueEntity.Name,
            CreatedAt = venueEntity.CreatedAt,
            VenueTypeId = venueEntity.VenueTypeId,
            Summary = venueEntity.Summary,
            Description = venueEntity.Description,
            Address = venueEntity.Address,
            PhoneNumber = venueEntity.PhoneNumber,
            EmailAddress = venueEntity.EmailAddress,
            Website = venueEntity.Website,
            Instagram = venueEntity.Instagram,
            Facebook = venueEntity.Facebook,
            VenueImages = venueEntity.VenueImages.Select(image => new VenueImage
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                Featured = image.Featured,
                Description = image.Description,
                CreatedAt = image.CreatedAt
            }).ToList(),
            VenueOpeningHours = venueEntity.VenueOpeningHours.Select(openingHour => new VenueOpeningHour
            {
                Id = openingHour.Id,
                WeekDay = openingHour.WeekDay,
                OpeningTime = openingHour.OpeningTime,
                ClosingTime = openingHour.ClosingTime
            }).ToList()
        });
    }

}