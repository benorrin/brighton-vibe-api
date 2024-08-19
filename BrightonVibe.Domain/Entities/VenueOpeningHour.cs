using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Entities;

public class VenueOpeningHour
{
    public Guid Id { get; set; }
    public Guid VenueId { get; set; }
    public WeekDay WeekDay { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
}