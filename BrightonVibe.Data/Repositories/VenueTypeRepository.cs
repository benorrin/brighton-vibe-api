using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrightonVibe.Data.Repositories;

public class VenueTypeRepository : IVenueTypeRepository
{
    private readonly ApplicationDbContext _context;

    public VenueTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a venue Type by its unique identifier.
    /// </summary>
    /// <param name="venueTypeId">The unique identifier of the venue Type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// the venue Type if found; otherwise, null.
    /// </returns>
    public async Task<VenueType?> GetVenueTypeByIdAsync(Guid venueTypeId)
    {
        var venueType = await _context
            .VenueCategories
            .SingleOrDefaultAsync(venueType => venueType.Id == venueTypeId);

        if (venueType is null)
        {
            return null;
        }

        return new VenueType
        {
            Id = venueType.Id,
            Slug = venueType.Slug,
            Name = venueType.Name,
            Description = venueType.Description,
            CreatedAt = venueType.CreatedAt
        };
    }
}