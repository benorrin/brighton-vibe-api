using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrightonVibe.Data.Repositories;

public class VenueImageRepository : IVenueImageRepository
{
    private readonly ApplicationDbContext _context;

    public VenueImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<VenueImage>> GetVenueImagesByVenueId(Guid venueId)
    {
        var venueImages = await _context
            .VenueImages
            .Where(venueImage => venueImage.VenueId == venueId)
            .ToListAsync();

        return venueImages.Select(venueImage => new VenueImage
        {
            Id = venueImage.Id,
            VenueId = venueImage.VenueId,
            ImageUrl = venueImage.ImageUrl,
            Featured = venueImage.Featured,
            CreatedAt = venueImage.CreatedAt
        });
    }
}