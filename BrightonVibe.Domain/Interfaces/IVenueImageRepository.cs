

using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueImageRepository
{
    Task<IEnumerable<VenueImage>> GetVenueImagesByVenueId(Guid venueId);
}