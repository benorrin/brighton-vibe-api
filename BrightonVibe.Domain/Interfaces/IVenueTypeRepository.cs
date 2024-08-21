using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueTypeRepository
{
    Task<VenueType?> GetVenueTypeByIdAsync(Guid venueTypeId);
}