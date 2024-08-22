using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueCategoryRepository
{
    Task<VenueCategory?> GetVenueCategoryBySlugAsync(string venueCategorySlug);
}