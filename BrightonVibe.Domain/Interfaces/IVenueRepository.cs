using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueRepository
{
    Task<Venue> GetVenueByIdAsync(Guid id);
    Task<IQueryable<Venue>> GetAllVenuesAsync();
    Task<IQueryable<Venue>> GetVenuesByTypeAsync(VenueType type);
    Task AddVenueAsync(Venue venue);
    Task UpdateVenueAsync(Venue venue);
    Task DeleteVenueAsync(Guid id);
}