using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Entities;

public class VenueOpeningHour
{
    public Guid Id { get; set; }
    public Guid VenueId { get; set; }
    public WeekDay WeekDay { get; set; }
    public DateTime OpeningTime { get; set; }
    public DateTime ClosingTime { get; set; }
}