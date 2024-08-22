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
    /// Asynchronously retrieves a VenueCategory entity from the database by its slug.
    /// </summary>
    /// <param name="venueCategorySlug">The slug of the venue category to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the 
    /// <see cref="VenueCategory"/> object if found; otherwise, null if no venue category 
    /// with the specified slug exists.
    /// </returns>
    public async Task<VenueCategory?> GetVenueCategoryBySlugAsync(string venueCategorySlug)
    {
        var venueCategory = await _context
            .VenueCategories
            .SingleOrDefaultAsync(venueCategory => venueCategory.Slug == venueCategorySlug);

        if (venueCategory is null)
        {
            return null;
        }

        return new VenueCategory
        {
            Id = venueCategory.Id,
            Slug = venueCategory.Slug,
            Name = venueCategory.Name,
            Description = venueCategory.Description,
            CreatedAt = venueCategory.CreatedAt
        };
    }
}