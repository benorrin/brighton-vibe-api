using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IVenueOpeningHourRepository
{
    Task<IEnumerable<VenueOpeningHour>> GetVenueOpeningHoursByVenueId(Guid venueId);
}