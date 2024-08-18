using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueRepository
{
    Task<Venue?> GetVenueBySlugAsync(string venueSlug);
    Task<IEnumerable<Venue>> GetAllVenuesAsync();
    Task<IEnumerable<Venue>> GetVenuesByTypeAsync(VenueCategory category);
}