using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueTypeRepository
{
    Task<VenueType?> GetVenueTypeByIdAsync(Guid venueTypeId);
    Task<VenueType?> GetVenueTypeBySlugAsync(string venueTypeSlug);
    Task<IEnumerable<VenueType>> GetVenueTypesByCategoryAsync(Guid venueCategoryId);
}