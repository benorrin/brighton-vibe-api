using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueRepository
{
    Task<Venue?> GetVenueBySlugAsync(string venueSlug);
    Task<IEnumerable<Venue>> GetAllVenuesAsync();
    Task<IEnumerable<Venue>> GetVenuesByCategoryIdAsync(Guid venueCategoryId);
}