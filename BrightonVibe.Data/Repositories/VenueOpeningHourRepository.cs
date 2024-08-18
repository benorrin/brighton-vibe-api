using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrightonVibe.Data.Repositories;

public class VenueOpeningHourRepository : IVenueOpeningHourRepository
{
    private readonly ApplicationDbContext _context;

    public VenueOpeningHourRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VenueOpeningHour>> GetVenueOpeningHoursByVenueId(Guid venueId)
    {
        var venueOpeningHour = await _context
            .VenueOpeningHours
            .Where(venueOpeningHour => venueOpeningHour.VenueId == venueId)
            .ToListAsync();
        
        return venueOpeningHour.Select(venueOpeningHour => new VenueOpeningHour
        {
            Id = venueOpeningHour.Id,
            VenueId = venueOpeningHour.VenueId,
            WeekDay = venueOpeningHour.WeekDay,
            OpeningTime = venueOpeningHour.OpeningTime,
            ClosingTime = venueOpeningHour.ClosingTime
        });
    }
}