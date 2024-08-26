using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Entities;

public class Venue
{
    public required Guid Id { get; set; }
    public required string Slug { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }  
    public required Guid VenueTypeId { get; set; }
    public required string Summary { get; set; }
    public required string Description { get; set; }
    public required string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Website { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }
    public IEnumerable<VenueImage> VenueImages { get; set; }
    public IEnumerable<VenueOpeningHour> VenueOpeningHours { get; set; }
    
}