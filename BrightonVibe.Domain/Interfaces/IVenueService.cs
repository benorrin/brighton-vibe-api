using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueService
{
    Task<Venue> GetVenueByIdAsync(Guid id);
    Task<IEnumerable<Venue>> GetAllVenuesAsync();
    Task CreateVenueAsync(Venue venue);
    Task UpdateVenueAsync(Venue venue);
    Task DeleteVenueAsync(Guid id);
}