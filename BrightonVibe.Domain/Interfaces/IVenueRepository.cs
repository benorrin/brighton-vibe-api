using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueRepository
{
    Task<Venue?> GetVenueByIdAsync(Guid id);
    Task<IEnumerable<Venue>> GetAllVenuesAsync();
    Task<IEnumerable<Venue>> GetVenuesByTypeAsync(VenueType type);
}