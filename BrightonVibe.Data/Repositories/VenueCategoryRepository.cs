using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrightonVibe.Data.Repositories;

public class VenueCategoryRepository : IVenueCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public VenueCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a venue category by its unique identifier.
    /// </summary>
    /// <param name="venueCategoryId">The unique identifier of the venue category.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// the venue category if found; otherwise, null.
    /// </returns>
    public async Task<VenueCategory?> GetVenueCategoryByIdAsync(Guid venueCategoryId)
    {
        var venueCategory = await _context
            .VenueCategories
            .SingleOrDefaultAsync(venueCategory => venueCategory.Id == venueCategoryId);

        if (venueCategory is null)
        {
            return null;
        }

        return new VenueCategory
        {
            Id = venueCategory.Id,
            Name = venueCategory.Name,
            Description = venueCategory.Description,
            CreatedAt = venueCategory.CreatedAt
        };
    }
}